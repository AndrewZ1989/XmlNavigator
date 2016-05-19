using System.Collections.Generic;
using System.IO;
using System.Xml;
using XmlBig.Core.Factory;
using XmlBig.Core.ObjectRepresentation;

namespace XmlBig.Example
{
	public class TestXmlObject : XmlObject
	{
		public TestXmlObject( Stream content,
			XmlReaderSettings settings,
			INavigationActionFactory navigationFactory )
			: base( () =>
			{
				content.Position = 0;
				var sr = new StreamReader( content );
				return XmlReader.Create( sr, settings );
			}, navigationFactory )
		{
		}


		public IEnumerable<BXmlObject> BValue
		{
			get
			{
				var action = CurrentNavigation.
					ToElement( "D" ).GoInner().
					ToChild( "A" ).GoInner()
					.GetAction();

				long bCount = GetElementsCount( action, "B" );

				for ( long i = 1; i <= bCount; i++ )
				{
					var bAction = _navigationFactory.CreateNew( action ).ToChild( "B", i ).GetAction();
					yield return new BXmlObject( GetReaderDelegate, bAction, _navigationFactory );
				}
			}
		}

	}
}

using XmlBig.Core;
using XmlBig.Core.Factory;
using XmlBig.Core.ObjectRepresentation;

namespace XmlBig.Example
{
    public class BXmlObject : XmlObject
	{
		public BXmlObject( GetXmlReaderDelegate rDelegate, INavigationAction action, INavigationActionFactory navigationFactory )
			: base( rDelegate, action, navigationFactory )
		{
		}

		public string InnerXml
		{
			get
			{
				return NavigateAndGetInnerXml( CurrentNavigation.GetAction() );
			}
		}
	}
}

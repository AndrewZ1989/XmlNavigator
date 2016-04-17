using System;
using System.Xml;

namespace XmlBig.Core
{
	internal class GoToElementNavigationAction : INavigationAction
	{
		#region .ctor

		public GoToElementNavigationAction( string name, long position, bool useSomeDepth )
		{
			_elementName = name;
			_elementPosition = position;
			_useSomeDepth = useSomeDepth;
		} 

		#endregion

		#region Fields

		private string _elementName;
		private long _elementPosition;
		private bool _useSomeDepth; 

		#endregion

		#region INavigationAction

		public XmlReader Execute( XmlReader reader )
		{
			long elementsCount = 0;

			int initialDepth = reader.Depth;

			#region Go to element position

			while ( reader.ReadToFollowing( _elementName ) )
			{
				if ( _useSomeDepth )
				{
					if ( reader.Depth != initialDepth + 1 ) continue;
				}

				elementsCount++;
				if ( elementsCount == _elementPosition ) break;
			} 

			#endregion

			if ( elementsCount != _elementPosition ) throw new Exception( "Element with name <" + _elementName + "> not found.");

			return reader;
		}

		public INavigationAction Clone()
		{
			return new GoToElementNavigationAction( _elementName, _elementPosition, _useSomeDepth );
		}

		#endregion

	}
}

using System;
using System.Xml;

namespace XmlBig.Core
{
	internal class GoToAttributeNavigationAction : INavigationAction
	{
		#region .ctor

		public GoToAttributeNavigationAction( string attributeName )
		{
			_attributeName = attributeName;
		} 

		#endregion

		#region Fields

		private string _attributeName; 

		#endregion

		#region INavigationAction

		public XmlReader Execute( XmlReader reader )
		{
			if ( reader.MoveToAttribute( _attributeName ) == false ) throw new Exception( "Attribute with name <" + _attributeName + "> not found." );

			return reader;
		}

		public INavigationAction Clone()
		{
			return new GoToAttributeNavigationAction( _attributeName );
		}

		#endregion

	}
}

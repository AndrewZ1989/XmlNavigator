using System.Xml;

namespace XmlBig.Core
{
	internal class NopeNavigationAction : INavigationAction
	{
		#region INavigationAction

		public XmlReader Execute( XmlReader reader )
		{
			return reader;
		}

		public INavigationAction Clone()
		{
			return new NopeNavigationAction();
		}

		#endregion

	}
}

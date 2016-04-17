using System.Xml;

namespace XmlBig.Core
{
	internal class InnerXmlNavigationAction : INavigationAction
	{
		#region INavigationAction

		public XmlReader Execute( XmlReader reader )
		{
			return reader.ReadSubtree();
		}

		public INavigationAction Clone()
		{
			return new InnerXmlNavigationAction();
		}

		#endregion

	}
}

using System.Xml;

namespace XmlBig.Core
{
	public interface INavigationAction
	{
		XmlReader Execute( XmlReader reader );

		INavigationAction Clone();
	}
}

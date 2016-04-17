
namespace XmlBig.Core
{
	public interface INavigationActionBuilder
	{
		#region Build

		INavigationActionBuilder GoInner();

		INavigationActionBuilder ToElement( string elementName, long elementPosition = 1 );

		INavigationActionBuilder ToChild( string elementName, long elementPosition = 1 );

		INavigationActionBuilder ToAttribute( string attributeName );

		#endregion

		INavigationAction GetAction();

	}
}

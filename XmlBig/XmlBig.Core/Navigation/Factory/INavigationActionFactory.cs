
namespace XmlBig.Core.Factory
{
	public interface INavigationActionFactory
	{
		INavigationActionBuilder CreateNew();

		INavigationActionBuilder CreateNew( INavigationAction startAction );
	}
}

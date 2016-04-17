
namespace XmlBig.Core.Factory
{
	public class NavigationActionFactory : INavigationActionFactory
	{
		#region INavigationActionFactory

		public INavigationActionBuilder CreateNew()
		{
			return new NavigationActionBuilder();
		}

		public INavigationActionBuilder CreateNew( INavigationAction startAction )
		{
			return new NavigationActionBuilder( startAction );
		}

		#endregion

	}
}

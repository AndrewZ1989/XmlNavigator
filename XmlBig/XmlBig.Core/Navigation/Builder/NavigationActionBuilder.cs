
namespace XmlBig.Core
{
	internal class NavigationActionBuilder : INavigationActionBuilder
	{
		public NavigationActionBuilder()
		{
			_action = new NopeNavigationAction();
		}

		public NavigationActionBuilder( INavigationAction action )
		{
			_action = action;
		}

		private INavigationAction _action;

		#region Члены INavigationActionBuilder

		public INavigationAction GetAction()
		{
			return _action;
		}

		#region Build

		public INavigationActionBuilder GoInner()
		{
			return this.Next( new InnerXmlNavigationAction() );
		}

		public INavigationActionBuilder ToElement( string elementName, long elementPosition = 1 )
		{
			return this.Next( new GoToElementNavigationAction( elementName, elementPosition, false ) );
		}

		public INavigationActionBuilder ToChild( string elementName, long elementPosition = 1 )
		{
			return this.Next( new GoToElementNavigationAction( elementName, elementPosition, true ) );
		}

		public INavigationActionBuilder ToAttribute( string attributeName )
		{
			return this.Next( new GoToAttributeNavigationAction( attributeName ) );
		} 

		#endregion

		#endregion

		#region Private

		private INavigationActionBuilder Next( INavigationAction action )
		{
			_action = new CompositeNavigationAction( _action, action );
			return this;
		}

		#endregion

	}
}

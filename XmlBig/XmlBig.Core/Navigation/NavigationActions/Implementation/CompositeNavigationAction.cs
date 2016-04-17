using System.Xml;

namespace XmlBig.Core
{
	internal class CompositeNavigationAction : INavigationAction
	{
		#region .ctor

		public CompositeNavigationAction( INavigationAction firstAction, INavigationAction secondAction )
		{
			_firstAction = firstAction;
			_secondAction = secondAction;
		} 

		#endregion

		#region Fields

		private INavigationAction _firstAction;
		private INavigationAction _secondAction; 

		#endregion

		#region INavigationAction

		public XmlReader Execute( XmlReader reader )
		{
			return _secondAction.Execute( _firstAction.Execute( reader ) );
		}

		public INavigationAction Clone()
		{
			return new CompositeNavigationAction( _firstAction.Clone(), _secondAction.Clone() );
		}

		#endregion

	}
}

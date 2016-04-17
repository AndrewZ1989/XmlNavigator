using System.Xml;
using XmlBig.Core.Factory;

namespace XmlBig.Core.ObjectRepresentation
{
	public abstract class XmlObject
	{
		#region .ctor

		public XmlObject( GetXmlReaderDelegate getReaderDelegate,
			INavigationAction navigationAction,
			INavigationActionFactory navigationFactory )
		{
			_getReaderDelegate = getReaderDelegate;
			_navigationAction = navigationAction;
			_navigationFactory = navigationFactory;
		}

		public XmlObject( GetXmlReaderDelegate getReaderDelegate,
			INavigationActionFactory navigationFactory )
		{
			_getReaderDelegate = getReaderDelegate;
			_navigationAction = navigationFactory.CreateNew().GetAction();
			_navigationFactory = navigationFactory;
		}

		#endregion

		#region Fields

		private GetXmlReaderDelegate _getReaderDelegate;

		private INavigationAction _navigationAction;

		protected INavigationActionFactory _navigationFactory;

		#endregion

		#region Protected

		protected INavigationActionBuilder CurrentNavigation { get { return _navigationFactory.CreateNew( _navigationAction ); } }

		protected GetXmlReaderDelegate GetReaderDelegate { get { return _getReaderDelegate; } }

		protected string NavigateAndGetValue()
		{
			using ( var reader = GetNavigatedReader() )
			{
				return reader.Value;
			}
		}

		protected string NavigateAndGetValue( INavigationAction action )
		{
			using ( var reader = GetNavigatedReader( action ) )
			{
				return reader.Value;
			}
		}

		protected string NavigateAndGetInnerXml( INavigationAction action )
		{
			using ( var reader = GetNavigatedReader( action ) )
			{
				return reader.ReadInnerXml();
			}
		}

		protected long GetElementsCount( INavigationAction action, string elementName )
		{
			using ( var reader = GetNavigatedReader( action ) )
			{
				long elementsCount = 0;

				while ( reader.ReadToFollowing( elementName ) ) elementsCount++;

				return elementsCount;
			}
		}



		#endregion

		#region Private

		private XmlReader GetNavigatedReader()
		{
			var sourceReader = _getReaderDelegate.Invoke();
			return _navigationAction.Execute( sourceReader );
		}

		private XmlReader GetNavigatedReader( INavigationAction action )
		{
			var sourceReader = _getReaderDelegate.Invoke();
			return action.Execute( sourceReader );
		}

		#endregion
	}
}

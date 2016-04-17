using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlBig.Core;
using XmlBig.Core.Factory;
using XmlBig.Core.ObjectRepresentation;

namespace XmlBig
{
	public class BXmlObject : XmlObject
	{
		public BXmlObject( GetXmlReaderDelegate rDelegate, INavigationAction action, INavigationActionFactory navigationFactory )
			: base( rDelegate, action, navigationFactory )
		{
		}

		public string InnerXml
		{
			get
			{
				return NavigateAndGetInnerXml( CurrentNavigation.GetAction() );
			}
		}
	}
}

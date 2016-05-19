using XmlBig.Core;
using XmlBig.Core.Factory;
using XmlBig.Core.ObjectRepresentation;

namespace XmlBig.Example
{
    public class InnerFoo : XmlObject
    {
        public InnerFoo(GetXmlReaderDelegate rDelegate, INavigationAction action, INavigationActionFactory navigationFactory)
            : base(rDelegate, action, navigationFactory)
        {
        }

        public string Name
        {
            get
            {
                return NavigateAndGetInnerXml(CurrentNavigation.ToAttribute("Name").GetAction());
            }
        }

    }
}

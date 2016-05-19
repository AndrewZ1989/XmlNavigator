using System.Collections.Generic;
using System.IO;
using System.Xml;
using XmlBig.Core.Factory;
using XmlBig.Core.ObjectRepresentation;

namespace XmlBig.Example
{
    public class Xml : XmlObject
    {
        public Xml(Stream content,
            XmlReaderSettings settings,
            INavigationActionFactory navigationFactory)
            : base(() =>
           {
               content.Position = 0;
               var sr = new StreamReader(content);
               return XmlReader.Create(sr, settings);
           }, navigationFactory)
        {
        }


        public IEnumerable<Foo> FooCollection
        {
            get
            {
                var action = CurrentNavigation.ToElement("xml").GoInner().GetAction();

                long fooCount = GetElementsCount(action, "Foo");
                for (long i = 1; i <= fooCount; i++)
                {
                    var bAction = _navigationFactory.CreateNew(action).ToChild("Foo", i).GetAction();
                    yield return new Foo(GetReaderDelegate, bAction, _navigationFactory);
                }
            }
        }

    }
}

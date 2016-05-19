using System;
using System.IO;
using System.Xml;
using XmlBig.Core.Factory;
using System.Linq;

namespace XmlBig.Example
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;

            using (var fs = File.OpenRead(@"LargeXml\out.xml"))
            {
                var testXml = new Xml(fs, settings, new NavigationActionFactory());
                foreach (var foo in testXml.FooCollection.Skip(10000).Take(15))
                {
                    Console.WriteLine(foo.Id);
                    Console.WriteLine(foo.Bar);

                    foreach (var innerFoo in foo.InnerFooCollection.Skip(10).Take(5))
                    {
                        Console.WriteLine(innerFoo.Name);
                    }
                }
            }

            Console.WriteLine("Finish.");
            Console.ReadKey();
        }
    }

}


using System.IO;
using System.Xml;
using XmlBig.Core.Factory;

namespace XmlBig
{

	class Program
	{
		static void Main( string[] args )
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;

			using ( var fs = File.OpenRead( @"C:\Users\Андрец\Desktop\1.xml" ) )
			{
				var test = new TestXmlObject( fs, settings, new NavigationActionFactory() );

				foreach ( var x in test.BValue )
				{
					string s = x.InnerXml;
				}

			}

		}
	}

}


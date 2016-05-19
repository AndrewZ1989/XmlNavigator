using System;
using System.IO;
using System.Xml;
using XmlBig.Core.Factory;

namespace XmlBig.Example
{

	class Program
	{
		static void Main( string[] args )
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.ConformanceLevel = ConformanceLevel.Fragment;
			settings.IgnoreWhitespace = true;

			using ( var fs = File.OpenRead( @"C:\Sample.xml" ) )
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


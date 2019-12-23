using System;
using System.Collections.Generic;
using System.Xml;
using XmlToClasses.Converters;
using XmlToClasses.Processors;
using XmlToClasses.Serialization.Text;

namespace XmlToClasses {
    public class Program {
        private static String _OutputFolder;

        private static void Main(String[] args) {
            Console.WriteLine("Xml File");
            String XmlFile = Console.ReadLine();

            Console.WriteLine("Output Folder");
            _OutputFolder = Console.ReadLine();

            if (!_OutputFolder.EndsWith("\\")) {
                _OutputFolder += "\\";
            }

            Console.WriteLine("reading");
            List<ClassMap> Classes = ReadXml(XmlFile);
            Console.WriteLine("processing");
            ClassMapProcessor Processor = new ClassMapProcessor();
            Processor.Process(Classes);

            //Write Files
            Console.WriteLine("writing");
            ClassMapSerializer Serializer = new ClassMapSerializer();

            foreach (ClassMap O in Classes) {
                Serializer.Serialize(O, _OutputFolder);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static List<ClassMap> ReadXml(String Filepath) {
            //Read Contents
            XmlDocument Document = new XmlDocument();
            Document.Load(Filepath);

            List<ClassMap> Classes = new List<ClassMap>(1000);

            XmlNodeToClassMap Converter = new XmlNodeToClassMap();

            for (Int32 I = 0; I < Document.ChildNodes.Count; I++) {
                Converter.Convert(Document.ChildNodes[I], Classes);
            }

            return Classes;
        }
    }
}

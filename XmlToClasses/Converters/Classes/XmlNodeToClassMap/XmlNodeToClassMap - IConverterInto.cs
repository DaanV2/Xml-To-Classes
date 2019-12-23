using System;
using System.Collections.Generic;
using System.Xml;
using DaanV2.Converters;

namespace XmlToClasses.Converters {
    public partial class XmlNodeToClassMap : IConverterInto<XmlNode, List<ClassMap>>{



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Process"></param>
        /// <param name="Receiver"></param>
        public void Convert(XmlNode Process, List<ClassMap> Receiver) {
            ClassMap Out = new ClassMap {
                Name = Process.Name.Replace(" ", String.Empty)
            };

            Receiver.Add(Out);

            XmlAttributeCollection Attributes = Process.Attributes;
            Int32 Length = Attributes.Count;

            for (Int32 I = 0; I < Length; I++) {
                Out.Properties.Add(new PropertyMap() {
                    Attributes = new List<String>() { $"XmlAttributeAttribute(AttributeName=\"{Attributes[I].Name}\")" },
                    Name = Attributes[I].Name.Replace(" ", String.Empty),
                    Type = TypeIdentifier.DetermineType(Attributes[I].Value)
                });
            }

            XmlNodeList InnerChilds = Process.ChildNodes;
            Length = InnerChilds.Count;
            XmlNode InnerC;

            for (Int32 I = 0; I < Length; I++) {
                InnerC = InnerChilds[I];

                //Child node becomes its own class
                if ((InnerC.Attributes != null && InnerC.Attributes.Count > 0) || (InnerC.ChildNodes != null && InnerC.ChildNodes.Count > 0)) {
                    Out.Properties.Add(new PropertyMap() {
                        Attributes = new List<String>() { $"XmlElementAttribute(ElementName =\"{InnerC.Name}\")" },
                        Name = InnerC.Name.Replace(" ", String.Empty),
                        Type = InnerC.Name.Replace(" ", String.Empty)
                    });
                    this.Convert(InnerC, Receiver);
                }
                //Just a property
                else {
                    Out.Properties.Add(new PropertyMap() {
                        Attributes = new List<String>() { $"XmlElementAttribute(ElementName=\"{InnerC.Name}\")" },
                        Name = InnerC.Name.Replace(" ", String.Empty),
                        Type = TypeIdentifier.DetermineType(InnerC.Value)
                    });
                }
            }
        }
    }
}

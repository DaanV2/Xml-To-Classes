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

            XmlAttributeCollection Attributes = Process.Attributes;
            Int32 Length = Attributes.Count;

            for (Int32 I = 0; I < Length; I++) {
                if (!Attributes[I].Name.StartsWith("#")) {
                    Out.Properties.Add(new PropertyMap() {
                        Attributes = new List<String>() { $"XmlAttributeAttribute(AttributeName=\"{Attributes[I].Name}\")" },
                        Name = Attributes[I].Name.Replace(" ", String.Empty).Replace("-", "_"),
                        Type = TypeIdentifier.DetermineType(Attributes[I].Value)
                    });
                }
            }

            XmlNodeList InnerChilds = Process.ChildNodes;
            Length = InnerChilds.Count;
            XmlNode InnerC;

            for (Int32 I = 0; I < Length; I++) {
                InnerC = InnerChilds[I];

                if (!InnerC.Name.StartsWith("#")) {
                    //Child node becomes its own class
                    if (InnerC.Attributes != null && InnerC.Attributes.Count > 0) {
                        Out.Properties.Add(new PropertyMap() {
                            Attributes = new List<String>() { $"XmlElementAttribute(ElementName =\"{InnerC.Name}\")" },
                            Name = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_"),
                            Type = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_")
                        });
                        this.Convert(InnerC, Receiver);
                    }
                    else if (InnerC.HasChildNodes) {
                        if (InnerC.ChildNodes.Count == 1) {
                            if (InnerC.Name == InnerC.FirstChild.Name || InnerC.FirstChild.NodeType == XmlNodeType.Text) {
                                Out.Properties.Add(new PropertyMap() {
                                    Attributes = new List<String>() { $"XmlElementAttribute(ElementName=\"{InnerC.Name}\")" },
                                    Name = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_"),
                                    Type = TypeIdentifier.DetermineType(InnerC.FirstChild.Value)
                                });

                                continue;
                            }
                        }

                        Out.Properties.Add(new PropertyMap() {
                            Attributes = new List<String>() { $"XmlElementAttribute(ElementName =\"{InnerC.Name}\")" },
                            Name = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_"),
                            Type = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_")
                        });
                        this.Convert(InnerC, Receiver);
                    }
                    //Just a property
                    else {
                        Out.Properties.Add(new PropertyMap() {
                            Attributes = new List<String>() { $"XmlElementAttribute(ElementName=\"{InnerC.Name}\")" },
                            Name = InnerC.Name.Replace(" ", String.Empty).Replace("-", "_"),
                            Type = TypeIdentifier.DetermineType(InnerC.Value)
                        });
                    }
                }
            }

            if (Out.Properties.Count > 0)
                Receiver.Add(Out);
        }
    }
}

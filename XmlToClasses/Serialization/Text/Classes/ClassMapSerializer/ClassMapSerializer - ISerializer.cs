using System;
using System.IO;
using System.Text;
using DaanV2.Serialization;

namespace XmlToClasses.Serialization.Text {
    public partial class ClassMapSerializer : ISerializer<ClassMap, String> {
        /// <summary></summary>
        /// <param name="O">The object to process</param>
        /// <param name="Folder">The folder to output to</param>
        public void Serialize(ClassMap O, String Folder) {
            if (!Folder.EndsWith("\\")) {
                Folder += "\\";
            }

            Folder += "Classes\\" + O.Name + "\\";
            Directory.CreateDirectory(Folder);

            this.SerializeInitialize(O, Folder);
            this.SerializeVariable(O, Folder);
            this.SerializeProperties(O, Folder);
        }

        private void SerializeInitialize(ClassMap O, String Folder) {
            String Name = O.Name;
            StringBuilder Builder = new StringBuilder(1000);

            Builder.AppendLine("using System;");
            Builder.AppendLine();
            //Namespace
            Builder.AppendLine("namespace REPLACENAMESPACE {");
            //Comment
            Builder.AppendLine($"\t///DOLATER <summary>add description for class: {Name}</summary>");
            //Attributes
            Builder.AppendLine("\t[Serializable]");
            //Header
            Builder.AppendLine($"\tpublic partial class {Name} {{");

            //Constructor
            Builder.AppendLine($"\t\t/// <summary>Creates a new instance of <see cref=\"{Name}\"/></summary>");
            Builder.AppendLine($"\t\tpublic {Name}() {{");

            //Write Properties
            for (Int32 I = 0; I < O.Properties.Count; I++) {
                Builder.AppendLine($"\t\t\tthis.{O.Properties[I].Name} = new {O.Properties[I].Type}();");
            }

            Builder.AppendLine("\t\t}");
            Builder.AppendLine("\t}");
            Builder.AppendLine("}");

            File.WriteAllText(Folder + $"{Name} - Initialize.cs", Builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="O"></param>
        /// <param name="Folder"></param>
        private void SerializeVariable(ClassMap O, String Folder) {
            String Name = O.Name;
            StringBuilder Builder = new StringBuilder(1000);

            Builder.AppendLine("using System;");
            Builder.AppendLine();
            //Namespace
            Builder.AppendLine("namespace REPLACENAMESPACE {");
            //Header
            Builder.AppendLine($"\tpublic partial class {Name} {{");

            //Write Properties
            for (Int32 I = 0; I < O.Properties.Count; I++) {
                Builder.AppendLine($"\t\t/// <summary>add description for property {O.Properties[I].Name}</summary>");
                Builder.AppendLine($"\t\tprivate {O.Properties[I].Type} _{O.Properties[I].Name};");
                Builder.AppendLine();
            }

            Builder.AppendLine("\t}");
            Builder.AppendLine("}");

            File.WriteAllText(Folder + $"{Name} - Variables.cs", Builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="O"></param>
        /// <param name="Folder"></param>
        private void SerializeProperties(ClassMap O, String Folder) {
            String Name = O.Name;
            StringBuilder Builder = new StringBuilder(1000);

            Builder.AppendLine("using System;");
            Builder.AppendLine("using System.Xml.Serialization;");
            Builder.AppendLine();
            //Namespace
            Builder.AppendLine("namespace REPLACENAMESPACE {");
            //Header
            Builder.AppendLine($"\tpublic partial class {Name} {{");

            //Write Properties
            for (Int32 I = 0; I < O.Properties.Count; I++) {
                Builder.AppendLine($"\t\t/// <summary>add description for property {O.Properties[I].Name}</summary>");
                
                for (Int32 J = 0; J < O.Properties[I].Attributes.Count; J++) {
                    Builder.AppendLine($"\t\t[{O.Properties[I].Attributes[J]}]");
                }

                Builder.AppendLine($"\t\tpublic {O.Properties[I].Type} {O.Properties[I].Name} {{");

                Builder.AppendLine($"\t\t\tget => this._{O.Properties[I].Name};");
                Builder.AppendLine($"\t\t\tset => this._{O.Properties[I].Name} = value;");

                Builder.AppendLine("\t\t}");
                Builder.AppendLine();
            }

            Builder.AppendLine("\t}");
            Builder.AppendLine("}");

            File.WriteAllText(Folder + $"{Name} - Properties.cs", Builder.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using DaanV2.Processors;

namespace XmlToClasses.Processors {
    public partial class ClassMapProcessor : IProcessor<ClassMap>, IProcessor<List<ClassMap>> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Process"></param>
        public void Process(List<ClassMap> Process) {
            for (Int32 I = 0; I < Process.Count; I++) {
                this.Process(Process[I]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Process"></param>
        public void Process(ClassMap Process) {
            List<PropertyMap> Properties = Process.Properties;
            Int32 Length = Properties.Count;
            Int32 Count;
            String Current;

            for (Int32 I = 0; I < Length; I++) {
                Count = 0;
                Current = Properties[I].Name;

                //Count Property
                for (Int32 J = 0; J < Length; J++) {
                    if (Current == Properties[J].Name) {
                        Count++;
                    }
                }

                //If more then the same property is found then it was a collection
                if (Count > 1) {
                    Properties[I].Type = $"List<{Properties[I].Type}>";

                    for (Int32 J = I + 1; J < Properties.Count; J++) {
                        if (Properties[J].Name == Current) {
                            Properties.RemoveAt(J--);
                        }
                    }

                    //Update Length 
                    Length = Properties.Count;
                }
            }
        }
    }
}


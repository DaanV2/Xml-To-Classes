using System;
using System.Collections.Generic;

namespace XmlToClasses.Processors {
    public partial class ClassMapProcessor {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Maps"></param>
        public void CheckMaps(List<ClassMap> Maps) {
            Int32 ReplaceCount = 0;

            for (Int32 I = 0; I < Maps.Count; I++) {
                for (Int32 J = I + 1; J < Maps.Count; J++) {
                    if (Maps[I].Name != Maps[J].Name) {
                        if (Equals(Maps[I], Maps[J])) {
                            //WE FOUND ONE
                            ClassMap Replacement = new ClassMap() {
                                Name = "REPLACEMENT" + ReplaceCount.ToString(),
                                Properties = Maps[I].Properties
                            };

                            ReplaceTypes(Maps, Maps[I].Name, Replacement.Name);
                            ReplaceTypes(Maps, Maps[J].Name, Replacement.Name);

                            Maps.Add(Replacement);
                            Maps.RemoveAt(J--);
                            Maps.RemoveAt(I--);
                            ReplaceCount++;
                        }
                    }
                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Maps"></param>
        /// <param name="OldType"></param>
        /// <param name="NewType"></param>
        public void ReplaceTypes(List<ClassMap> Maps, String OldType, String NewType) {
            for (Int32 I = 0; I < Maps.Count; I++) {
                ClassMap Current = Maps[I];
                for (Int32 J = 0; J < Current.Properties.Count; J++) {

                    Current.Properties[J].Type = Current.Properties[J].Type.Replace(OldType, NewType);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public static Boolean Equals(ClassMap A, ClassMap B) {

            if (A.Properties.Count != B.Properties.Count) {
                return false;
            }

            for (Int32 I = 0; I < A.Properties.Count; I++) {
                if (A.Properties[I].Name != B.Properties[I].Name || //Name
                    A.Properties[I].Type != B.Properties[I].Type || //Type
                    A.Properties[I].Attributes.Count != B.Properties[I].Attributes.Count) { //Count Properties
                    return false;
                }

                //Are properties attributes the same?
                for (Int32 K = 0; K < A.Properties[I].Attributes.Count; K++) {
                    if (A.Properties[I].Attributes[K] != B.Properties[I].Attributes[K]) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

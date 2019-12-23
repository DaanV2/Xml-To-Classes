using System;
using System.Collections.Generic;

namespace XmlToClasses.Processors {
    public partial class ClassMapProcessor {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Maps"></param>
        public void RemoveDoubles(List<ClassMap> Maps) {
            Int32 Count = Maps.Count;

            for (Int32 I = 0; I < Count; I++) {
                for (Int32 J = I + 1; J < Count; J++) {
                    if (Maps[I].Name == Maps[J].Name) {
                        Maps.RemoveAt(J--);
                        Count = Maps.Count;
                    }
                }
            }
        }
    }
}

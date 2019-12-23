using System;
using System.Collections.Generic;
using DaanV2.Processors;

namespace XmlToClasses.Processors {
    public partial class ClassMapProcessor : IProcessor<List<ClassMap>> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Process"></param>
        public void Process(List<ClassMap> Process) {
            ClassMap Current;
            this.RemoveDoubles(Process);
            Sorter sorter = new Sorter();

            Process.Sort(sorter);

            for (Int32 I = 0; I < Process.Count; I++) {
                Current = Process[I];
                Current.Properties.Sort(sorter);

                this.FixTypes(Current);
            }            
            this.CheckMaps(Process);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlToClasses {
    ///DOLATER <summary>add description for class: ClassMap</summary>
    public partial class ClassMap {
        /// <summary>Creates a new instance of <see cref="ClassMap"/></summary>
        public ClassMap() {
            this.Name = String.Empty;
            this.Properties = new List<PropertyMap>(10);
        }

        /// <summary>Creates a new instance of <see cref="ClassMap"/></summary>
        public ClassMap(String Name, List<PropertyMap> Properties) {
            this.Name = String.Empty;
            this.Properties = Properties;
        }
    }
}

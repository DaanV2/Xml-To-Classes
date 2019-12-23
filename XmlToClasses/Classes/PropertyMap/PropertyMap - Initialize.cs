using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlToClasses {
    ///DOLATER <summary>add description for class: PropertyMap</summary>
    public partial class PropertyMap {
        /// <summary>Creates a new instance of <see cref="PropertyMap"/></summary>
        public PropertyMap() {
            this.Name = String.Empty;
            this.Type= String.Empty;
        }

        /// <summary>Creates a new instance of <see cref="PropertyMap"/></summary>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        public PropertyMap(String Name, String Type) {
            this.Name = Name;
            this.Type = Type;
        }
    }
}

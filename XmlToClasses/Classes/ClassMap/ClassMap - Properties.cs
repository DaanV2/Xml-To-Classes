using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToClasses {
    public partial class ClassMap {
        /// <summary></summary>
        public String Name { get; set; }

        /// <summary></summary>
        public List<PropertyMap> Properties { get; set; }
    }
}

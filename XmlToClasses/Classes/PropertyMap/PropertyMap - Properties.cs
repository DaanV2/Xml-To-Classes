using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToClasses {
    public partial class PropertyMap {
        /// <summary></summary>
        public String Name { get; set; }

        /// <summary></summary>
        public String Type { get; set; }

        /// <summary></summary>
        public List<String> Attributes { get; set; }
    }
}

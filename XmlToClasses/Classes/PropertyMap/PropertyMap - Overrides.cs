using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToClasses {
    public partial class PropertyMap : IEquatable<PropertyMap> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Boolean Equals(Object obj) {
            return this.Equals(obj as PropertyMap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Boolean Equals([AllowNull] PropertyMap other) {
            return other != null &&
                   this.Name == other.Name &&
                   this.Type == other.Type &&
                   EqualityComparer<List<String>>.Default.Equals(this.Attributes, other.Attributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Boolean operator ==(PropertyMap left, PropertyMap right) {
            return EqualityComparer<PropertyMap>.Default.Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Boolean operator !=(PropertyMap left, PropertyMap right) {
            return !(left == right);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace XmlToClasses {
    ///DOLATER <summary>add description for class: Sorter</summary>
    public partial class Sorter : 
        IComparer<ClassMap>,
        IComparer<PropertyMap>{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Int32 Compare([AllowNull] ClassMap x, [AllowNull] ClassMap y) {
            Int32? R = x?.Name.CompareTo(y?.Name);
            return R == null ? 0 : (Int32)R;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Int32 Compare([AllowNull] PropertyMap x, [AllowNull] PropertyMap y) {
            Int32? R = x?.Name.CompareTo(y?.Name);
            return R == null ? 0 : (Int32)R;
        }
    }
}

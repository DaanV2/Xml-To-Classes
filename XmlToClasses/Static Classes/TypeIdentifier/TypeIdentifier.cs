using System;
using System.Linq;
using DaanV2;

namespace XmlToClasses {
    ///DOLATER <summary>add description for class: TypeIdentifier</summary>
    public static partial class TypeIdentifier {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static String DetermineType(String Value) {

            if (String.IsNullOrEmpty(Value))
                return "String";

            Value = Value.Trim();

            if (IsNumber(Value))
                return "Int32";

            if (IsDecimal(Value))
                return "Double";

            if (IsDate(Value))
                return "DateTime";

            return "String";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boolean IsNumber(String Value) {
            Int32 Length = Value.Length;

            for (Int32 I = 0; I < Length; I++) {
                if (!TypeIdentifier._NumberPattern.Contains(Value[I])) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boolean IsDecimal(String Value) {
            Int32 Length = Value.Length;

            for (Int32 I = 0; I < Length; I++) {
                if (!TypeIdentifier._DecimalPattern.Contains(Value[I])) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Boolean IsDate(String Value) {
            Int32 Length = Value.Length;

            for (Int32 I = 0; I < Length; I++) {
                if (!TypeIdentifier._DatePattern.Contains(Value[I])) {
                    return false;
                }
            }

            return true;
        }
    }
}

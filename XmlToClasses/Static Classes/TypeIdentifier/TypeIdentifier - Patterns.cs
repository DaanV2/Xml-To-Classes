using System;

namespace XmlToClasses {
    public static partial class TypeIdentifier {

        private static readonly Char[] _NumberPattern = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-' };

        private static readonly Char[] _DecimalPattern = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '\\', ':' };

        private static readonly Char[] _DatePattern = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ',', '.' };
    }
}

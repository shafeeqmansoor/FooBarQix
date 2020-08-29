using Interact.FooBarQix.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Interact.FooBarQix.Encoders
{
    public class DigitEncoder : DigitEncoderBase, IDigitEncoder
    {
        private readonly Dictionary<char, string> _specialDigitCodeLookup = new Dictionary<char, string>
        {
            {'0', "*"}
        };
        private string GetSpecialDigitCodeOrDefault(char digitChar, string defaultValue) =>
            _specialDigitCodeLookup.ContainsKey(digitChar) ? _specialDigitCodeLookup[digitChar] : defaultValue;

        public string GetExtendedDigitCode(long number, bool retainUnmatchedDigits)
        {
            var digitChars = number.ToString().ToCharArray();
            bool hasSpecialDigits = digitChars.Any(x => _specialDigitCodeLookup.ContainsKey(x));

            if (!hasSpecialDigits) return base.GetDigitCode(number);


            return retainUnmatchedDigits ? GetSpecialDigitCode(digitChars) : GetCombinedDigitCode(digitChars);
        }

        /// <summary>
        /// Looks up code from special-digit-code dictionary for each digit
        /// </summary>
        private string GetSpecialDigitCode(char[] digitChars)
        {
            var result = "";
            foreach (var digitChar in digitChars)
            {
                result += GetSpecialDigitCodeOrDefault(digitChar, digitChar.ToString());
            }

            return result;
        }


        /// <summary>
        /// Lookup codes from both dictionaries (special-digit-code and 
        /// base-digit-code) would be combined into one for each digit
        /// </summary>
        private string GetCombinedDigitCode(char[] digitChars)
        {
            var result = "";
            foreach (var digitChar in digitChars)
            {
                var code = base.GetDigitCodeOrDefault(digitChar, "");
                code += GetSpecialDigitCodeOrDefault(digitChar, "");

                result += code;
            }

            return result;
        }
    }
}

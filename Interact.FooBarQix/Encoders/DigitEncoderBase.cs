using System.Collections.Generic;

namespace Interact.FooBarQix.Encoders
{
    public abstract class DigitEncoderBase
    {
        protected readonly Dictionary<char, string> _digitCodeLookup = new Dictionary<char, string>
        {
            {'3', "Foo"},
            {'5', "Bar"},
            {'7', "Qix"}
        };

        protected string GetDigitCodeOrDefault(char digitChar, string defaultValue) =>
            _digitCodeLookup.ContainsKey(digitChar) ? _digitCodeLookup[digitChar] : defaultValue;

        public string GetDigitCode(long number)
        {
            var result = "";
            var digitChars = number.ToString().ToCharArray();


            foreach (var digitChar in digitChars)
            {
                result += GetDigitCodeOrDefault(digitChar, "");
            }

            return result;
        }
    }
}

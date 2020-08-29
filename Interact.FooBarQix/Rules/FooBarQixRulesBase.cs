using Interact.FooBarQix.Encoders;
using Interact.FooBarQix.Interfaces;

namespace Interact.FooBarQix.Rules
{
    public abstract class FooBarQixRulesBase: IFooBarQixRules
    {
        private readonly IDivisorEncoder _divisorEncoder;
        private readonly IDigitEncoder _digitEncoder;

        protected FooBarQixRulesBase()
        {
            _divisorEncoder = new DivisorEncoder();
            _digitEncoder = new DigitEncoder();
        }

        protected string GetDivisorCode(long number) =>
            _divisorEncoder.GetDivisorCode(number);

        protected string GetDigitCode(long number) =>
            _digitEncoder.GetDigitCode(number);

        protected string GetExtendedDigitCode(long number, bool retainUnmatchedDigits) =>
            _digitEncoder.GetExtendedDigitCode(number, retainUnmatchedDigits);

        protected long? GetIntValueOrNull(string text)
        {
            return long.TryParse(text, out var value) ? value : (long?)null;
        }

        protected abstract string ComputeCode(long number);

        public string Compute(string numberText)
        {
            var converted = GetIntValueOrNull(numberText);
            if (converted == null) return numberText;

            var number = converted.Value;
            return ComputeCode(number);
        }
    }
}

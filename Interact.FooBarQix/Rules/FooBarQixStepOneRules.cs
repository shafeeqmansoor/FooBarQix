namespace Interact.FooBarQix.Rules
{
    public class FooBarQixStepOneRules : FooBarQixRulesBase
    {
        protected override string ComputeCode(long number)
        {
            var divisorCode = GetDivisorCode(number);
            var digitCode = GetDigitCode(number);

            var output = $"{divisorCode}{digitCode}";

            return string.IsNullOrWhiteSpace(output) ? number.ToString() : output;
        }
    }
}

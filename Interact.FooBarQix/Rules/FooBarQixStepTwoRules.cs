namespace Interact.FooBarQix.Rules
{
    public class FooBarQixStepTwoRules : FooBarQixRulesBase
    {
        protected override string ComputeCode(long number)
        {
            var divisorCode = GetDivisorCode(number);
            bool retainUnmatchedDigitsInCode = string.IsNullOrWhiteSpace(divisorCode);

            var digitCode = GetExtendedDigitCode(number, retainUnmatchedDigitsInCode);

            var output = $"{divisorCode}{digitCode}";

            return string.IsNullOrWhiteSpace(output) ? number.ToString() : output;
        }
    }
}

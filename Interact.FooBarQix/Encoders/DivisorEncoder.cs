using Interact.FooBarQix.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Interact.FooBarQix.Encoders
{
    public class DivisorEncoder: IDivisorEncoder
    {
        private readonly Dictionary<int, string> _divisorCodeLookup = new Dictionary<int, string>
        {
            {3, "Foo"},
            {5, "Bar"},
            {7, "Qix"}
        };

        private bool IsNumberDivisible(long number, int divisor)
        {
            if (divisor == 0) return false; //Div by Zero handler
            return number % divisor == 0;
        }

        private IList<int> GetDivisors(long number) =>
            _divisorCodeLookup.Keys.Where(divisor => IsNumberDivisible(number, divisor)).ToList();


        public string GetDivisorCode(long number)
        {
            var result = "";
            var divisors = GetDivisors(number);

            foreach (var divisor in divisors)
            {
                result += _divisorCodeLookup[divisor];
            }
            return result;
        }
    }
}

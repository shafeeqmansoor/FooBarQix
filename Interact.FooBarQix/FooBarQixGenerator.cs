using Interact.FooBarQix.Interfaces;
using System;

namespace Interact.FooBarQix
{
    public class FooBarQixGenerator
    {
        private IFooBarQixRules _fooBarQixRules;

        public FooBarQixGenerator(IFooBarQixRules fooBarQixRules)
        {
            _fooBarQixRules = fooBarQixRules ?? throw new ArgumentNullException(nameof(fooBarQixRules));
        }

        public string Compute(string text) => _fooBarQixRules.Compute(text);
    }
}

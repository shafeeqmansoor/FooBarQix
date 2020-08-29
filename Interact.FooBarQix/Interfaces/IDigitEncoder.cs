namespace Interact.FooBarQix.Interfaces
{
    public interface IDigitEncoder
    {
        string GetDigitCode(long number);
        string GetExtendedDigitCode(long number, bool retainUnmatchedDigits);
    }
}

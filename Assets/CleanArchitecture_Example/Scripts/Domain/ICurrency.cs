namespace CleanArchitecture_Example.Scripts.Domain
{
    public interface ICurrency
    {
        string Key { get; }
        int Quantity { get; }
    }
}
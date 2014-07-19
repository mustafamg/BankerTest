namespace Banker.Domain.TDD.Infrastructure
{
    public interface ITransactionRepository
    {
        void Create(int accountId, decimal amount);
    }
}
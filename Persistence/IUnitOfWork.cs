namespace exchange_rates_backend.Persistence;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
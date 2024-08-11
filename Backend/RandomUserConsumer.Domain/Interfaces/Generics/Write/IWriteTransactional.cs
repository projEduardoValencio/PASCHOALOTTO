namespace RandomUserConsumer.Domain.Interfaces.Generics.Write;

public interface IWriteTransactional
{
    void BeginTransaction();

    void CommitTrasaction();

    void RollbackTransaction();
}
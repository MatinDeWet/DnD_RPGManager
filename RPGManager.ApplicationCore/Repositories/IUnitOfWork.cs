namespace RPGManager.ApplicationCore.Repositories
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken);
    }
}

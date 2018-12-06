namespace Sdt.Practice.Domain.Repositories
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
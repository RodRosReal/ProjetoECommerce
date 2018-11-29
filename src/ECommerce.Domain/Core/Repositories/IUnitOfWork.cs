using System.Threading.Tasks;

namespace Framework.Domain.Core
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}

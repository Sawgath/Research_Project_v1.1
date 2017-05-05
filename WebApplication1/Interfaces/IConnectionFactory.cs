using System.Data;

namespace WebApplication1.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}

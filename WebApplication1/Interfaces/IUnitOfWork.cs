using System;

namespace WebApplication1.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //new void Dispose();

        void SaveChanges();
    }
}

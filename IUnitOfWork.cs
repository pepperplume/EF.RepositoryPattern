using System;
using System.Collections.Generic;
using System.Text;

namespace EF.RepositoryPattern
{
    public interface IUnitOfWorkBase : IDisposable
    {
        int Complete();
    }
}

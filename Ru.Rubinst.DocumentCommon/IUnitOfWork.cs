using System;

namespace Ru.Rubinst.Common
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}

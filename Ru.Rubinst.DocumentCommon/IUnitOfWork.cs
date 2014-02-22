using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ru.Rubinst.DocumentCommon
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}

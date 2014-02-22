using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ru.Rubinst.DocumentModel
{
    public interface IEntityModel: IModel
    {
        int Id { get; set; }
    }
}

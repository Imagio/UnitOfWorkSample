using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Ru.Rubinst.DocumentModel
{
    public abstract class EntityModelBase: ModelBase, IEntityModel
    {
        [Key]
        public int Id { get; set; }
    }
}

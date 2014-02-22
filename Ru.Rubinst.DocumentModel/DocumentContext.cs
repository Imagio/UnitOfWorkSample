using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Ru.Rubinst.DocumentModel
{
    public class DocumentContext: DbContext
    {
        public DocumentContext()
            : this(DatabaseConnectionFactory.Instance.ConnectionString)
        {
            
        }

        public DocumentContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}

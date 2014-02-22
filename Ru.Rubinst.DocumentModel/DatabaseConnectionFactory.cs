using MySql.Data.MySqlClient;

namespace Ru.Rubinst.DocumentModel
{
    internal class DatabaseConnectionFactory
    {
        private DatabaseConnectionFactory()
        {
            var mySqlConnectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "gothic",
                Database = "doc_reg",
                CharacterSet = "utf8"
            };

            _connectionString = mySqlConnectionStringBuilder.ConnectionString;
        }

        private static class FactoryCreator
        {
            private static DatabaseConnectionFactory _instance;

            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static DatabaseConnectionFactory Instance
            {
                get
                {
                    return _instance ?? (_instance = new DatabaseConnectionFactory());
                }
            }
        }

        public static DatabaseConnectionFactory Instance
        {
            get
            {
                return FactoryCreator.Instance;
            }
        }

        private readonly string _connectionString;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}

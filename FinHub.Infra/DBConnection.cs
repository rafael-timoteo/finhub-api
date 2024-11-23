using Npgsql;

namespace FinHub.Infra
{
    public class DBConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; private set; }

        public DBConnection()
        {
            Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=finhub;Username=admin;Password=password;");
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
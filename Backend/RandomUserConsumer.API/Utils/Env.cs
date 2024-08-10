using RandomUserConsumer.Domain.Interfaces;

namespace PASCHOALOTTO_Random_User_Consumer.Utils;

public static class Env
{
    public static IDataBaseInfo  DatabaseEnvLoad(IWebHostEnvironment webAppEnvironment)
    {
        DotNetEnv.Env.Load(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                webAppEnvironment.IsDevelopment() ? ".env_develop" : ".env"
            )
        );
        
        return new DatabaseInfo(
            Environment.GetEnvironmentVariable("DB_HOST") ?? String.Empty,
            Environment.GetEnvironmentVariable("DB_PORT") ?? String.Empty,
            Environment.GetEnvironmentVariable("DB_USER") ?? String.Empty,
            Environment.GetEnvironmentVariable("DB_PASS") ?? String.Empty,
            Environment.GetEnvironmentVariable("DB_NAME") ?? String.Empty,
            Environment.GetEnvironmentVariable("DB_SCHEMA") ?? String.Empty
        );
    }

    public class DatabaseInfo : IDataBaseInfo
    {
        public string Host { get; private set; }
        public string Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Database { get; private set; }
        public string SearchPath { get; private set; }

        public DatabaseInfo(string host, string port, string username, string password, string database, string searchPath)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            Database = database;
            SearchPath = searchPath;
        }
    }
}
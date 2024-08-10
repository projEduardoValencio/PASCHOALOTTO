namespace RandomUserConsumer.Domain.Interfaces;

public interface IDataBaseInfo
{
    string Host { get; }
    string Port { get; }
    string Username { get; }
    string Password { get; }
    string Database { get; }
    string SearchPath { get; }
}
namespace RandomUserConsumer.Application.Interfaces;

public interface IApiProviderReponse<T>
{
    public T FromJson(string json);
}
namespace Lms.Client.Clients
{
    public interface IGameClient
    {
        Task<T?> GetAsync<T>(string path, string contentType = "application/json");
    }
}
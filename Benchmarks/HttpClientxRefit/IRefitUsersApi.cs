using Refit;

namespace HttpClientxRefit;
public interface IRefitUsersApi
{
    [Get("/users")]
    Task<IReadOnlyCollection<User>> GetUsers();
}

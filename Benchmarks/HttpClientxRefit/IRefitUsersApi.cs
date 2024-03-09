using Refit;

namespace HttpClientxRefit;
public interface IRefitUsersApi
{
    [Get("/users")]
    Task<IEnumerable<User>> GetUsers();
}

namespace UserService.Domain;

public interface IUserManager
{
    /// <summary>
    /// Получить список всех пользователей
    /// </summary>
    /// <returns>Список пользователей</returns>
    List<User> GetAllUsers();

    /// <summary>
    /// Получение пользователя по Id
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <returns>Данные пользователя</returns>
    User? GetUserById(long id);


    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="user">Данные пользователя</param>
    /// <returns></returns>
    User CreateUser(User user);

    /// <summary>
    /// Обновление данных пользователя
    /// </summary>
    /// <param name="user">Данные пользователя</param>
    /// <returns></returns>
    User? UpdateUser(User user);

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    User? DeleteUser(long id);


}
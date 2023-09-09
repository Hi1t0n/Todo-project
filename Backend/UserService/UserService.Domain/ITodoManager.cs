namespace UserService.Domain;

public interface ITodoManager
{


    /// <summary>
    /// Добавление новой задачи
    /// </summary>
    /// <param name="Todo"></param>
    /// <returns></returns>
    Todo AddTodo(Todo Todo); 

    /// <summary>
    /// Получение всех задач определенного пользователя
    /// </summary>
    /// <param name="Login"></param>
    /// <returns></returns>
    List<Todo> GetAllbyUserLogin(string Login);

    /// <summary>
    /// Обновление информации о задаче
    /// </summary>
    /// <param name="Todo"></param>
    /// <returns>обновленные данные задачи</returns>
    Todo? UpdateTodo(Todo Todo);

    /// <summary>
    /// Получение более подробной информации о задаче по Id
    /// </summary>
    /// <param name="id">Идентификатор задачи</param>
    /// <returns>Информация о задаче</returns>
    Todo? GetTodoById(long id);

    /// <summary>
    /// Удаление задачи
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Todo? DeleteTodo(long id);
}
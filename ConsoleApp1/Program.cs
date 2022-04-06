using ConsoleApp1;
using ConsoleApp1.Models;

Context db = new Context();


User user0 = new User
{
    FirstName = "FirstName1",
    SecondName = "SecondName1",
    LastName = "LastName1",
    Login = "login1",
    Password = "password1"
};
User user1 = new User
{
    FirstName = "FirstName2",
    SecondName = "SecondName2",
    LastName = "LastName2",
    Login = "login2",
    Password = "password2"
};
User user2 = new User
{
    FirstName = "FirstName3",
    SecondName = "SecondName3",
    LastName = "LastName3",
    Login = "login3",
    Password = "password3"
};
User user3 = new User
{
    FirstName = "FirstName4",
    SecondName = "SecondName4",
    LastName = "LastName4",
    Login = "login4",
    Password = "password4"
};

TaskX task0 = new TaskX
{
    Title = "Task#1",
    Description = "Easy Level",
    Date = new DateTime(2022, 10, 01),
    UsersSetId = 1,
    //UsersGetId = 2,
    StatusId = 1,
    Answer = ""
};
TaskX task1 = new TaskX
{
    Title = "Task#2",
    Description = "Easy Level",
    Date = new DateTime(2022, 11, 09),
    UsersSetId = 2,
    //UsersGetId = 1,
    StatusId = 3,
    Answer = ""
};
TaskX task2 = new TaskX
{
    Title = "Task#3",
    Description = "Hard Level",
    Date = new DateTime(2022, 06, 04),
    UsersSetId = 3,
    //UsersGetId = 2,
    StatusId = 2,
    Answer = ""
};
TaskX task3 = new TaskX
{
    Title = "Task#4",
    Description = "Medium Level",
    Date = new DateTime(2022, 12, 20),
    UsersSetId= 2,
    //UsersGetId = 3,
    StatusId = 2,
    Answer = ""
};
//db.Statuses.Add(new Status() { Title = "Не готово" });
//db.Statuses.Add(new Status() { Title = "Выполняется" });
//db.Statuses.Add(new Status() { Title = "Готово" });
//db.SaveChanges();
//db.Users.Add(user0);
//db.SaveChanges();
//db.Users.Add(user1);
//db.SaveChanges();
//db.Users.Add(user2);
//db.SaveChanges();
//db.Users.Add(user3);
//db.SaveChanges();
//db.TaskXes.Add(task0);
//db.SaveChanges();
//db.TaskXes.Add(task1);
//db.SaveChanges();
//db.TaskXes.Add(task2);
//db.SaveChanges();
//db.TaskXes.Add(task3);
//db.SaveChanges();
string a = "";
List<User> users = db.Users.ToList();
List<TaskX> tasks = db.TaskXes.ToList();
int s = 1;
//void CheckProfile(User Check)
//{
//    Console.WriteLine("Ваши данные");
//    Console.WriteLine($"Ваше имя {Check.FirstName}");
//    Console.WriteLine($"Ваша фамилия {Check.SecondName}");
//    Console.WriteLine($"Ваше отчество {Check.LastName}");
//    Console.WriteLine($"Ваш логин {Check.Login}");
//    int TaskCountGet = tasks.Count(x => x.UserGet == Check.Id);
//    int TaskCountSet = tasks.Count(x => x.UserSet == Check.Id);
//    Console.WriteLine($"Количество решеных задач {TaskCountGet}");
//    Console.WriteLine($"Количество заданных задач {TaskCountSet}");
//}
void ViewUsers(List<User> users)
{
    foreach (var item in users)
    {
        Console.WriteLine($"Пользователь {item.Login}");
    }
}

void ViewTasks(List<TaskX> tasks)
{
    foreach (var item in tasks)
    {
        if (item.StatusId == 1 || item.StatusId == 2)
        {
            Console.WriteLine($"Название - {item.Title}");
            Console.WriteLine($"Описание - {item.Description}");
            Console.WriteLine($"Статус - {item.StatusId}");
        }
    }
}
ViewTasks(tasks);
//List<TaskX> CheckAvailableTasks()
//{
//    List<TaskX> AvailableTasks = new List<TaskX>();
//    foreach (var item in tasks)
//    {
//        if (item.Status == "Не готово")
//        {
//            Console.WriteLine($"Номер - {item.Id}");
//            Console.WriteLine($"Название - {item.Title}");
//            Console.WriteLine($"Описание - {item.Description}");
//            Console.WriteLine($"Дата - {item.Date}");
//            Console.WriteLine($"Пользователь - {users.Find(x => x.Id == item.Id).Login}");
//            AvailableTasks.Add(item);
//        }
//    }
//    Console.WriteLine($"Доступно {AvailableTasks.Count} задач");
//    return AvailableTasks;
//}
//void ViewAvailableTasks(List<TaskX> tasks, List<User> users, User Check)
//{
//    List<TaskX> AvailableTasks = CheckAvailableTasks();
//    Console.Write("Выберите одну из доступных задач: ");
//    int ChoiceAvailableTask = Convert.ToInt32(Console.ReadLine());
//    if (ChoiceAvailableTask > AvailableTasks.Count)
//    {
//        Console.WriteLine("Неверный ввод");
//    }
//    else
//    {
//        Console.WriteLine($"Вы выбрали задачу {AvailableTasks[ChoiceAvailableTask].Title}");
//        Console.WriteLine($"Заданную пользоватлем с логином - {AvailableTasks[ChoiceAvailableTask].UserSet}");
//        Console.WriteLine("Откликнитетесь на задачу - ? 1 - да Other - нет");
//        int TaskChoise = Convert.ToInt32(Console.ReadLine());
//        if (TaskChoise == 1)
//        {
//            Console.WriteLine("Замечательно");
//            AvailableTasks[ChoiceAvailableTask].UserSet = Check.Id;
//            Console.WriteLine("Теперь вы ответсвтвенны за решение данной задачи");
//            AvailableTasks[ChoiceAvailableTask].Status = "Выполняется";
//            Console.WriteLine("----------->Введите ответ на задачу<-----------");
//            string UserSetAnswer = Console.ReadLine();
//            AvailableTasks[ChoiceAvailableTask].Answer = UserSetAnswer;
//        }
//        else
//        {
//            Console.WriteLine("За отклонение задачи падает карма");
//        }
//    }

//}
//void GetRegistre(string Login)
//{
//    Console.WriteLine("Замечательно!");
//    Console.WriteLine($"Ваш логин: {Login}");
//    while (users.Exists(x => x.Login == Login) == true)
//    {
//        Console.WriteLine("Такой логин уже существует");
//        Console.Write("Попробуйте что-нибудь другое: ");
//        Login = Console.ReadLine();
//    }
//    Console.Write("Теперь придумайте себе пароль: ");
//    string NewPass = Console.ReadLine();
//    Console.Write("Введите своё имя: ");
//    string NewFirstName = Console.ReadLine();
//    Console.Write("Введите свою фамилию: ");
//    string NewSecondName = Console.ReadLine();
//    Console.Write("Введите своё отчество: ");
//    string NewLastName = Console.ReadLine();
//    int NewId = users.Count + 1;
//    User NewUser = new User(NewId, NewSecondName, NewFirstName, NewLastName, Login, NewPass);
//    users.Add(NewUser);
//    Console.WriteLine();
//}
//void ChangeStatus(User Check, List<TaskX> tasks)
//{
//    Console.WriteLine("Ваши задачи");
//    foreach (var item in tasks.Where(x => x.UserGet == Check.Id).ToList())
//    {
//        Console.WriteLine($"Номер - {item.Id}");
//        Console.WriteLine($"Название - {item.Title}");
//        Console.WriteLine($"Описание - {item.Description}");
//    }
//    Console.WriteLine("Выберите ту, где хотите изменить статус");
//    int ChoiceGetTask = Convert.ToInt32(Console.ReadLine());
//    if (ChoiceGetTask > tasks.Where(x => x.UserGet == Check.Id).Count())
//    {
//        Console.WriteLine("Неверный ввод");
//    }
//    else
//    {
//        Console.WriteLine($"Вы выбрали задачу {tasks[ChoiceGetTask].Title}");
//        Console.WriteLine($"Откликнулся на задачу {tasks[ChoiceGetTask].UserSet}");
//        Console.WriteLine($"Ответ {tasks[ChoiceGetTask].Answer}");
//        Console.WriteLine("Подтверждаете изменение статуса задачи: 1 - да Other - нет");
//        int GetTaskChangeStatus = Convert.ToInt32(Console.ReadLine());
//        if (GetTaskChangeStatus == 1)
//        {
//            tasks[ChoiceGetTask].Status = "Готово";
//            Console.WriteLine("Ответ принят");
//        }
//        else
//        {
//            Console.WriteLine("Решение отклонено");
//        }

//    }
//}
//void Filter(DateOnly UserStart, DateOnly UserEnd)
//{
//    if (UserStart > UserEnd)
//    {
//        Console.WriteLine("Неверный ввод");
//    }
//    else
//    {
//        List<TaskX> DateTasks = tasks.Where(x => x.Date < UserEnd && x.Date > UserStart).ToList();
//        if (DateTasks.Count() == 0)
//        {
//            Console.WriteLine($"Список задач за промежуток {UserStart}-{UserEnd} пуст");
//        }
//        foreach (var item in DateTasks)
//        {
//            Console.WriteLine($"Название - {item.Title}");
//            Console.WriteLine($"Автор - {item.UserGet}");
//            Console.WriteLine($"Дата - {item.Date}");
//            Console.WriteLine($"Ответ - {item.Answer}");
//        }
//    }
//}
//void MainF(User Check, List<TaskX> tasks, List<User> users)
//{
//    while (true)
//    {
//        Console.WriteLine("Вход успешно выполнен");
//        Console.Clear();
//        Console.WriteLine("Что выбираем? ");
//        Console.WriteLine("1 - Посмотреть свой профиль");
//        Console.WriteLine("2 - Посмотреть список пользователей");
//        Console.WriteLine("3 - Посмотреть список доступных задач");
//        Console.WriteLine("4 - Откликнуться на задачу");
//        Console.WriteLine("5 - Посмотреть историю задач");
//        Console.WriteLine("6 - Изменить статус своей задач");
//        Console.WriteLine("7 - Фильтровать задачи по дате");
//        Console.WriteLine("8 - Искать задачи");
//        int Choise = Convert.ToInt32(Console.ReadLine());
//        switch (Choise)
//        {
//            case 1:
//                CheckProfile(Check);
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 2:
//                ViewUsers(users);
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 3:
//                ViewTasks(tasks);
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 4:
//                Console.WriteLine("Доступные задачи: ");
//                ViewAvailableTasks(tasks, users, Check);
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 5:
//                int TaskCountGet = tasks.Count(x => x.UserGet == Check.Id);
//                Console.WriteLine($"Количество решеных задач {TaskCountGet}");
//                Console.WriteLine("Ответы на них: ");
//                List<TaskX> ViewAnsweredTasks = tasks.Where(x => x.UserGet == Check.Id).ToList();
//                foreach (var item in ViewAnsweredTasks)
//                {
//                    Console.WriteLine($"Название - {item.Title}");
//                    Console.WriteLine($"Автор - {item.UserGet}");
//                    Console.WriteLine($"Дата - {item.Date}");
//                    Console.WriteLine($"Ответ - {item.Answer}");
//                    Console.WriteLine($"Статус - {item.Status}");
//                }
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 6:
//                ChangeStatus(Check, tasks);
//                break;
//            case 7:
//                Console.WriteLine("Введите начало поиска: ");
//                Console.Write("Год - ");
//                int year = Convert.ToInt32(Console.ReadLine());
//                Console.Write("Месяц - ");
//                int month = Convert.ToInt32(Console.ReadLine());
//                Console.Write("День - ");
//                int day = Convert.ToInt32(Console.ReadLine());
//                DateOnly UserStart = new DateOnly(year, month, day);
//                Console.WriteLine("Введите конец поиска: ");
//                Console.Write("Год - ");
//                year = Convert.ToInt32(Console.ReadLine());
//                Console.Write("Месяц - ");
//                month = Convert.ToInt32(Console.ReadLine());
//                Console.Write("День - ");
//                day = Convert.ToInt32(Console.ReadLine());
//                DateOnly UserEnd = new DateOnly(year, month, day);
//                Filter(UserStart, UserEnd);
//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//            case 8:
//                Console.Write("Введите логин автора задачи для поиска: ");
//                string UserLoginGet = Console.ReadLine();
//                try
//                {
//                    int UserLoginGetId = users.First(x => x.Login == UserLoginGet).Id;
//                    List<TaskX> UserLoginFind = tasks.Where(x => x.UserGet == UserLoginGetId).ToList();
//                    foreach (var item in UserLoginFind)
//                    {
//                        Console.WriteLine($"Название - {item.Title}");
//                        Console.WriteLine($"Описание - {item.Description}");
//                        Console.WriteLine($"Дата - {item.Date}");
//                    }
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("Такокого пользователя нет");

//                }

//                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
//                a = Console.ReadLine();
//                break;
//        }
//    }
//}

//Console.WriteLine("Добро пожаловать в систему 'Вопрос-ответ'!");
//Console.Write("Введите свой логин для входа в систему: ");
//string Login = Console.ReadLine();
//if (users.Exists(x => x.Login == Login) == true)
//{
//    Console.Write("Введите пароль: ");
//    string Password = Console.ReadLine();
//    var Check = users.Find(x => x.Login == Login);
//    //while (Check.CheckPass(Password) != true)
//    //{
//    //    Console.Write("Неверный пароль! Попробуйте снова: ");
//    //    Password = Console.ReadLine();
//    //}
//    //if (Check.CheckPass(Password) == true)
//    //{
//    //    MainF(Check, tasks, users);
//    //}

//}
//else
//{
//    Console.WriteLine("Увы, такого пользователя не существует");
//    Console.WriteLine("Хотите зарегистрироваться? 1 - да other - нет");
//    int IsRegistr = Convert.ToInt32(Console.ReadLine());
//    if (IsRegistr == 1)
//    {
//        GetRegistre(Login);
//        var Check = users.Find(x => x.Login == Login);
//        MainF(Check, tasks, users);
//    }
//    else
//    {
//        Console.WriteLine("Ладно(");
//    }
//}


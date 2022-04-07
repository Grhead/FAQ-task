using ConsoleApp1;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

var db = new Context();


var user0 = new User
{
    FirstName = "FirstName1",
    SecondName = "SecondName1",
    LastName = "LastName1",
    Login = "login1",
    Password = "password1"
};
var user1 = new User
{
    FirstName = "FirstName2",
    SecondName = "SecondName2",
    LastName = "LastName2",
    Login = "login2",
    Password = "password2"
};
var user2 = new User
{
    FirstName = "FirstName3",
    SecondName = "SecondName3",
    LastName = "LastName3",
    Login = "login3",
    Password = "password3"
};
var user3 = new User
{
    FirstName = "FirstName4",
    SecondName = "SecondName4",
    LastName = "LastName4",
    Login = "login4",
    Password = "password4"
};

var task0 = new TaskX
{
    Title = "Task#1",
    Description = "Easy Level",
    Date = new DateTime(2022, 10, 01),
    UsersSetId = 1,
    UsersGetId = 2,
    StatusId = 1,
    Answer = ""
};
var task1 = new TaskX
{
    Title = "Task#2",
    Description = "Easy Level",
    Date = new DateTime(2022, 11, 09),
    UsersSetId = 2,
    UsersGetId = 1,
    StatusId = 3,
    Answer = ""
};
var task2 = new TaskX
{
    Title = "Task#3",
    Description = "Hard Level",
    Date = new DateTime(2022, 06, 04),
    UsersSetId = 3,
    UsersGetId = 2,
    StatusId = 2,
    Answer = ""
};
var task3 = new TaskX
{
    Title = "Task#4",
    Description = "Medium Level",
    Date = new DateTime(2022, 12, 20),
    UsersSetId = 2,
    UsersGetId = 3,
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
var a = "";
var users = db.Users.ToList();
var tasks = new List<TaskX>(db.TaskXes.Include(x => x.Status)).ToList();

void CheckProfile(User Check)
{
    Console.WriteLine("Ваши данные");
    Console.WriteLine($"Ваше имя {Check.FirstName}");
    Console.WriteLine($"Ваша фамилия {Check.SecondName}");
    Console.WriteLine($"Ваше отчество {Check.LastName}");
    Console.WriteLine($"Ваш логин {Check.Login}");
    var TaskCountGet = tasks.Count(x => x.UsersGetId == Check.Id);
    var TaskCountSet = tasks.Count(x => x.UsersSetId == Check.Id);
    Console.WriteLine($"Количество решеных задач {TaskCountGet}");
    Console.WriteLine($"Количество заданных задач {TaskCountSet}");
}

void ViewUsers()
{
    var users = db.Users.ToList();
    foreach (var item in users) Console.WriteLine($"Пользователь {item.Login}");
}

void ViewTasks(List<TaskX> tasks)
{
    foreach (var item in tasks)
    {
        if (item.StatusId == 1 || item.StatusId == 2)
        {
            Console.WriteLine($"Название - {item.Title}");
            Console.WriteLine($"Описание - {item.Description}");
            Console.WriteLine($"Статус - {item.Status.Title}");
            Console.WriteLine($"Пользователь - {db.Users.FirstOrDefault(x => x.Id == item.UsersSetId).Login}");
        }
    }  
}

List<TaskX> CheckAvailableTasks()
{
    var AvailableTasks = new List<TaskX>();
    foreach (var item in tasks)
    {
        if (item.StatusId == 1)
        {
            AvailableTasks.Add(item);
            Console.WriteLine($"Номер - {AvailableTasks.Count - 1}");
            Console.WriteLine($"Название - {item.Title}");
            Console.WriteLine($"Описание - {item.Description}");
            Console.WriteLine($"Дата - {item.Date}");
            Console.WriteLine($"Пользователь - {users.Find(x => x.Id == item.Id).Login}");
        }
    }
    Console.WriteLine($"Доступно {AvailableTasks.Count} задач");
    return AvailableTasks;
}

void ViewAvailableTasks(List<TaskX> tasks, User Check)
{
    var users = db.Users.ToList();
    var AvailableTasks = CheckAvailableTasks();
    Console.Write("Выберите одну из доступных задач: ");
    if (AvailableTasks.Count == 0)
    {
        Console.WriteLine("Доступных задач пока нет");
    }
    else
    {
        var ChoiceAvailableTask = Convert.ToInt32(Console.ReadLine());
        if (ChoiceAvailableTask > AvailableTasks.Count || AvailableTasks.Count == 0)
        {
            Console.WriteLine("Неверный ввод");
        }
        else
        {
            Console.WriteLine($"Вы выбрали задачу {AvailableTasks[ChoiceAvailableTask].Title}");
            Console.WriteLine($"Заданную пользователем с логином - {AvailableTasks[ChoiceAvailableTask].UsersSetId}");
            Console.WriteLine("Откликнитетесь на задачу - ? 1 - да Other - нет");
            var TaskChoise = Convert.ToInt32(Console.ReadLine());
            if (TaskChoise == 1)
            {
                Console.WriteLine("Замечательно");
                Console.WriteLine("Теперь вы ответсвтвенны за решение данной задачи");
                Console.WriteLine("----------->Введите ответ на задачу<-----------");
                var UserSetAnswer = Console.ReadLine();
                var ToPush = db.TaskXes.FirstOrDefault(x => x.Title == AvailableTasks[ChoiceAvailableTask].Title);
                ToPush.UsersGetId = Check.Id;
                ToPush.Answer = UserSetAnswer;
                ToPush.StatusId = 2;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("За отклонение задачи падает карма");
            }
        }
    }

}

User GetRegistre(string Login)
{
    Console.WriteLine("Замечательно!");
    Console.WriteLine($"Ваш логин: {Login}");
    while (users.Exists(x => x.Login == Login))
    {
        Console.WriteLine("Такой логин уже существует");
        Console.Write("Попробуйте что-нибудь другое: ");
        Login = Console.ReadLine();
    }

    Console.Write("Теперь придумайте себе пароль: ");
    var NewPass = Console.ReadLine();
    Console.Write("Введите своё имя: ");
    var NewFirstName = Console.ReadLine();
    Console.Write("Введите свою фамилию: ");
    var NewSecondName = Console.ReadLine();
    Console.Write("Введите своё отчество: ");
    var NewLastName = Console.ReadLine();
    var NewId = users.Count + 1;
    var NewUser = new User
    {
        FirstName = NewFirstName,
        SecondName = NewSecondName,
        LastName = NewLastName,
        Login = Login,
        Password = NewPass
    };
    var Check = NewUser;
    db.Users.Add(NewUser);
    db.SaveChanges();
    Console.WriteLine();
    return Check;
}

void ChangeStatus(User Check, List<TaskX> tasks)
{
    Console.WriteLine("Ваши задачи");
    foreach (var item in tasks.Where(x => x.UsersSetId == Check.Id).ToList())
    {
        Console.WriteLine($"Номер - {item.Id}");
        Console.WriteLine($"Название - {item.Title}");
        Console.WriteLine($"Описание - {item.Description}");
    }

    Console.WriteLine("Выберите ту, где хотите изменить статус");
    var ChoiceGetTask = Convert.ToInt32(Console.ReadLine());
    if (ChoiceGetTask > tasks.Where(x => x.UsersGetId == Check.Id).Count())
    {
        Console.WriteLine("Неверный ввод");
    }
    else
    {
        Console.WriteLine($"Вы выбрали задачу {tasks[ChoiceGetTask].Title}");
        Console.WriteLine($"Откликнулся на задачу {tasks[ChoiceGetTask].UsersGetId}");
        Console.WriteLine($"Ответ {tasks[ChoiceGetTask].Answer}");
        Console.WriteLine("Подтверждаете изменение статуса задачи: 1 - да Other - нет");
        var GetTaskChangeStatus = Convert.ToInt32(Console.ReadLine());
        if (GetTaskChangeStatus == 1)
        {
            var ToPush = db.TaskXes.FirstOrDefault(x => x.Title == tasks[ChoiceGetTask].Title);
            ToPush.StatusId = 3;
            Console.WriteLine("Ответ принят");
            db.SaveChanges();
        }
        else
        {
            Console.WriteLine("Решение отклонено");
        }
    }
}

void Filter(DateTime UserStart, DateTime UserEnd)
{
    if (UserStart > UserEnd)
    {
        Console.WriteLine("Неверный ввод");
    }
    else
    {
        var DateTasks = tasks.Where(x => x.Date < UserEnd && x.Date > UserStart).ToList();
        if (DateTasks.Count() == 0) Console.WriteLine($"Список задач за промежуток {UserStart}-{UserEnd} пуст");
        foreach (var item in DateTasks)
        {
            Console.WriteLine($"Название - {item.Title}");
            Console.WriteLine($"Автор - {item.UsersGetId}");
            Console.WriteLine($"Дата - {item.Date}");
            Console.WriteLine($"Ответ - {item.Answer}");
        }
    }
}

void MainF(User Check, List<TaskX> tasks, List<User> users)
{
    while (true)
    {
        Console.WriteLine("Вход успешно выполнен");
        Console.Clear();
        Console.WriteLine("Что выбираем? ");
        Console.WriteLine("1 - Посмотреть свой профиль");
        Console.WriteLine("2 - Посмотреть список пользователей");
        Console.WriteLine("3 - Посмотреть список доступных задач");
        Console.WriteLine("4 - Откликнуться на задачу");
        Console.WriteLine("5 - Посмотреть историю задач");
        Console.WriteLine("6 - Изменить статус своей задач");
        Console.WriteLine("7 - Фильтровать задачи по дате");
        Console.WriteLine("8 - Искать задачи");
        var Choise = Convert.ToInt32(Console.ReadLine());
        switch (Choise)
        {
            case 1:
                CheckProfile(Check);
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 2:
                ViewUsers();
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 3:
                ViewTasks(tasks);
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 4:
                Console.WriteLine("Доступные задачи: ");
                ViewAvailableTasks(tasks, Check);
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 5:
                var TaskCountGet = tasks.Count(x => x.UsersGetId == Check.Id);
                Console.WriteLine($"Количество решеных задач {TaskCountGet}");
                Console.WriteLine("Ответы на них: ");
                var ViewAnsweredTasks = tasks.Where(x => x.UsersGetId == Check.Id).ToList();
                foreach (var item in ViewAnsweredTasks)
                {
                    Console.WriteLine($"Название - {item.Title}");
                    Console.WriteLine($"Автор - {item.UsersGetId}");
                    Console.WriteLine($"Дата - {item.Date}");
                    Console.WriteLine($"Ответ - {item.Answer}");
                    Console.WriteLine($"Статус - {item.Status}");
                }

                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 6:
                ChangeStatus(Check, tasks);
                break;
            case 7:
                Console.WriteLine("Введите начало поиска: ");
                Console.Write("Год - ");
                var year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц - ");
                var month = Convert.ToInt32(Console.ReadLine());
                Console.Write("День - ");
                var day = Convert.ToInt32(Console.ReadLine());
                var UserStart = new DateTime(year, month, day);
                Console.WriteLine("Введите конец поиска: ");
                Console.Write("Год - ");
                year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц - ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("День - ");
                day = Convert.ToInt32(Console.ReadLine());
                var UserEnd = new DateTime(year, month, day);
                Filter(UserStart, UserEnd);
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
            case 8:
                Console.Write("Введите логин автора задачи для поиска: ");
                var UserLoginGet = Console.ReadLine();
                try
                {
                    var UserLoginGetId = users.First(x => x.Login == UserLoginGet).Id;
                    var UserLoginFind = tasks.Where(x => x.UsersGetId == UserLoginGetId).ToList();
                    foreach (var item in UserLoginFind)
                    {
                        Console.WriteLine($"Название - {item.Title}");
                        Console.WriteLine($"Описание - {item.Description}");
                        Console.WriteLine($"Дата - {item.Date}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Такокого пользователя нет");
                }
                Console.Write("Нажмите любую кнопку, чтобы вернуться на главный экран: ");
                a = Console.ReadLine();
                break;
        }
    }
}

Console.WriteLine("Добро пожаловать в систему 'Вопрос-ответ'!");
Console.Write("Введите свой логин для входа в систему: ");
var Login = Console.ReadLine();
Console.Write("Введите пароль: ");
var Password = Console.ReadLine();
var Check = db.Users.FirstOrDefault(q => q.Login == Login && q.Password == Password);
if (Check == null)
{
    Console.WriteLine("Увы, такого пользователя не существует");
    Console.WriteLine("Хотите зарегистрироваться? 1 - да other - нет");
    var IsRegistr = Convert.ToInt32(Console.ReadLine());
    if (IsRegistr == 1)
    {
        Check = GetRegistre(Login);
        MainF(Check, tasks, users);
    }
    else
    {
        Console.WriteLine("Ладно(");
    }
}
else if (Check != null)
{
    MainF(Check, tasks, users);
}
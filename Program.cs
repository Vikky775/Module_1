using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_new
{
    class Program

    { //создаем массивы с данными 
        static string[] namesList = new string[1];
        static string[] credrntialsList = new string[1];
        static string[] bankAccounts = new string[1];
        static int[] summMoney = new int[1];
        static string[] usersStatus = new string[1];

        static void Main(string[] args)
        {
            Login(); //выполняем вход в систему
        }
        static void Login()
        {
            Console.Clear();
            Console.WriteLine("Приветствуем Вас!" + "\n" +
                "Нажмите 1, если Вы хотите зайти как клиент банка" + "\n" +
                "0 - если Вы хотите зайти как администратор. ");
            string role = Console.ReadLine();
            switch (role)
            {
                case "1":
                    { LoginUser(); }
                    break;
                case "0":
                    { LoginAdmin(); }
                    break;
            }
        }

        static void LoginAdmin() //пароль админа 1111
        {
            Console.Clear();
            Console.WriteLine("Приветствуем, администратор!" + "\n" + " Введите пароль: ");
            string adminPass = Console.ReadLine();
            if (adminPass == "1111")
            {
                Console.Clear();
                Console.WriteLine("Поздравляем, Вы зашли на страницу администратора!" + "\n");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Вы ввели неверный пароль, попробуйте еще раз.");
                LoginAdmin();
            }
        }
        static void AdminMenu()//меню юзера
        {
            Console.Clear();
            Console.WriteLine("Выберите действие, которое хотите совершить:" + "\n" +
     "1 - Просмотреть список счетов" + "\n" +
     "2 - Заблокировать пользователя от входа в системы" + "\n" +
     "3 - Разблокировать пользователя" + "\n" +
     "4 - Добавить счет для нового пользователя" + "\n" +
     "5 - Удалить счет пользователя" + "\n" +
     "0 - Выйти из учетной записи");
            string adminDo = Console.ReadLine();
            switch (adminDo)
            {
                case "1":
                    { AllUsers(); }//список юзеров
                    break;
                case "2":
                    { Block(); }//блок.юзеров
                    break;
                case "3":
                    { Unblock(); }//разблок.
                    break;
                case "4":
                    { CreateUser(); }//создание нового юзера
                    break;
                case "5":
                    { DeleteUser(); }//удаление юзера
                    break;
                case "0":
                    { Login(); }//выход в меню авторизации
                    break;
            }
        }

        public static void Unblock()
        {
            Console.Clear();
            Console.WriteLine("Заблокированые пользователи: ");
            for (int i = 0; i < namesList.Length; i++)
            {
                if (usersStatus[i] == "BLOCKED!")
                { Console.WriteLine(namesList[i]); }
            }
            Console.WriteLine("Введите фамилию и имя пользователя, которого хотите разблокировать.");
            string unblockedUser = Console.ReadLine();
            int userIndex = -1;
            for (int i = 0; i < namesList.Length; i++)
            {
                if (unblockedUser == namesList[i] && usersStatus[i] == "BLOCKED!")
                {
                    userIndex = i;
                    break;
                }
            }
            usersStatus[userIndex] = "not blocked";
            Console.WriteLine("Пользователь разблокирован." + "\n" +
                "Для перехода в главное меню нажмите 1" + "\n" +
                "Для того, чтобы выйти из учетной записи нажмите 0.");
            string input = Console.ReadLine();
            if (input == "0")
            { Login(); }
            else
            { AdminMenu(); }

        }

        public static void AllUsers()
        {
            Console.WriteLine("ФИО" + " " + "Счет" + " " + "Остаток средств" + " " + "Статус" + " ");
            for (int i = 0; i < namesList.Length; i++)
            {
                Console.WriteLine(namesList[i] + "      " + bankAccounts[i] + " " + summMoney[i] + "          " + usersStatus[i]);
            }
            Console.WriteLine(
                "Для перехода в главное меню нажмите 1" + "\n" +
                "Для того, чтобы выйти из учетной записи нажмите 0.");
            string input = Console.ReadLine();
            if (input == "0")
            { Login(); }
            else
            { AdminMenu(); }
        }

        public static void Block()
        {
            Console.Clear();
            Console.WriteLine("Cуществующие пользователи: ");
            for (int i = 0; i < namesList.Length; i++)
            {
                Console.WriteLine(namesList[i]);
            }
            Console.WriteLine("Введите фамилию и имя пользователя, которого хотите заблокировать.");
            string blockedUser = Console.ReadLine();
            int userIndex = -1;
            for (int i = 0; i < namesList.Length; i++)
            {

                if (blockedUser == namesList[i])
                {
                    userIndex = i;
                    break;
                }
            }
            usersStatus[userIndex] = "BLOCKED!";
            Console.WriteLine("Пользователь заблокирован." + "\n" +
                "Для перехода в главное меню нажмите 1" + "\n" +
                "Для того, чтобы выйти из учетной записи нажмите 0.");
            string input = Console.ReadLine();
            if (input == "0")
            { Login(); }
            else
            { AdminMenu(); }

        }

        public static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Cуществующие пользователи: ");
            for (int i = 0; i < namesList.Length; i++)
            {
                Console.WriteLine(namesList[i]);
            }
            Console.WriteLine("Введите фамилию и имя пользователя, которого хотите удалить из базы.");
            string userToBeDeleted = Console.ReadLine();
            int userIndex = -1;
            for (int i = 0; i < namesList.Length; i++)
            {
                if (userToBeDeleted == namesList[i])
                {
                    userIndex = i;
                }
            }
            namesList[userIndex] = "deleted";
            credrntialsList[userIndex] = "deleted";
            bankAccounts[userIndex] = "deleted";
            summMoney[userIndex] = -1;
            usersStatus[userIndex] = "deleted";
            Console.WriteLine("Пользователь удален." +
                "Для перехода в главное меню нажмите 1" +
                "Для того, чтобы выйти из учетной записи нажмите 0.");
            string input = Console.ReadLine();
            if (input == "0")
            { Login(); }
            else
            { AdminMenu(); }
        }

        public static void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Для создания нового пользователя укажите фамилию и имя пользователя.");
            string name = Console.ReadLine();
            Array.Resize(ref namesList, namesList.Length + 1);
            namesList[namesList.Length-1] = name;

            Console.WriteLine("Укажите логин и пароль в формате: Login password");
            string logPass = Console.ReadLine();
            Array.Resize(ref credrntialsList, credrntialsList.Length + 1);
            credrntialsList[credrntialsList.Length-1] = logPass;

            Console.WriteLine("Введите номер счета пользователя: ");
            string account = Console.ReadLine();
            Array.Resize(ref bankAccounts, bankAccounts.Length + 1);
            bankAccounts[bankAccounts.Length-1] = account;

            Console.WriteLine(" Введите сумму, которая находится на счету: ");
            string moneyStr = Console.ReadLine();
            int money = int.Parse(moneyStr);
            Array.Resize(ref summMoney, summMoney.Length + 1);
            summMoney[summMoney.Length-1] = money;

            string status = "not blocked";
            Array.Resize(ref usersStatus, usersStatus.Length + 1);
            usersStatus[usersStatus.Length-1] = status;

            Console.WriteLine("Пользователь успешно добавлен.");
            Console.WriteLine("Нажмите ENTER для продолжения.");
            Console.ReadLine();
            AdminMenu();
        }
        static void LoginUser()
        {

            Console.Clear();
            Console.WriteLine("Введите логин и пароль в формате: Login password");


            string userPass = Console.ReadLine();


            for (int i = 0; i < credrntialsList.Length; i++)

            {
                //Console.WriteLine("debug " + credrntialsList[i]);
                if (userPass.Equals(credrntialsList[i]) && usersStatus[i] == "not blocked")//равенство
                {
                    UserMenu();
                    
                }
                else if (userPass.Equals(credrntialsList[i]) && "BLOCKED!" == usersStatus[i])
                {
                    Console.WriteLine("Вы заблокированы банком. Нажмите Enter для возврата в меню авторизации.");
                    Console.ReadLine();
                    { Login(); }
                    break;
                } else if (usersStatus[i] == null || !userPass.Equals(credrntialsList[i]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Неверный пароль или такого пользователя больше не существует. Нажмите 1 для повторной попытки или 0 для выхода в главное меню.");
                    string errorPass = Console.ReadLine();
                    if (errorPass == "1")
                    { LoginUser(); }
                    else if (errorPass == "0" || errorPass == "")
                    { Login(); }
                    break;
                }

            }
        }

        static void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("Пользователь, выберите действие:" + "\n" +
                   "1 - пополнить счет" + "\n" +
                   "2 - снять деньги" + "\n" +
                   "0 - выйти из учетной записи" + "\n");
            string userDo = Console.ReadLine();
            switch (userDo)
            {
                case "1":
                    { AddMoney(); }
                    break;
                case "2":
                    { TakeMoney(); }
                    break;
                case "0":
                    { Login(); }
                    break;
            }

        }

        public static void AddMoney()
        {

            Console.WriteLine("В целях безопасности введите свое имя и фамилию: ");
            string a = Console.ReadLine();
            int userIndex = GetUsersIndex(namesList, a);


            Console.Clear();
            Console.WriteLine("Введите сумму, которую хотите положить на свой счет: ");
            string sumStr = Console.ReadLine();
            int sum = int.Parse(sumStr);

            summMoney[userIndex] += sum;
            Console.WriteLine("Ваш баланс: " + summMoney[userIndex]);
            Console.ReadLine();
            { UserMenu(); }
        }

        public static void TakeMoney()
        {
            Console.WriteLine("В целях безопасности введите свое имя и фамилию: ");
            string a = Console.ReadLine();
            int userIndex = GetUsersIndex(namesList, a);


            Console.Clear();
            Console.WriteLine("Введите сумму, которую хотите положить на свой счет: ");
            string minusStr = Console.ReadLine();
            int minus = int.Parse(minusStr);

            summMoney[userIndex] -= minus;
            Console.WriteLine("Ваш баланс: " + summMoney[userIndex]);
            Console.ReadLine();
            { UserMenu(); }
        }

        public static int GetUsersIndex(string[] names, string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == name)
                {
                    return i;

                }

            }
            return -1;
        }
    }
}



//Смоделируйте работу пиццерии в вашем приложении.
//К сожалению, в вашей пиццерии ещё не работает доставка.Две ключевые сущности: пользователь и пиццерия взаимодействуют через заказ и пиццу. Пользователь делает заказ в заведении,
// после чего ждет оповещения о том, что пицца готова. Например – его имя высветится на табло. После этого пользователь сам забирает пиццу.
//
//Подумайте, как может выглядеть такое приложение? Какой минимум данных необходим для реализации?
//
//Плюсом будет хранение заказов – например, в формате JSON, или в текстовом файле, или БД (но не обязательно).
//Наличие консольного интерфейса обязательно. Можете продемонстрировать работу с помощью базовых Console.WriteLine(…) и Console.ReadLine(…).
//Обязательно наличие вменяемой архитектуры, прописанных сущностей и базового взаимодействия.


//КРИТЕРИИ ОЦЕНКИ И ДЕТАЛИ

//Оценка за экзаменационный проект будет выставлена по следующим критериям:
//•	5 – выполнен законченный проект на одну из заданных тем, группа успешно показала и объяснила исходный код проекта;
//•	4 – представлен недоделанный проект на одну из заданных тем, либо проект выполнен, но группа не смогла объяснить исходный код проекта;
//•	3 – проект не представлен к сдаче.


//Возможно выполнение проекта в группах до трёх человек, при этом:
//•	Оценка выставляется одна на проект (на группу);
//•	Группа обязана объяснить распределение ролей внутри группы;
//•	Приветствуется и добавляет итоговых баллов использование систем Task Tracking (таких как Trello);
//•	Приветствуется и добавляет итоговых баллов использование систем контроля версий (например, GIT).


using System;
using System.Xml.Linq;

namespace PizzaTime
{
    class Pizza                                                                     // класс для генерации сущности типа Пицца
    {
        string? name = "Undefined";
        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }
    }

    class Pizzeria                                                                  // класс для взаимодействия с сущностями типа Пиццерия и Клиент
    {
        string? name = "Undefined";
        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }

        public void SetPizzaName(Pizza p1, Pizza p2, Pizza p3, Pizza p4, Pizza p5)   // запись названий видов пиццы в экземпляры класса Pizza
        {
            p1.Name = "Original Margherita";
            p2.Name = "Our White Pizza (no tomato sauce)";
            p3.Name = "Rustic Double Pepperoni";
            p4.Name = "Sausage, Peppers and Onion";
            p5.Name = "Pesto Pie";
        }

        public void GetPizzaName(Pizza p1, Pizza p2, Pizza p3, Pizza p4, Pizza p5)   // получение названия вида пиццы
        {
            Console.WriteLine($"1. {p1.Name}");
            Console.WriteLine($"2. {p2.Name}");
            Console.WriteLine($"3. {p3.Name}");
            Console.WriteLine($"4. {p4.Name}");
            Console.WriteLine($"5. {p5.Name}");
        }

        public void CookPizza()                                                      // уведомление о приготовлении выбранной пицы
        {
            Console.WriteLine("Your pizza is getting ready. Please wait a while.\n\n");
            LoadScreen();
        }

        public void LoadScreen()                                                     // имитация экрана процесса приготовления пиццы
        {
            Console.Write("L O A D I N G ");
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(150);
                Console.Write(". ");
            }
            Console.Clear();
        }

        public void GivePizza(Consumer cnsmr)                                        // отдать пиццу клиенту
        {
            Console.Clear();
            Console.WriteLine($"{cnsmr.Name}! Your pizza is ready! Bon appetit.");
        }
    }

    

    class Consumer                                                                  // класс для взаимодействия с сущностями типа клиент
    {
        string? name = "Undefined";
        public string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }

        public void Actions()                                                       // действия, которые может выполнять клиент
        {
            Console.WriteLine("1. Buy pizza.\n" +
                              "2. Exit from pizzeria.");
        }

        public void TakePizza()                                                     // забрать пиццу после приготовления
        {
            Console.WriteLine("\n*you took a pizza and went to the car*");
        }
    }

    class Program
    {
        static void Main()
        {
            // Входные данные.
            string? input;

            Pizza p1 = new();
            Pizza p2 = new();
            Pizza p3 = new();
            Pizza p4 = new();
            Pizza p5 = new();

            Pizzeria pzzr = new();
            Console.Write("Enter the pizzeria's name: ");
            pzzr.Name = Console.ReadLine();

            Consumer cnsmr = new();
            Console.Write("Enter the consumer's name: ");
            cnsmr.Name = Console.ReadLine();

            bool flag = false;
            while(true)                                                             // запуск бесконечного цикла (выход осуществляется по заданному условию) - начало
                                                                                    // работы алгоритма заказа пиццы
            {
                Console.Clear();

                Console.WriteLine($"Hi {cnsmr.Name}! What dou want?");
                cnsmr.Actions();

                Console.Write("> ");
                input = Console.ReadLine();
                while (!flag)
                {
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine();
                            flag = true;
                            break;

                        case "2":
                            Console.WriteLine("Exit...");
                            return;

                        default:
                            Console.WriteLine("Choose correctly action!");
                            break;
                    }
                }
                flag = false;


                // Выбор пиццы клиентом.
                Console.WriteLine("Which pizza do you want to buy?");
                pzzr.SetPizzaName(p1, p2, p3, p4, p5);
                pzzr.GetPizzaName(p1, p2, p3, p4, p5);
                Console.WriteLine();

                Console.Write("> ");
                input = Console.ReadLine();
                while (!flag)
                {
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine($"\nYou chosen {p1.Name}");
                            flag = true;
                            break;

                        case "2":
                            Console.WriteLine($"\nYou chosen {p2.Name}"); ;
                            flag = true;
                            break;

                        case "3":
                            Console.WriteLine($"\nYou chosen {p3.Name}");
                            flag = true;
                            break;

                        case "4":
                            Console.WriteLine($"\nYou chosen {p4.Name}");
                            flag = true;
                            break;

                        case "5":
                            Console.WriteLine($"\nYou chosen {p5.Name}");
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Choose correctly pizza!");
                            Console.Write("> ");
                            input = Console.ReadLine();
                            break;
                    }
                }

                // Уведомление о приготовлении пиццы и отображение имени клиента на дисплее.
                pzzr.CookPizza();
                pzzr.GivePizza(cnsmr);

                cnsmr.TakePizza();

                return;
            }
        }
    }
}
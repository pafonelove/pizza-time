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
using System.Diagnostics;
using System.Xml.Linq;

namespace PizzaTime
{
    // Класс для создания сущностей Pizza.
    class Pizza                                                                   
    {
        string? name = "Undefined";

        // Конструктор для создания экземпляров Pizza.
        public Pizza(string? n)
        {
            if ((n is null) || (n == ""))
                throw new ArgumentNullException("Name must not be empty!");
            name = n;
        }

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

    // Класс для создания сущностей Pizzeria.
    class Pizzeria    
    {
        string? name = "Undefined";

        // Конструктор для создания экземпляров Pizzeria.
        public Pizzeria(string? n)
        {
            if ((n is null) || (n == ""))
                throw new ArgumentNullException("Name must not be empty!");
            name = n;
        }
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

        // Метож отображения названий пицц.
        public void GetPizzaName(Pizza p1, Pizza p2, Pizza p3, Pizza p4, Pizza p5)
        {
            Console.WriteLine($"1. {p1.Name}");
            Console.WriteLine($"2. {p2.Name}");
            Console.WriteLine($"3. {p3.Name}");
            Console.WriteLine($"4. {p4.Name}");
            Console.WriteLine($"5. {p5.Name}");
        }

        // Метод отображения сообщения о приготовлении выбранной пиццы.
        public void CookPizza()
        {
            Console.WriteLine("Your pizza is getting ready. Please wait a while.\n\n");
            LoadScreen();
        }

        // Метод имитации экрана загрузки.
        public void LoadScreen() 
        {
            Console.Write("L O A D I N G ");
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(150);
                Console.Write(". ");
            }
            Console.Clear();
        }

        // Метод отображения сообщения о выдаче готовой пиццы.
        public void GivePizza(Consumer cnsmr) 
        {
            Console.Clear();
            Console.WriteLine($"{cnsmr.Name}! Your pizza is ready! Bon appetit.");
        }
    }

    // Класс для создания сущностей Consumer.
    class Consumer 
    {
        string? name = "Undefined";

        // Конструктор для создания экземпляров Consumer.
        public Consumer(string? n)
        {
            if ((n is null) || (n == ""))
                throw new NullReferenceException("Name must not be empty!");
            name = n;
        }
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

        // Метод отображения действий, которые может выполнять экземпляр Consumer;
        public void Actions()                                                      
        {
            Console.WriteLine("1. Buy pizza.\n" +
                              "2. Exit from pizzeria.");
        }

        // Метод действия - забрать пиццу после приготовления.
        public void TakePizza()
        {
            Console.WriteLine("\n*you took a pizza and went to the car*");
        }
    }

    class Program
    {
        static string? input;
        static bool flag = false;

        static Pizza p1;
        static Pizza p2;
        static Pizza p3;
        static Pizza p4;
        static Pizza p5;
        
        static Pizzeria pzzr;
        static Consumer cnsmr;

        static void Main()
        {
            MakePizzaObj();
            MakePizzeriaObj();
            MakeConsumerObj();
            
            while(true)                                                             // запуск бесконечного цикла (выход осуществляется по заданному условию) - начало
                                                                                    // работы алгоритма заказа пиццы
            {
                Console.Clear();

                ConsActions();
                flag = false;

                ChoosePizzaCons();

                Notifitaction();

                return;
            }
        }

        // Метод создания новых экземпляров класса Pizza.
        static void MakePizzaObj()
        {
            p1 = new("Original Margherita");
            p2 = new("Our White Pizza (no tomato sauce)");
            p3 = new("Rustic Double Pepperoni");
            p4 = new("Sausage, Peppers and Onion");
            p5 = new("Pesto Pie");
        }

        // Метод создания новых экземпляров класса Pizzeria.
        static void MakePizzeriaObj()
        {
            Console.Write("Enter the pizzeria's name: ");
            input = Console.ReadLine();
            pzzr = new(input);
        }

        // Метод создания новых экземпляров класса Consumer.
        static void MakeConsumerObj()
        {
            Console.Write("Enter the consumer's name: ");
            input = Console.ReadLine();
            cnsmr = new(input);
        }

        // Метод вызова действий экземпляра Consumer.
        static void ConsActions()
        {
            Console.WriteLine($"Hi {cnsmr.Name}! What do you want?");
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
        }

        // Вызов метода выбора пиццы эзкемпляром Consumer.
        static void ChoosePizzaCons()
        {
            Console.WriteLine("Which pizza do you want to buy?");
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
        }

        // Метод активации уведомления о приготовлении пиццы и отображения имени клиента на дисплее.
        static void Notifitaction()
        {
            pzzr.CookPizza();
            pzzr.GivePizza(cnsmr);

            cnsmr.TakePizza();
        }
    }
}
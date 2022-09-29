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

namespace PizzaTime
{
    class Pizzeria                                              // класс для взаимодействия с сущностями типа пиццерия
    {
        string? pizzeria;

        string[] pizzas = {                                     // список пицц, которые готовят в заведении
            "Original Margherita",
            "Our White Pizza (no tomato sauce)",
            "Rustic Double Pepperoni",
            "Sausage, Peppers and Onion",
            "Pesto Pie",
            "Pepperoni, Pancetta, Onion",
            "Spinach, Ricotta, Pancetta (White Base)",
            "Spinach & Tomato (White Pie)",
            "Eggplant & Ricotta (Red Pie)",
            "Meatball & Ricotta (Red Pie)"
        };

        public Pizzeria(string? p)
        {
            pizzeria = p;
        }

        public string? Name()
        {
            return pizzeria;
        }

        public void ShowPizzasList()
        {
            for (int i = 0; i < pizzas.Length; i++)
            {
                Console.WriteLine($"{i+1}. {pizzas[i]}.");
            }
        }

        public string? ChosenPizza(int choice)
        {
            return pizzas[choice];
        }
    }

    class Consumer                                                                  // класс для взаимодействия с сущностями типа клиент
    {
        string? consumer;
        public Consumer(string? c)
        {
            consumer = c;
        }

        public string? Name()
        {
            return consumer;
        }

        public void Actions()                                                       // действия, которые может выполнять клиент
        {
            Console.WriteLine("1. Buy pizza.\n" +
                              "2. Exit from pizzeria.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the pizzeria's name: ");
            string? input = Console.ReadLine();
            Pizzeria pzzr = new Pizzeria(input);

            Console.Write("Enter the consumer's name: ");
            input = Console.ReadLine();
            Consumer cnsmr = new Consumer(input);

            bool flag = false;
            while(true)                                                             // запуск бесконечного цикла (выход осуществляется по заданному условию) - начало
                                                                                    // работы алгоритма заказа пиццы
            {
                Console.WriteLine($"Hi {cnsmr.Name()}! What dou want?");
                cnsmr.Actions();

                input = Console.ReadLine();
                while (!flag)
                {
                    switch (input)
                    {
                        case "1":
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

                Console.WriteLine("Which pizza do you want to buy?");
                pzzr.ShowPizzasList();

                input = Console.ReadLine();
                while (!flag)
                {
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(0)}.");
                            flag = true;
                            break;

                        case "2":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(1)}.");
                            flag = true;
                            break;

                        case "3":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(2)}.");
                            flag = true;
                            break;

                        case "4":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(3)}.");
                            flag = true;
                            break;

                        case "5":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(4)}.");
                            flag = true;
                            break;

                        case "6":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(5)}.");
                            flag = true;
                            break;

                        case "7":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(6)}.");
                            flag = true;
                            break;

                        case "8":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(7)}.");
                            flag = true;
                            break;

                        case "9":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(8)}.");
                            flag = true;
                            break;

                        case "10":
                            Console.WriteLine($"You chosen {pzzr.ChosenPizza(9)}.");
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Choose correctly pizza!");
                            break;
                    }
                }
            }
        }
    }
}
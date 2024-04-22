
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Labamemer2;

namespace Labamemer2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Створення потягу
            Train train = new Train("Ластівка", "123-А");

            // Додавання вагонів до потягу
            DiningCarriage diningCarriage = new DiningCarriage("D1", "Dining", 55, 25, 1, 10, true, 5, 100);
            FreightCarriage freightCarriage = new FreightCarriage("F2", "Freight", 60, 30, 2, 50, CargoType.Wood);
            PassengerCarriage passengerCarriage = new PassengerCarriage("P3", "Passenger", 50, 28, 3, 50, "Standard");
            SleepingCarriage sleepingCarriage = new SleepingCarriage("S4", "Sleeping", 65, 32, 4, 10, true, true);

            train.AddCarriage(diningCarriage);
            train.AddCarriage(freightCarriage);
            train.AddCarriage(passengerCarriage);
            train.AddCarriage(sleepingCarriage);

            // Виведення інформації про всі вагони
            train.PrintAllCarriagesInfo();

            // Запит на оцінку їжі у вагоні-ресторані
            Console.WriteLine("Введіть оцінку якості їжі у вагоні D1 (від 1 до 5):");
            int diningCarriageRating = int.Parse(Console.ReadLine());
            diningCarriage.EvaluateFood(diningCarriageRating);

            // Перевірка залишків їжі у вагоні-ресторані
            diningCarriage.CheckFoodStocks();

            // Завантаження вагона-фургона
            Console.WriteLine("Введіть кількість зерна, яку потрібно завантажити у вагон F2:");
            double grainAmount = double.Parse(Console.ReadLine());
            freightCarriage.LoadUnloadCargo(grainAmount);

            // Перевірка вільних місць у пасажирському вагоні
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете розмістити у вагоні P3:");
            int passengersCount = int.Parse(Console.ReadLine());
            passengerCarriage.AreThereFreeSeats(passengersCount);

            // Висадка пасажирів з пасажирського вагона
            Console.WriteLine("Введіть кількість пасажирів, яких ви хочете висадити з вагона P3:");
            int disembarkCount = int.Parse(Console.ReadLine());
            passengerCarriage.DisembarkPassengers(disembarkCount);

            // Перевірка кількості людей, що сплять у спальному вагоні
            sleepingCarriage.CheckSleepingPeople();

            // Перевірка наявності душу у спальному вагоні
            sleepingCarriage.CheckShowers();

            // Перевірка наявності дверей у купе спального вагона
            sleepingCarriage.CheckDoorsInCompartments();

            // Зміна маршруту потягу під час руху
            train.ChangeRouteWhileInMotion("456-Б");

            // Додавання вагона до потягу під час руху
            SleepingCarriage newSleepingCarriage = new SleepingCarriage("S5", "Sleeping", 70, 35, 5, 12, true, true);
            train.AddCarriageWhileInMotion(newSleepingCarriage, 2);

            // Видалення вагона з потягу під час руху
            train.RemoveCarriageWhileInMotion(1);

            // Пошук вагонів за типом
            IEnumerable<Carriage> passengerCarriages = train.FindCarriagesByCriteria(carriage => carriage.Type == "Passenger");
            Console.WriteLine("Вагони-пасажири:");
            foreach (var carriage in passengerCarriages)
            {
                Console.WriteLine(carriage.Id);
            }

            // Розрахунок загальної ваги потягу
            double totalWeight = train.CalculateTotalWeight();
            Console.WriteLine($"Загальна вага потягу: {totalWeight} тонн");
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Программа описания автомобилей ===\n");
        
        while (true)
        {
            Console.Write("Введите марку автомобиля или 'done' для остановки ввода: ");
            string input = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Пожалуйста, введите название автомобиля.\n");
                continue;
            }

            if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Программа завершена. До свидания!");
                break;
            }

            if (CarMappings.ModelDictionary.TryGetValue(input, out CarType carType))
            {
                try
                {
                    ICar car = CarFactory.CreateCar(carType);
                    Console.WriteLine($"«{car.GetDescription()}»\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при создании автомобиля: {ex.Message}\n");
                }
            }
            else
            {
                Console.WriteLine($"Автомобиль '{input}' не найден в базе.\nДоступные модели:\n{CarMappings.AvailableModels}\n");
            }
        }
    }
}

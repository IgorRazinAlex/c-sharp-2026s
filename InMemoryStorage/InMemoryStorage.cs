using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntity
{
    int Id { get; }
}

public class Repository<T> where T : IEntity
{
    private readonly Dictionary<int, T> _storage = new Dictionary<int, T>();

    public int Count => _storage.Count;

    public void Add(T item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            throw new InvalidOperationException($"Element with id {item.Id} already exists.");
        }
        _storage.Add(item.Id, item);
    }

    public bool Remove(int id)
    {
        return _storage.Remove(id);
    }

    public T? GetById(int id)
    {
        return _storage.TryGetValue(id, out var item) ? item : default;
    }

    public IReadOnlyList<T> GetAll()
    {
        return _storage.Values.ToList().AsReadOnly();
    }

    public IReadOnlyList<T> Find(Predicate<T> predicate)
    {
        return _storage.Values.Where(item => predicate(item)).ToList().AsReadOnly();
    }
}

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public override string ToString() => $"[Product] Id: {Id}, Name: {Name}, Price: {Price:C}";
}

public class User : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public override string ToString() => $"[User] Id: {Id}, Name: {Name}";
}

class Program
{
    static void Main()
    {
        var productRepo = new Repository<Product>();
        productRepo.Add(new Product { Id = 1, Name = "Phone", Price = 50000 });
        productRepo.Add(new Product { Id = 2, Name = "Case", Price = 800 });
        productRepo.Add(new Product { Id = 3, Name = "Laptop", Price = 120000 });

        Console.WriteLine($"Total product: {productRepo.Count}");

        var p = productRepo.GetById(1);
        Console.WriteLine($"Found by Id=1: {p?.Name}");

        Console.WriteLine("\nProducts more expensive than 1000:");
        var expensiveProducts = productRepo.Find(x => x.Price > 1000);
        foreach (var item in expensiveProducts)
        {
            Console.WriteLine(item);
        }

        try
        {
            Console.WriteLine("\nDublicates check:");
            productRepo.Add(new Product { Id = 1, Name = "aboba" });
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"error: {ex.Message}");
        }

        Console.WriteLine("\nUser usage");
        var userRepo = new Repository<User>();
        userRepo.Add(new User { Id = 101, Name = "Biba" });
        userRepo.Add(new User { Id = 102, Name = "Boba" });

        foreach (var user in userRepo.GetAll())
        {
            Console.WriteLine(user);
        }
    }
}

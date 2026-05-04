using System;
using System.Collections.Generic;

public static class CollectionUtils
{
    public static List<T> Distinct<T>(List<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        var result = new List<T>();
        var seen = new HashSet<T>();

        foreach (var item in source)
        {
            if (seen.Add(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public static Dictionary<TKey, List<TValue>> GroupBy<TValue, TKey>(
        List<TValue> source,
        Func<TValue, TKey> keySelector) where TKey : notnull
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

        var groups = new Dictionary<TKey, List<TValue>>();

        foreach (var item in source)
        {
            TKey key = keySelector(item);
            if (!groups.ContainsKey(key))
            {
                groups[key] = new List<TValue>();
            }
            groups[key].Add(item);
        }
        return groups;
    }

    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
        Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second,
        Func<TValue, TValue, TValue> conflictResolver) where TKey : notnull
    {
        if (first == null || second == null) throw new ArgumentNullException("Dictionaries cannot be null");

        var result = new Dictionary<TKey, TValue>(first);

        foreach (var kvp in second)
        {
            if (result.ContainsKey(kvp.Key))
            {
                result[kvp.Key] = conflictResolver(result[kvp.Key], kvp.Value);
            }
            else
            {
                result[kvp.Key] = kvp.Value;
            }
        }
        return result;
    }

    public static T MaxBy<T, TKey>(List<T> source, Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        if (source == null || source.Count == 0)
            throw new InvalidOperationException("Sequence contains no elements");

        T maxElement = source[0];
        TKey maxValue = selector(maxElement);

        for (int i = 1; i < source.Count; i++)
        {
            TKey currentValue = selector(source[i]);
            if (currentValue.CompareTo(maxValue) > 0)
            {
                maxValue = currentValue;
                maxElement = source[i];
            }
        }
        return maxElement;
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main()
    {
        var numbers = new List<int> { 1, 2, 2, 3, 1, 4 };
        var uniqueNumbers = CollectionUtils.Distinct(numbers);

        var words = new List<string> { "apple", "banana", "pear", "kiwi", "plum" };
        var groupedByLength = CollectionUtils.GroupBy(words, w => w.Length);

        var dict1 = new Dictionary<string, int> { { "hello", 1 }, { "world", 2 } };
        var dict2 = new Dictionary<string, int> { { "world", 3 }, { "csharp", 5 } };
        var merged = CollectionUtils.Merge(dict1, dict2, (v1, v2) => v1 + v2);

        var products = new List<Product>
        {
            new Product { Name = "Phone", Price = 500 },
            new Product { Name = "Laptop", Price = 1500 },
            new Product { Name = "Mouse", Price = 20 }
        };
        var expensive = CollectionUtils.MaxBy(products, p => p.Price);

        Console.WriteLine($"Max: {expensive.Name} for {expensive.Price}");
    }
}

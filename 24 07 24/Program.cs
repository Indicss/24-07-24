using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int CopiesAvailable { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet", Year = 2019, CopiesAvailable = 5 },
            new Book { Id = 2, Title = "Pro C# 7", Author = "Andrew Troelsen", Year = 2018, CopiesAvailable = 2 },
            new Book { Id = 3, Title = "C# 6.0 and the .NET 4.6 Framework", Author = "Andrew Troelsen", Year = 2015, CopiesAvailable = 0 },
            new Book { Id = 4, Title = "Learning C# by Developing Games", Author = "Harrison Ferrone", Year = 2020, CopiesAvailable = 4 },
            new Book { Id = 5, Title = "CLR via C#", Author = "Jeffrey Richter", Year = 2012, CopiesAvailable = 1 }
        };

        var booksByAndrewTroelsen = books.Where(b => b.Author == "Andrew Troelsen").ToList();
        Console.WriteLine("Books by Andrew Troelsen:");
        booksByAndrewTroelsen.ForEach(b => Console.WriteLine(b.Title));

        var booksOrderedByYearDesc = books.OrderByDescending(b => b.Year).ToList();
        Console.WriteLine("\nBooks ordered by year (desc):");
        booksOrderedByYearDesc.ForEach(b => Console.WriteLine($"{b.Title} - {b.Year}"));

        var availableBooksTitles = books.Where(b => b.CopiesAvailable > 0).Select(b => b.Title).ToList();
        Console.WriteLine("\nAvailable books titles:");
        availableBooksTitles.ForEach(t => Console.WriteLine(t));

        var totalCopiesAvailable = books.Sum(b => b.CopiesAvailable);
        Console.WriteLine($"\nTotal copies available: {totalCopiesAvailable}");

        var uniqueAuthors = books.Select(b => b.Author).Distinct().ToList();
        Console.WriteLine("\nUnique authors:");
        uniqueAuthors.ForEach(a => Console.WriteLine(a));

        int pageSize = 2;
        int pageNumber = 2;
        var secondPageBooks = books.OrderBy(b => b.Title)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();
        Console.WriteLine("\nSecond page of books (ordered by title):");
        secondPageBooks.ForEach(b => Console.WriteLine(b.Title));
    }
}

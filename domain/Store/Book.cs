﻿using System.Text.RegularExpressions;

namespace Store;

public class Book
{
    public int Id { get; }
    public string Isbn { get; }
    public string Author { get; }
    public string Title { get; }

    public Book(int id, string Isbn, string Autor, string title)
    {

        Id = id;
        Title = title;
        Author = Autor;
        Isbn = Isbn;
    }
    internal static bool IsIsbn(string s)
    {
        if (s == null) return false;
        s = s.Replace("-", "").Replace(" ", "").ToUpper();
        return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
    }
}

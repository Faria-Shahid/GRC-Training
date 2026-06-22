// Note to self
// b => b. is similar to the lambda in python.
// The groups are like the groups in SQL


public static class LINQQueries
{
    // 1. Filter books by a specific author
    public static void FilterByAuthor(int authorId)
{
    Console.Write("Filtering Books by Authors.");
    Author? author = InMemoryStore.getAuthorById(authorId);

    if (author == null){
        Console.WriteLine("Author not found.");
        return;
        
    }

    Console.WriteLine("Author: " + author.Name);

    var result = InMemoryStore.Books.Where(b => b.AuthorId == authorId);

    foreach (var book in result)
    {
        Console.WriteLine(book.Title);
    }
}


    // 2. Select titles sorted alphabetically
    public static void TitlesSorted()
    {
        var result = InMemoryStore.Books
            .Select(b => b.Title)
            .OrderBy(t => t);

        foreach (var title in result)
            Console.WriteLine(title);
    }

    // 3. Group books by author
    public static void GroupByAuthor()
    {
        var result = InMemoryStore.Books.GroupBy(b => b.AuthorId);

        foreach (var group in result)
        {
            Console.WriteLine("AuthorId: " + group.Key);
            foreach (var book in group)
                Console.WriteLine("  " + book.Title);
        }
    }

    // 4. Average page count across all books
    public static void AveragePages()
    {
        double avg = InMemoryStore.Books.Average(b => b.PageCount);
        Console.WriteLine("Average pages: " + avg);
    }

    // 5. Check if any book has more than 500 pages
    public static void AnyOver500Pages()
    {
        bool result = InMemoryStore.Books.Any(b => b.PageCount > 500);
        Console.WriteLine("Any book over 500 pages: " + result);
    }

    // 6. Get first book matching an Id, or null if not found
    public static void FirstOrDefaultById(int id)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
            Console.WriteLine("Book not found");
        else
            Console.WriteLine("Found: " + book.Title);
    }

    // 7. Join books with authors to get author name alongside book title
    public static void JoinBooksAndAuthors()
    {
        var result = InMemoryStore.Books.Join(
            InMemoryStore.Authors,
            book => book.AuthorId,
            author => author.Id,
            (book, author) => new { book.Title, author.Name }
        );

        foreach (var item in result)
            Console.WriteLine(item.Title + " by " + item.Name);
    }

    // 8. Top 3 books with the most pages
    public static void Top3Longest()
    {
        var result = InMemoryStore.Books
            .OrderByDescending(b => b.PageCount)
            .Take(3);

        foreach (var book in result)
            Console.WriteLine(book.Title + " - " + book.PageCount + " pages");
    }
}

InMemoryStore.Seed();

foreach (Book book in InMemoryStore.Books)
{
    Console.WriteLine(book.Id + " " + book.Title + " " + book.Year + " " + book.nav.Name);
}

LINQQueries.FilterByAuthor(1);

using Entity_Framework_Training.DbContexts;
using Entity_Framework_Training.Vare;
using Microsoft.EntityFrameworkCore;

List<Book> listeBooks = new List<Book>()
        {
            new () { Navn = "To Kill a Mockingbird", Beskrivelse = "Novel", LagerStatus = 10, Pris = 9.99 },
            new Book { Navn = "1984", Beskrivelse = "Dystopian fiction", LagerStatus = 15, Pris = 8.49 },
            new Book { Navn = "The Great Gatsby", Beskrivelse = "Fiction", LagerStatus = 20, Pris = 12.99 },
            new Book { Navn = "Harry Potter and the Philosopher's Stone", Beskrivelse = "Fantasy", LagerStatus = 5, Pris = 14.99 },
            new Book { Navn = "Pride and Prejudice", Beskrivelse = "Romance", LagerStatus = 30, Pris = 10.5 },
            new Book { Navn = "The Catcher in the Rye", Beskrivelse = "Novel", LagerStatus = 8, Pris = 11.25 },
            new Book { Navn = "The Lord of the Rings", Beskrivelse = "Fantasy", LagerStatus = 25, Pris = 19.99 },
            new Book { Navn = "The Hobbit", Beskrivelse = "Fantasy", LagerStatus = 12, Pris = 16.75 },
            new Book { Navn = "The Hunger Games", Beskrivelse = "Science fiction", LagerStatus = 18, Pris = 13.49 },
            new Book { Navn = "The Da Vinci Code", Beskrivelse = "Mystery", LagerStatus = 7, Pris = 9.25 }
        };


VareDbContext db = new VareDbContext();

await db.AddRangeAsync(listeBooks);

Book newBook = new Book { Navn = "Ayy Macarena", Beskrivelse = "Fiction", LagerStatus = 6, Pris = 199.95 };

await db.Books.AddAsync(newBook);
await db.SaveChangesAsync();

List<Book> books = await db.Books.ToListAsync();
Book book = db.Books.FirstOrDefault(b => b.Navn.Contains("The"));
Console.WriteLine($"Navn: {book.Navn}, Beskrivelse: {book.Beskrivelse}, LagerStatus: {book.LagerStatus}, Pris: {book.Pris}");

// Find de to bøger, du vil opdatere
Book book1 = await db.Books.FirstOrDefaultAsync(b => b.Navn == "The Great Gatsby");
Book book2 = await db.Books.FirstOrDefaultAsync(b => b.Navn == "Pride and Prejudice");

if (book1 != null && book2 != null)
{
    // Opdater værdierne for de to bøger
    book1.LagerStatus = 22;
    book1.Pris = 14.99;

    book2.LagerStatus = 35;
    book2.Pris = 11.5;

    // Gem ændringerne i databasen
    db.Update(book1);
    db.Update(book2);
    await db.SaveChangesAsync();

    Console.WriteLine("Bøgerne er blevet opdateret.");
}
else
{
    Console.WriteLine("Mindst en af bøgerne blev ikke fundet.");
}

//Slet en vare, fra DB
VareDbContext DBSlet=new VareDbContext();
//Tjek databasen igennem for om navnet passer
Book deleteBook=await DBSlet.Books.FirstOrDefaultAsync(b=>b.Navn =="The Greate Gatsby");

if (deleteBook == null)
{
    Console.WriteLine("Bogen findes ikke i databasen");
}
else
{
    DBSlet.Remove(deleteBook);
    await DBSlet.SaveChangesAsync();
    Console.WriteLine("Bogen blev slette fra databasen");
}


// Find den første bog i databasen
Book firstBook = await db.Books.OrderBy(b => b.Id).FirstOrDefaultAsync();

// Find den sidste bog i databasen
Book lastBook = await db.Books.OrderByDescending(b => b.Id).FirstOrDefaultAsync();

if (firstBook != null && lastBook != null)
{
    Console.WriteLine("Første bog i databasen:");
    Console.WriteLine($"Navn: {firstBook.Navn}, Beskrivelse: {firstBook.Beskrivelse}");

    Console.WriteLine("\nSidste bog i databasen:");
    Console.WriteLine($"Navn: {lastBook.Navn}, Beskrivelse: {lastBook.Beskrivelse}");
}
else
{
    Console.WriteLine("Der er ingen bøger i databasen.");
}

//Find den dyreste bog i DB
Book expensiveBook = await db.Books.OrderByDescending(b => b.Pris).FirstOrDefaultAsync();
if(expensiveBook==null)
    Console.WriteLine("Der er ingen bøger i databasen");
else
{
    Console.WriteLine($"Navn: {expensiveBook.Navn} Pris: {expensiveBook.Pris}");
}


// Find summen for hele databasen
List<Book> books1 = await db.Books.ToListAsync();

decimal totalValue = 0;

foreach (var book5 in books1)
{
    decimal bookValue = (decimal)book5.LagerStatus * (decimal)book5.Pris;
    totalValue += bookValue;
}
Console.WriteLine($"Den samlede værdi af databasen er: {totalValue}");

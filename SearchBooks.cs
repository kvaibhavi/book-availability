async Task<ConsoleState> SearchBooks()
{
    Console.WriteLine("Enter a book title to search for");
    string? bookTitle = Console.ReadLine();

    if (string.IsNullOrEmpty(bookTitle))
    {
        Console.WriteLine("Book title cannot be empty. Please try again.");
        return ConsoleState.PatronDetails;
    }

    // Find book by title (case-insensitive)
    var book = _jsonData.Books.FirstOrDefault(b => 
        b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));

    if (book == null)
    {
        Console.WriteLine($"No book found with title '{bookTitle}'. Please try again.");
        return ConsoleState.PatronDetails;
    }

    // Get the BookItem for this book
    var bookItem = _jsonData.BookItems.FirstOrDefault(bi => bi.BookId == book.Id);

    if (bookItem == null)
    {
        Console.WriteLine($"Book item not found for '{book.Title}'. Please try again.");
        return ConsoleState.PatronDetails;
    }

    // Check for active loans (ReturnDate is null)
    var activeLoan = _jsonData.Loans.FirstOrDefault(l => 
        l.BookItemId == bookItem.Id && l.ReturnDate == null);

    if (activeLoan == null)
    {
        Console.WriteLine($"{book.Title} is available for loan");
    }
    else
    {
        Console.WriteLine($"{book.Title} is on loan to another patron. The return due date is {activeLoan.DueDate}");
    }

    return ConsoleState.PatronDetails;
}

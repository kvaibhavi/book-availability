async Task<ConsoleState> SearchBooks()
{
    Console.WriteLine("Enter a book title to search for");
    string? bookTitle = Console.ReadLine();

    if (string.IsNullOrEmpty(bookTitle))
    {
        Console.WriteLine("Book title cannot be empty. Please try again.");
        return ConsoleState.PatronDetails;
    }

    return ConsoleState.PatronDetails;
}

static void WriteInputOptions(CommonActions options)
{
    Console.WriteLine("Input Options:");
    if (options.HasFlag(CommonActions.ReturnLoanedBook))
    {
        Console.WriteLine(" - \"r\" to mark as returned");
    }
    if (options.HasFlag(CommonActions.ExtendLoanedBook))
    {
        Console.WriteLine(" - \"e\" to extend the book loan");
    }
    if (options.HasFlag(CommonActions.RenewPatronMembership))
    {
        Console.WriteLine(" - \"m\" to extend patron's membership");
    }
    if (options.HasFlag(CommonActions.SearchPatrons))
    {
        Console.WriteLine(" - \"s\" for new search");
    }
    if (options.HasFlag(CommonActions.SearchBooks))
    {
        Console.WriteLine(" - \"b\" to check for book availability");
    }
    if (options.HasFlag(CommonActions.Quit))
    {
        Console.WriteLine(" - \"q\" to quit");
    }
    if (options.HasFlag(CommonActions.Select))
    {
        Console.WriteLine("Or type a number to select a list item.");
    }
}

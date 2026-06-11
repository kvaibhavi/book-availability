async Task<ConsoleState> PatronDetails()
{
    Console.WriteLine($"Name: {selectedPatronDetails.Name}");
    Console.WriteLine($"Membership Expiration: {selectedPatronDetails.MembershipEnd}");
    Console.WriteLine();
    Console.WriteLine("Book Loans:");
    int loanNumber = 1;
    foreach (Loan loan in selectedPatronDetails.Loans)
    {
        Console.WriteLine($"{loanNumber}) {loan.BookItem!.Book!.Title} - Due: {loan.DueDate} - Returned: {(loan.ReturnDate != null).ToString()}");
        loanNumber++;
    }

    CommonActions options = CommonActions.SearchPatrons | CommonActions.Quit | CommonActions.Select | CommonActions.RenewPatronMembership | CommonActions.SearchBooks;
    CommonActions action = ReadInputOptions(options, out int selectedLoanNumber);

    if (action == CommonActions.Select)
    {
        if (selectedLoanNumber >= 1 && selectedLoanNumber <= selectedPatronDetails.Loans.Count())
        {
            var selectedLoan = selectedPatronDetails.Loans.ElementAt(selectedLoanNumber - 1);
            selectedLoanDetails = selectedPatronDetails.Loans.Where(l => l.Id == selectedLoan.Id).Single();
            return ConsoleState.LoanDetails;
        }
        else
        {
            Console.WriteLine("Invalid book loan number. Please try again.");
            return ConsoleState.PatronDetails;
        }
    }
    else if (action == CommonActions.Quit)
    {
        return ConsoleState.Quit;
    }
    else if (action == CommonActions.SearchPatrons)
    {
        return ConsoleState.PatronSearch;
    }
    else if (action == CommonActions.RenewPatronMembership)
    {
        var status = await _patronService.RenewMembership(selectedPatronDetails.Id);
        Console.WriteLine(EnumHelper.GetDescription(status));
        // reloading after renewing membership
        selectedPatronDetails = (await _patronRepository.GetPatron(selectedPatronDetails.Id))!;
        return ConsoleState.PatronDetails;
    }
    else if (action == CommonActions.SearchBooks)
    {
        return await SearchBooks();
    }

    throw new InvalidOperationException("An input option is not handled.");
}

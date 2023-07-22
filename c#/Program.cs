using System;
using System.Collections.Generic;

class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; } 
    public string Author {get; set; } 
    public int Number { get; set; } 

    public string Category { get; set; }

    public Book(string isbn,string title, string author, int number, string category)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        Number = number;
        Category = category;
    }
}
class Member {
    public string CardId { get; set; }
    public string Name { get; set; }
    public string CMND { get; set;} 

    public string Daycreated  { get; set;}

    public Member(string cardId,string name, string cmnd, string daycreated) {
        CardId = cardId;
        Name = name;
        CMND = cmnd;
        Daycreated = daycreated;
       
    }
}
class LoanCard {
    public string CardId { get; set; }
    public string BookISBN { get; set; }
    public string LoanDate { get; set; }
    public string DueDate { get; set; }
   

    public LoanCard(string cardId, string bookISBN, string loanDate, string dueDate)
    {
        CardId = cardId;
        BookISBN = bookISBN;
        LoanDate = loanDate;
        DueDate = dueDate;
    }
}

class Library
{
    public List<Book> books = new List<Book>(); 
    private List<Member> members = new List<Member>();
     private List<LoanCard> loans = new List<LoanCard>();

//Book
   
   
    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Library is empty!");
            return;
        }

        Console.WriteLine("=======================================");
        Console.WriteLine("List of books");
        Console.WriteLine("");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|  ISBN          |  Title                 |  Author                  |  Quantity    |  Category              |");
        Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
        foreach (Book book in books)
        {

            Console.WriteLine($"|  {book.ISBN,-14}|  {book.Title,-22}|  {book.Author,-24}|  {book.Number,-12}|  {book.Category,-22}|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");

        }
    }
    public void UpdateBook(string isbn)
    {
        Book bookToUpdate = books.Find(book => book.ISBN == isbn);
        if (bookToUpdate == null)
        {
            Console.WriteLine("Book not found!");
            return;
        }

        Console.Write(" - Enter new title (or press enter to keep current infomation): ");
        string title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title))
        {
            bookToUpdate.Title = title;
        }

        Console.Write(" - Enter new author (or press enter to keep current infomation): ");
        string author = Console.ReadLine();
        if (!string.IsNullOrEmpty(author))
        {
            bookToUpdate.Author = author;
        }

        Console.Write(" - Enter new number of copies (or press enter to keep current infomation): ");
        string numberString = Console.ReadLine();
        int number;
        if (!string.IsNullOrEmpty(numberString) && int.TryParse(numberString, out number))
        {
            bookToUpdate.Number = number;
        }

        Console.Write(" - Enter new category (or press enter to keep current infomation): ");
        string category = Console.ReadLine();
        if (!string.IsNullOrEmpty(category))
        {
            bookToUpdate.Category = category;
        }

        Console.WriteLine("Book updated successfully!");
    }

     public void AddBook(string isbn,string title, string author, int number, string category)
    {
        Book book = new Book(isbn, title, author, number, category);
        books.Add(book);
        Console.WriteLine("Book added successfully!");
    }

//Card
    public void DisplayCards()
    {
        if (members.Count == 0)
        {
            Console.WriteLine("There aren't any members in the library!");
            return;
        }

        Console.WriteLine("=======================================");
        Console.WriteLine("List of member cards");
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("|  ID Card          |  Name                  |  CMND                |  Day created            |");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        foreach (Member member in members)
        {
            Console.WriteLine($"|  {member.CardId,-17}|  {member.Name,-21}|  {member.CMND,-21}|  {member.Daycreated,-23}|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
        }
    }

    public void AddCard(string cardId,string name, string cmnd, string daycreated)
    {
        Member member = new Member(cardId, name, cmnd, daycreated);
        members.Add(member);
        Console.WriteLine("Card added successfully!");
    }

    public void UpdateCard(string cardId)
    {
        Member CardToUpdate = members.Find(member => member.CardId == cardId);
        if (CardToUpdate == null)
        {
            Console.WriteLine("Card not found!");
            return;
        }

        Console.Write(" - Enter new name (or press enter to keep current infomation): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name))
        {
            CardToUpdate.Name = name;
        }

        Console.Write(" - Enter new CMND (or press enter to keep current infomation): ");
        string cmnd = Console.ReadLine();
        if (!string.IsNullOrEmpty(cmnd))
        {
            CardToUpdate.CMND = cmnd;
        }
        Console.Write(" - Enter date updated: ");
        string daycreated = Console.ReadLine();
        if (!string.IsNullOrEmpty(daycreated))
        {
            CardToUpdate.Daycreated = daycreated;
        }
        Console.WriteLine("Card updated successfully!");
    }

//Loan
    public void AddLoanCard(string cardId, string bookISBN, string loanDate, string dueDate)
    {
        LoanCard loanCard = new LoanCard(cardId, bookISBN, loanDate, dueDate);
        bool BookExists = false;
        foreach(Book book in books)
        {
            if(book.ISBN == bookISBN)
            {
                BookExists = true;
                break;
            }
        }
        bool CardExists = false;
        foreach(Member member in members )
        {
            if(member.CardId == cardId)
            {
                CardExists = true;
                break;
            }
        }

        if(CardExists && BookExists)
        {
            loans.Add(loanCard);
            Console.WriteLine("Loan card created successfully!");
        }
        else
        {
            Console.WriteLine("Card ID or book ISBN does not exist for loan!");
        }
  
    }

    public void DisplayLoans()
    {
        if (loans.Count == 0)
        {
            Console.WriteLine("There aren't any loan cards in the library!");
            return;
        }
        
        Console.WriteLine("=======================================");
        Console.WriteLine("List of loan cards");
        Console.WriteLine("");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("|  Card ID   |  Book ISBN           |  Loan Date                 |  Due Date                  |");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        foreach (LoanCard loan in loans)
        {
            Console.WriteLine($"|  {loan.CardId,-10}|  {loan.BookISBN,-20}|  {loan.LoanDate,-26}|  {loan.DueDate,-26}|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            
        }

    }
}



class Program
{
    static void Main(string[] args)
    {
        bool isProgramRunning = true;
        Library library = new Library(); 

        while (isProgramRunning)
        {
            Console.WriteLine("\n--- Welcome to VTC Libary ---");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Manage books in library");
            Console.WriteLine("2. Manage library members' card");
            Console.WriteLine("3. Manage book borrowing form");
            Console.WriteLine("0. Exit");
            Console.Write("#Choose: ");

            string option = Console.ReadLine().Trim();

            switch (option)
            {   
                case "1":
                    string bookOption;
                    do
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine("1. Display all books");
                        Console.WriteLine("2. Update book");
                        Console.WriteLine("3. Add new book");
                        Console.WriteLine("0. Back to main menu ");
                        Console.Write("#Choose: ");

                        bookOption = Console.ReadLine().Trim();

                        switch (bookOption)
                        {
                            case "1":
                                library.DisplayBooks();
                                break;

                            case "2":
                                Console.Write(" - Enter book ISBN: ");
                                string find_isbn =Console.ReadLine();
                                library.UpdateBook(find_isbn);
                                break;

                            case "3":
                                Console.Write(" - Enter book ISBN: ");
                                string isbn = Console.ReadLine().Trim();
                                Console.Write(" - Enter book title:  ");
                                string title = Console.ReadLine().Trim();
                                Console.Write(" - Enter book author: ");
                                string author = Console.ReadLine().Trim();
                                Console.Write(" - Enter quantity of books: ");
                                int number = int.Parse(Console.ReadLine().Trim());
                                Console.Write(" - Enter category: ");
                                string category = Console.ReadLine().Trim();
                                library.AddBook(isbn, title, author, number, category);
                                break;

                            case "0":
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (bookOption != "0");
                    

                    break;

                case "2":
                    string cardOption;
                    do
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine("1. Display all member'cards");
                        Console.WriteLine("2. Update card information");
                        Console.WriteLine("3. Add new member's card");
                        Console.WriteLine("0. Back to main menu ");
                        Console.Write("#Choose: ");
                        cardOption = Console.ReadLine().Trim();
                        switch (cardOption)
                        {
                            case "1":
                                library.DisplayCards();
                                break;
                            case "2":
                                Console.Write(" - Enter your card ID: ");
                                string find_id =Console.ReadLine().Trim();
                                library.UpdateCard(find_id);
                                break;
                            case "3":
                                Console.Write(" - Enter card ID: ");
                                string cardId = Console.ReadLine().Trim();
                                Console.Write(" - Enter member's name: ");
                                string name = Console.ReadLine().Trim();
                                Console.Write(" - Enter member's CMND: ");
                                string cmnd = Console.ReadLine().Trim();
                                Console.Write(" - Enter the day card created (dd/mm/yyyy): ");
                                string daycreated = Console.ReadLine().Trim();
                                library.AddCard(cardId, name, cmnd, daycreated);
                                break;
                            case "0":
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (cardOption != "0");
                   
                    break;
                
                case "3":
                    string loanOption;
                    do
                    {
                        Console.WriteLine("===============================");
                        Console.WriteLine("1. Create a new loan book");
                        Console.WriteLine("2. Display all loan book");
                        Console.WriteLine("0. Back to main menu ");
                        Console.Write("Enter your choice: ");
                        loanOption = Console.ReadLine();

                        switch (loanOption)
                        {
                            case "1":
                                Console.Write(" - Enter card ID: ");
                                string cardId = Console.ReadLine();
                                Console.Write(" - Enter book ISBN: ");
                                string bookISBN = Console.ReadLine();
                                Console.Write(" - Enter loan date (dd/mm/yyyy): ");
                                string loanDate = Console.ReadLine();
                                Console.Write(" - Enter due date (dd/mm/yyyy): ");
                                string dueDate = Console.ReadLine();
                                library.AddLoanCard(cardId, bookISBN, loanDate, dueDate);
                                break;

                            case "2":
        
                                library.DisplayLoans();
                                break;

                            case "0":
                                break;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    } while (loanOption != "0");
                    
                    break;

                case "0":
                    Console.WriteLine("Thank you for using VTCA Library!");
                    isProgramRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}

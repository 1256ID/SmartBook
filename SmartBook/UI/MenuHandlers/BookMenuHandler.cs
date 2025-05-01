using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Session;
using SmartBook.Utilities;
using SmartBook.UI.FormatTools;
using System.ComponentModel;
using SmartBook.Enums.Models;

namespace SmartBook.UI.MenuHandlers
{
    public class BookMenuHandler
    {
        private readonly BookHandler _bookHandler;
        private readonly LibraryCardHandler _libraryCardHandler;
        private readonly LoanHandler _loanHandler;
        private readonly UserHandler _userHandler;

        private readonly UserContext _userContext;

        public BookMenuHandler(BookHandler bookHandler, LibraryCardHandler libraryCardHandler, LoanHandler loanHandler, UserHandler userHandler, UserContext userContext)
        {
            _bookHandler = bookHandler;
            _libraryCardHandler = libraryCardHandler;
            _loanHandler = loanHandler;
            _userHandler = userHandler;
            _userContext = userContext;
        }
        public Book SearchForBook()
        {
            int index = 0;
            bool whileSearching = true;
            Book book = new();
            do
            {
                Console.Clear();
                string? input = "";
                string[] menuChoices =
                [
                    "Titel",
                    "Författare",
                    "ISBN",
                    "Gå tillbaka till förgående meny"
                ];

                index = Menu.Display("Sök efter...", menuChoices, index);

                if (index == 3)
                {
                    whileSearching = false;
                }

                // Hittar ingen bok som heter 'Avbryt' så har valt att ha med funktionalitet där användaren kan avbryta sökandet när de vill genom att skriva in 'avbryt' i inmatningen.

                while (input != "avbryt")
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv in 'avbryt' ifall du vill avbryta.");
                        Console.Write("Ange " + menuChoices[index] + ": ");
                        input = Console.ReadLine();

                        if (string.IsNullOrEmpty(input))
                        {
                            Console.Clear();
                            Console.WriteLine("Inmatningen får inte vara tom eller null.");
                            AppTools.WaitForEnterKey();
                            continue;
                        }

                        else
                        {
                            if (index == 0)
                            {
                                if (_bookHandler.GetBooksByTitle(input).Count > 1)
                                {
                                    List<Book> books = _bookHandler.GetBooksByTitle(input);
                                    book = SelectBook(books, "Böcker med titeln: " + input);
                                }

                                else
                                {
                                    book = _bookHandler.GetBookByTitle(input);
                                }

                                input = "avbryt";
                            }

                            else if (index == 1)
                            {

                                if (_bookHandler.GetBooksByAuthor(input).Count > 1)
                                {
                                    List<Book> books = _bookHandler.GetBooksByAuthor(input);
                                    book = SelectBook(books, "Böcker med författaren: " + input);
                                }

                                else
                                {
                                    book = _bookHandler.GetBookByAuthor(input);
                                }

                                input = "avbryt";
                            }

                            else if (index == 2)
                            {
                                Guid guid = Guid.Empty;

                                bool validGuid = Guid.TryParse(input, out guid);

                                if (validGuid)
                                {
                                    book = _bookHandler.GetBookByISBN(guid);
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ogiltigt format/tecken för ISBN, var vänlig och försök igen.");
                                    AppTools.WaitForEnterKey();
                                }

                            }

                        }
                    }

                    catch
                    {
                        Console.WriteLine("Ogiltig inmatning kändes igen. Försök igen.");
                        AppTools.WaitForEnterKey();
                    }
                }


            } while (whileSearching);

            return (book);
        }

        public Book SelectBook(List<Book> books, string menuTitle)
        {
            string[] bookArray = FormatBooksAsArray(books);
            int index = 0;
            index = Menu.Display
            (
                menuTitle,
                bookArray,
                index
            );

            return books[index];
        }


        public void AddBook()
        {
            bool bookIsCreated = false;

            do
            {
                string title = AppTools.PromptUserForTextInput("Ange titel för boken: ");
                string author = AppTools.PromptUserForTextInput("Ange författare för boken: ");
                BookGenre genre = SelectBookGenre();
                BookCondition condition = SelectBookCondition();
                BookStatus status = SelectBookStatus();

                bookIsCreated = _bookHandler.AddBook(status, condition, title, author, genre);

                if (!bookIsCreated)
                {
                    Console.WriteLine("Det gick inte att lägga till boken, var vänlig och försök igen.");
                    AppTools.WaitForEnterKey();
                }


            } while (!bookIsCreated);
        }

        public void ViewBook(Book book)
        {
            int index = 0;
            bool view = true;
            string bookView = FormatTools.BookFormat.FormatDetailsAsString(book) + "\n";

            do
            {
                Console.Clear();

                index = Menu.Display
                    (
                        bookView,
                        [
                            "Låna",
                            "Redigera",
                            "Ta bort",
                            "Gå tillbaka till förgående meny"
                        ], index
                    );

                switch (index)
                {
                    case 0:
                        LoanBook(book);
                        break;

                    case 1:
                        EditBook(book);
                        break;

                    case 2:
                        RemoveBook(book.Id);
                        view = false;
                        break;

                    case 3:
                        view = false;
                        break;
                }


            } while (view);
        }

        public void LoanBook(Book book)
        {
            User? user = _userContext.SelectedUser;

            if (user != null)
            {
                LibraryCard card = _libraryCardHandler.GetLibraryCardByUserId(user.Id);


                if (card != null)
                {
                    bool loanIsCreated = _loanHandler.CreateLoan(book, user.Id, card.CardNumber);

                    if (loanIsCreated)
                        Console.WriteLine("Du har lånat " + book.BookInfo.Title + "\nKolla på 'Mina lån för att se mer info.");

                    else
                        Console.WriteLine("Lånet av boken" + book.BookInfo.Title + " misslyckades, var vänlig och försök igen.");

                    AppTools.WaitForEnterKey();
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("För att låna en bok behöver du ett lånekort, var vänlig och skapa ett först.");
                    AppTools.WaitForEnterKey();
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Den valda användaren returnerar null");
                AppTools.WaitForEnterKey();
            }
        }

        public void EditBook(Book book)
        {
            int index = 0;
            bool editing = true;
            do
            {
                string[] arrayOfDetails = BookFormat.FormatDetailsAsArray(book);

                index = Menu.Display
                    (
                        book.BookInfo.Title,
                        arrayOfDetails,
                        index
                    );

                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Du kan inte ändra detta värde.");
                        AppTools.WaitForEnterKey();
                        break;

                    case 1:
                        book.BookInfo.SetTitle(AppTools.PromptUserForTextInput("Ange Titel: "));
                        break;

                    case 2:
                        book.BookInfo.SetAuthor(AppTools.PromptUserForTextInput("Ange Författare: "));
                        break;

                    case 3:
                        book.BookInfo.SetGenre(SelectBookGenre());
                        break;

                    case 4:
                        book.SetConditon(SelectBookCondition());
                        break;

                    case 5:
                        book.SetStatus(SelectBookStatus());
                        break;

                    case 6:
                        Console.Clear();
                        Console.WriteLine("Du kan inte ändra detta värde.");
                        AppTools.WaitForEnterKey();
                        break;

                    case 7:
                        editing = false;
                        break;

                }


            } while (editing);


        }

        public BookGenre SelectBookGenre()
        {
            string[] names = Enum.GetNames(typeof(BookGenre));
            int index = Menu.Display("Ange genre:\n", names, 0);

            var values = Enum.GetValues<BookGenre>();

            if (index < 0 || index >= values.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Valt index är ogiltigt.");

            return values[index];
        }

        public BookCondition SelectBookCondition()
        {
            string[] names = Enum.GetNames(typeof(BookCondition));
            int index = Menu.Display("Ange skick:\n", names, 0);

            var values = Enum.GetValues<BookCondition>();

            if (index < 0 || index >= values.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Valt index är ogiltigt.");

            return values[index];
        }

        public BookStatus SelectBookStatus()
        {
            string[] names = Enum.GetNames(typeof(BookStatus));
            int index = Menu.Display("Ange tillgänglighet:\n", names, 0);

            var values = Enum.GetValues<BookStatus>();

            if (index < 0 || index >= values.Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Valt index är ogiltigt.");

            return values[index];
        }

        public void RemoveBook(Guid bookId)
        {
            _bookHandler.RemoveBook(bookId);
            Console.WriteLine("Boken har nu tagits bort.");
            AppTools.WaitForEnterKey();
        }

        public string[] FormatBooksAsArray(List<Book> books)
        {
            int index = 0;
            string[] booksArray = new string[books.Count];
            foreach (Book book in books)
            {
                booksArray[index++] = BookFormat.FormatRow(book);
            }

            return booksArray;
        }

        public string[] FormatBooksAsArrayWithExitOption(List<Book> books)
        {
            int index = 0;
            string[] booksArray = new string[books.Count + 1];
            foreach (Book book in books)
            {
                booksArray[index++] = BookFormat.FormatRow(book);
            }

            booksArray[index++] = "Gå tillbaka till förgående meny";

            return booksArray;
        }

        public void ListBooks()
        {
            List<Book> books = _bookHandler.GetBooks();

            int index = Menu.Display
                (
                    "Alla böcker",
                    FormatBooksAsArrayWithExitOption(books),
                    0
                );

            if (index != books.Count + 1 && books.Count != 0)
            {
                ViewBook(books[index]);
            }

        }
    }
}

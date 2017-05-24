namespace HackatonBot.BookImporter
{
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   using CsvHelper;
   using Dal.Entity.Library;
   using Dal.Repository.Library;

   internal class Program
   {
      #region Non-public static members

      private static void Main(string[] args)
      {
         var bookRepository = new AmdarisBookRepository();

         var bookCategoryRepository = new BookCategoryRepository();
         using (TextReader textReader = File.OpenText("BookImporter.csv"))
         {
            var csv = new CsvReader(textReader);
            while (csv.Read())
            {
               string bookName = csv.GetField<string>(0);
               string bookAuthor = csv.GetField<string>(1);
               IList<string> bookCategoryNames = csv.GetField<string>("Categories").Split(' ')
                                                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
               IList<BookCategory> bookCategories = new List<BookCategory>();
               foreach (string bookCategoryName in bookCategoryNames)
               {
                  BookCategory bookCategory = bookCategoryRepository.FindBookCategoryByName(bookCategoryName);
                  if (bookCategory == null)
                  {
                     bookCategory = new BookCategory(bookCategoryName);
                     bookCategoryRepository.SaveOrUpdate(bookCategory);
                  }
                  bookCategories.Add(bookCategory);
               }

               var book = new AmdarisBook(bookAuthor, bookName);
               foreach (BookCategory bookCategory in bookCategories)
                  book.AssignCategory(bookCategory);
               bookRepository.SaveOrUpdate(book);

               bookCategoryRepository.RegenerateSession();
               bookRepository.RegenerateSession();
            }
         }
      }

      #endregion
   }
}
using Library.Data.Entities;
using System.Collections.Generic;

namespace Library.Data.MockData
{
    public static class MockData
    {
        public static IEnumerable<Book> GetAllLibraryMockData()
        {
            var personsPopulated = new List<Borrower>
            {
                new Borrower
                {
                    Id = 1,
                    FirstName = "Cristina",
                    LastName = "Cris"
                },
                new Borrower
                {
                    Id = 2,
                    FirstName = "Andreea",
                    LastName = "Andy"
                },
                new Borrower
                {
                    Id = 3,
                    FirstName = "Mihai",
                    LastName = "Miha"
                },
                new Borrower
                {
                    Id = 4,
                    FirstName = "Ana",
                    LastName = "Any"
                }
            };

            var bookListPopulate = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Author = "Jane Austen",
                    BorowerId = 1,
                    Description = "The Pride of Jane Austen! The story is set in England in the late 18th century",
                    Name = "Pride and Prejudice",
                    Year = 1813
                },
                new Book
                {
                    Id = 2,
                    Author = "F. Scott Fitzgerald",
                    BorowerId = 1,
                    Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald",
                    Name = "The Great Gatsby",
                    Year = 1925
                }, new Book
                {
                    Id = 3,
                    Author = "Charlotte Bronte",
                    BorowerId = 4,
                    Description = "Jane Eyre is a novel by English writer Charlotte Bronte  on 16 October 1847",
                    Name = "Jane Eyre",
                    Year = 1847
                }, new Book
                {
                    Id = 4,
                    Author = "J. D. Salinger",
                    BorowerId = 2,
                    Description = "The Catcher in the Rye is a novel by J. D. Salinger, partially published in serial form in 1945–1946 and as a novel in 1951",
                    Name = "The Catcher in the Rye",
                    Year = 1951
                }, new Book
                {
                    Id = 5,
                    Author = "Miguel de Cervantes",
                    BorowerId = 3,
                    Description = "Don Quixote is a Spanish novel by Miguel de Cervantes. Its full title is The Ingenious Gentleman Don Quixote of La Mancha",
                    Name = "Don Quixote",
                    Year = 1605
                }
            };

            return bookListPopulate;
        }
    }
}

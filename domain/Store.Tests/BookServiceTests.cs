﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositorystub = new Mock<IBookRepository>();
            bookRepositorystub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "") });
            bookRepositorystub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositorystub.Object);
            var validIsbn = "ISBN 12345-67890";
            var actual = bookService.GetAllByQuery(validIsbn);
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }
        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositorystub = new Mock<IBookRepository>();
            bookRepositorystub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book(1, "", "", "") });
            bookRepositorystub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositorystub.Object);
            var invalidIsbn = "12345-67890";
            var actual = bookService.GetAllByQuery(invalidIsbn);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

    }
}

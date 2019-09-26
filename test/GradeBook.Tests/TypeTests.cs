using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book1");// creating the completely new object
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
             Assert.NotSame(book1,book2);
        }

            [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");// creating the completely new object
            var book2 = book1;

           Assert.Same(book1,book2);//point to the same object in memory 
           Assert.True(Object.ReferenceEquals(book1,book2)); //checked if the values pointing to the same object
        }

        Book GetBook(string name)
        {
           return new Book(name);
        }
    }
}

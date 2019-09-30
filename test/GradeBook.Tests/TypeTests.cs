using System;
using Xunit;

namespace GradeBook.Tests
{
    public  delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        //Delegate-----------------------------------
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count ++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count ++;
            return message;
        }

        //------------------------------------      
        [Fact]
        public void ValueTypesAlsoPassByRef()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }
        private int GetInt()
        {
            return 3;
        }
        //------------------------------------
        [Fact]
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        //------------------------------------
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            //book.Name=name;
        }
        //--------------------------------------
        [Fact]
        public void GetSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name=name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Nenad";
            var upper = MakeUpperCase(name);

            Assert.Equal("Nenad", name);
            Assert.Equal("NENAD", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

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
            var book2 = book1;//it is not a copy of some object, this will take the value that is inside in the book1, that value is a pointer to the reference

           Assert.Same(book1,book2);//point to the same object in memory 
           Assert.True(Object.ReferenceEquals(book1,book2)); //checked if the values pointing to the same object
        }

        Book GetBook(string name)
        {
           return new Book(name);
        }
    }
}

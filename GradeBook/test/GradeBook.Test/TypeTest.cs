using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string LogMessage);
    public class TypeTest
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
            WriteLogDelegate log;
            log = new WriteLogDelegate(ReturnMessage);
            // log = ReturnMessage;
            var result = log("hello");

        //Then
            Assert.Equal("hello",result);
        }

        string ReturnMessage(String msg)
        {
            return msg;
        }
         
        [Fact]
        public void GetBookReturnDifferentObject()
        {
            // Arrange
            var book1 = GetBook("book 1");
            var book2 = GetBook("book 2");
            // Act

            // Assert
            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);

        }

        InMemoryBook GetBook(String name)
        {
            return new InMemoryBook(name);
        }
    }
}

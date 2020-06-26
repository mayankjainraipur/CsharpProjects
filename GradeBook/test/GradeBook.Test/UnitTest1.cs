using System;
using Xunit;

namespace GradeBook.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(70);
            book.AddGrade(70);
            book.AddGrade(70);
            // Act

            var result = book.GetStatistics();

            // Assert
            Assert.Equal(70,result.Average, 1);
            Assert.Equal(70,result.High, 1);
            Assert.Equal(70,result.Low, 1);

        }
    }
}

using RomanToArabicNumeralConverter.Common;

namespace RomanToArabicNumeralConverter.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Success_CreatesSuccessfulResult_WithValidData()
        {
            const int expectedData = 12;

            var result = Result<int>.Success(expectedData);

            Assert.True(result.Status);
            Assert.Equal(expectedData, result.Data);
            Assert.Empty(result.Error);
        }

        [Fact]
        public void Failure_CreatesFailedResult_WithErrorMessage()
        {
            const string errorMessage = "Error";

            var result = Result<int>.Failure(errorMessage);

            Assert.False(result.Status);
            Assert.Equal(errorMessage, result.Error);
        }
    }
}

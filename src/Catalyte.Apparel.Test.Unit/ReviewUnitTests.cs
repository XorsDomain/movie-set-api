using Catalyte.Apparel.Data.SeedData;
using Xunit;

namespace Catalyte.Apparel.Test.Unit
{
    public class ReviewUnitTests
    {
        [Fact]
        public void GenerateRandomReviews_Returns600Reviews()
        {
           var reviewFactory = new ReviewFactory();
            int numberOfReviews = 600;
            int expected = 600;
            int actual = reviewFactory.GenerateRandomReviews(numberOfReviews).Count;
           Assert.Equal(expected, actual);
        }
    }
}

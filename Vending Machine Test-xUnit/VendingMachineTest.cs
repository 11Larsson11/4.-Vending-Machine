using System;
using Xunit;
using _4._Vending_Machine.Machine_Unit;


namespace Vending_Machine_Test_xUnit
{
    public class VendingMachineTest : VendingMachine
    {

        [Theory]
        [InlineData(2, "nam", 23, 200, 100)]
        [InlineData(2, "nam", 23, 150, 75)]
        public void CandyTest(int a, string b, int c, double d, double expectedResult)
        {
            Product sut = new Candy(a, b, c, d);
            double result = sut.MinutesToBurnCalories();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2, "nam", 23, 90, 50)]
        [InlineData(2, "nam", 23, 270, 150)]
        public void FoodTest(int a, string b, int c, double d, double expectedResult)
        {
            Product sut = new Food(a, b, c, d);
            double result = sut.MinutesToBurnCalories();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2,"nam",23,250, 100)]
        [InlineData(2,"nam",23,330, 132)]
        public void DrinkTest(int a, string b, int c, double d, double expectedResult)
        {
            Product sut = new Drink(a, b, c, d);
            double result = sut.MinutesToBurnCalories();

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(75, 0)]
        [InlineData(123, 0)]
        [InlineData(15, 0)]
        [InlineData(3, 0)]
        public void ChangeCounterTest(int input, int expectedResult)
        {
            var result = ChangeCounter(input);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1,15,false)]
        [InlineData(35,8,true)]
        [InlineData(15,15,true)]
        [InlineData(3,22,false)]
        public void CanBuyTest(int input1, int input2, bool expectedResult)
        {
            var result = CanBuy(input1, input2);
            Assert.Equal(expectedResult, result);
        }
    }
}

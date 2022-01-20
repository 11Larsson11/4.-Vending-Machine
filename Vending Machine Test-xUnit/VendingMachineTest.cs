using System;
using Xunit;
using _4._Vending_Machine;
using _4._Vending_Machine.Machine_Unit;


namespace Vending_Machine_Test_xUnit
{
    public class VendingMachineTest : VendingMachine
    {
        [Fact]
        public void CandyTest()
        {

            

            int a = 1;
            string b = "Generic Name";
            int c = 2;

            Candy sut = new Candy(a, b, c);

            Assert.Equal(sut.Slot, a);
            Assert.Equal(sut.Info, b);
            Assert.Equal(sut.Cost, c);
        }

        [Fact]
        public void FoodTest()
        {
            int a = 1;
            string b = "Generic Name";
            int c = 2;

            Food sut = new Food(a, b, c);

            Assert.Equal(sut.Slot, a);
            Assert.Equal(sut.Info, b);
            Assert.Equal(sut.Cost, c);
        }

        [Fact]
        public void DrinkTest()
        {
            int a = 1;
            string b = "Generic Name";
            int c = 2;

            Drink sut = new Drink(a, b, c);

            Assert.Equal(sut.Slot, a);
            Assert.Equal(sut.Info, b);
            Assert.Equal(sut.Cost, c);
        }

        [Fact]
        public void ProductTest()
        {
            int a = 2;
            string b = "Another generic name";
            int c = 3;

            Product sut = new Drink(a, b, c);
            Examine();
            sut.Use();
        }

        [Theory]
        [InlineData("0", -1)]
        [InlineData("1", 1)]
        [InlineData("3", -1)]
        [InlineData("20", 20)]
        [InlineData("r", -1)]
        public void CheckValidTest(string input, int expectedResult) //Testing both against the valid denominations and if it's an int value
        {
            var result = CheckValid(input);

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
        [InlineData(0,15,0)]
        [InlineData(35,8,1)]
        [InlineData(15,15,1)]
        [InlineData(3,22,0)]
        public void CanBuyTest(int input1, int input2, int expectedResult)
        {
            var result = CanBuy(input1, input2);

            Assert.Equal(expectedResult, result);
        }
    }
}

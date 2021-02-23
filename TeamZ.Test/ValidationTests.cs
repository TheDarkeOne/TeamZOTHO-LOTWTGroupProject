using FluentAssertions;
using NUnit.Framework;
using TeamZ.Shared;
using TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services;

namespace TeamZ.Test
{
    public class Tests
    {
        public ValidateClass validation { get; set; }
        public const int TITLE_SIZE = 50;
        public const int DESCRIPTION_SIZE = 200;

        [SetUp]
        public void Setup()
        {
            validation = new ValidateClass();
        }

        [Test]
        public void NormalStringTest()
        {
            var ValidTitle = "HelloThere";
            validation.ValidateString(ValidTitle).Should().BeTrue();
            validation.ValidateStringSize(ValidTitle, TITLE_SIZE).Should().BeTrue();
            var ValidDescription = "Lorem ipsum dolor sit amet, consectetur adipiscingnt occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            validation.ValidateString(ValidDescription).Should().BeTrue();
            validation.ValidateStringSize(ValidDescription, DESCRIPTION_SIZE).Should().BeTrue();
        }

        [Test]
        public void NormalClassTest()
        {
            var validStoreItem = new StoreItem("Jeffery the Cat", (decimal)300.00);
            validStoreItem.Description = "Literally a cat";
            validation.ValidateStoreItem(validStoreItem).Should().BeTrue();


            var validCategory = new Category { Title = "Animals" };
            validation.ValidateCategory(validCategory).Should().BeTrue();

            var validTransaction = new StoreTransaction() { Item = validStoreItem, Quantity = 300 };
            validation.ValidateTransactionQuantity(validTransaction.Quantity).Should().BeTrue();
        }

        [Test]
        public void BoundaryTest()
        {
            var invalidItemName = "kgRxXxbJKbiMVqssqYT7x1vu1XB7kyIEuPOa89ATphpkdkI6ZDR";
            validation.ValidateStringSize(invalidItemName, TITLE_SIZE).Should().BeFalse();

            var invalidDescription = "KunDFRe0T5o98FJEdHrJo3c5cajuDhezZACl19UM1Clx7rbsfp2sjeiJJMWNGDpSiHx2Yctz1JiXMN0VSTyq5J1vRE2xmLiTKAj0fsASYbeNclrgT8hqZ7nnOktI6v0LaJkGX1QGjPDL1kIWjIBHBcO4zcLYQ8Mxf5IMqX9SnzHrybZzWh6PuiXn5vRDDq9u6kGlqoBwT";
            validation.ValidateStringSize(invalidDescription, DESCRIPTION_SIZE).Should().BeFalse();
        }

        [Test]
        public void InvalidInputTest()
        {
            string invalidString = "--awefawfe";
            validation.ValidateString(invalidString).Should().BeFalse();
        }

        [Test]
        public void InvalidTransactionQuantityTest()
        {
            var invalidTransactionQuantity = -1;
            validation.ValidateTransactionQuantity(invalidTransactionQuantity).Should().BeFalse();

            var invalidTransactionQuantity2 = 501;
            validation.ValidateTransactionQuantity(invalidTransactionQuantity2).Should().BeFalse();
        }


    }
}
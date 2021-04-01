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

            var validItemName = "kgRxXxbJKbiMVqssqYT7x1vu1XB7kyIEuPOa89ATphpkdkI6ZD";
            validation.ValidateStringSize(validItemName, TITLE_SIZE).Should().BeTrue();

            var validDescription = "KunDFRe0T5o98FJEdHrJo3c5cajuDhezZACl19UM1Clx7rbsfp2sjeiJJMWNGDpSiHx2Yctz1JiXMN0VSTyq5J1vRE2xmTKAj0fsASYbeNclrgT8hqZ7nnOktI6v0LaJkGX1QGjPDL1kIWjIBHBcO4zcLYQ8Mxf5IMqX9SnzHrybZzWh6PuiXn5vRDDq9u6kGlqoBwT";
            validation.ValidateStringSize(validDescription, DESCRIPTION_SIZE).Should().BeTrue();
        }

        [Test]
        public void InvalidInputTest()
        {
            string invalidString = "--awefawfe";
            validation.ValidateString(invalidString).Should().BeFalse();

            string emptyString = "";
            validation.ValidateStringSize(emptyString, TITLE_SIZE).Should().BeFalse();
            validation.ValidateStringSize(emptyString, DESCRIPTION_SIZE).Should().BeFalse();
        }

        [Test]
        public void TransactionQuantityTests()
        {
            var invalidTransactionQuantity = -1;
            validation.ValidateTransactionQuantity(invalidTransactionQuantity).Should().BeFalse();

            var invalidTransactionQuantity2 = 501;
            validation.ValidateTransactionQuantity(invalidTransactionQuantity2).Should().BeFalse();

            var validTransactionQuantityZero = 0;
            validation.ValidateTransactionQuantity(validTransactionQuantityZero).Should().BeFalse();

            var validTransactionQuantityLow = 1;
            validation.ValidateTransactionQuantity(validTransactionQuantityLow).Should().BeTrue();

            var validTransactionQuantityHigh = 500;
            validation.ValidateTransactionQuantity(validTransactionQuantityHigh).Should().BeTrue();

            

        }

        [Test]
        public void ExtremeValueTests()
        {
            var extremeLowInt = int.MinValue;
            var extremeHighInt = int.MaxValue;

            validation.ValidateTransactionQuantity(extremeLowInt).Should().BeFalse();
            validation.ValidateTransactionQuantity(extremeHighInt).Should().BeFalse();

            var extremeLargeString = "ZTCERGRA9nIQWrvvM6rK3diZq" +
                "kqecgTNtpoclel4TnVQdoCV8rpLWa" +
                "gOEOEAYbiTf9QSimMJ5JD4Ztfu5H6rK" +
                "gPXBEklhcGkmhRvulReCefrTXbNnKH" +
                "UwyZjSCoprUwkCfuFtIsrwrZmeAUYKtM" +
                "g7ZSXoklksZnCwXpTGvcDPklY3uPFa" +
                "6LwVxGILSpwdBNMVQgQuAdEJCS57B" +
                "HWLUit7P7FZJ7eXKFExConi5QTxyVC" +
                "TVFVM112BC1PJXOWukvdbGrwyaz4f7aupW" +
                "ZxIWzjR4gh8L9mRJejFqpWSLtDpnuHBqsW48lT" +
                "F3xWXIiD7mQkdjTecKbXBm3Vrt08584fDV" +
                "ykV5eLDpnaAlh8eyHvxEfHJFeTsxj85g" +
                "nbz1uEI8mWaC01fVFECp2GHyUFk87rBSF7e" +
                "RZEbtToO6VGURdqyA2YaaanVsJ7IPEKRT2" +
                "QRtUS9CtbJ5FIK0BJx9NG8IPqUxGx4a8PPyO" +
                "n7RVwwcP1D01fYDMQENUqs5CYrFqkcpR36Vox" +
                "rbUNkT94NWmbdN96SuYg5DkbYdNd8vdmv8zEO" +
                "X3kGR1Bfql0eO33PMsV9qFxVfF2I0vGoqvBMhp" +
                "vwTm6kmqEyNl2qGvp6gKu7Ko3kIBPgXy42QM5m" +
                "efX3M018HgBtPJvmFl8HzEzHWKMBZDxgcoVLP7sU" +
                "WbMSU5hjzS2SpPAPkqTEQ4kuV1JdCujrqc4jrzw" +
                "QMPQJc2DAMaqtt5doZlWgkmJG4N3fanLTszdkAZy" +
                "mISoyw7s5nWQPqlypxrrsOvjVT2tRhgsDgoCGxpt" +
                "WVrgsKl0MdbMloofUtfnKO1O9AOy9FDdDLoMbI8J" +
                "6XUZVyCiQj9y9UGHVtrN0GO2uNefRI0llSQd4k8ae" +
                "lkVOndJ6PLzoj7R7A20KimYjEkc0wZK1dD6WMvp25" +
                "xzQ3DCmarLfn7A9EAOKEsPCxGL1hFXlehIsrHGTtR" +
                "ssCGbywb2VUrYETHVH1OPr92tk1umiIzg3qzFY3qXS" +
                "QeunFqC4C15Fs1ri6C9m7WTUyb8V";

            validation.ValidateStringSize(extremeLargeString, extremeLowInt).Should().BeFalse();


        }

        [Test]
        public void UsernameExtremeTesting()
        {
            var shortUserName = "a";
            validation.ValidateUsername(shortUserName).Should().BeFalse();

            var longUserName = "ZTCERGRA9nIQWrvvM6rK3diZq" +
                "kqecgTNtpoclel4TnVQdoCV8rpLWa" +
                "gOEOEAYbiTf9QSimMJ5JD4Ztfu5H6rK" +
                "gPXBEklhcGkmhRvulReCefrTXbNnKH" +
                "UwyZjSCoprUwkCfuFtIsrwrZmeAUYKtM" +
                "g7ZSXoklksZnCwXpTGvcDPklY3uPFa" +
                "6LwVxGILSpwdBNMVQgQuAdEJCS57B" +
                "HWLUit7P7FZJ7eXKFExConi5QTxyVC";

            validation.ValidateUsername(longUserName).Should().BeFalse();
        }

        [Test]
        public void PasswordExtremeTesting()
        {

        }


    }
}
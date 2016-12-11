namespace Cosmetics.Tests.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cosmetics.Tests.Engine.Mocks;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputStringIsValidCreateCategoryCommand_CategoryShouldBeAddedToList()
        {
            // Arrange
            var categoryName = "ForMale";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);
            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            // Act
            engine.Start();

            // Assert
            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputStringIsValidAddToCategoryCommand_ProductShouldBeAddedToCategory()
        {
            var category = "ForMale";
            var product = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedToothPaste = new Mock<IToothpaste>();

            mockedCommand.Setup(x => x.Name).Returns("AddToCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { category, product });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(category, mockedCategory.Object);
            engine.Products.Add(product, mockedToothPaste.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedToothPaste.Object), Times.Once);
        }

        [Test]
        //Start should read, parse and execute "RemoveFromCategory" command, 
        //when the passed input string is in the format that represents a 
        //RemoveFromCategory command, which should result in removing the 
        //selected product from the respective category.
        public void Start_WhenInputStringIsValidRemoveFromCategoryCommand_ProductShouldRemoveFromCategory()
        {
            var category = "ForMale";
            var product = "Colage";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothPaste = new Mock<IToothpaste>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.Setup(x => x.Name).Returns("AddToCategory");
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string> { category, product });
            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);
            engine.Categories.Add(category, mockedCategory.Object);
            engine.Products.Add(product, mockedToothPaste.Object);

            engine.Start();

            mockedCategory.Verify(x => x.RemoveProduct(mockedToothPaste.Object), Times.Once);
        }
    }
}

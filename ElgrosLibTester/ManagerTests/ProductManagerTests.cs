using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using ElgrosLibTester.Setup;

namespace ElgrosLibTester.ManagerTests
{
    /// <summary>
    /// Testing class for the CategoryManager's class methods
    /// </summary>
    internal class ProductManagerTests
    {
        private IProductManager _manager;

        [SetUp]
        public void Setup()
        {
            var db = SqlConfigurationSetup.SetupDB();
            _manager = new ProductManager(db);
        }

        /// <summary>
        /// Tests the GetAllAsync method of the ProductManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task GetAllAsync_HasData_IfCollectionIsNotNull()
        {
            //Act
            var products = await _manager.GetAllAsync();
            AsyncTestDelegate getAllAction = async () => await _manager.GetAllAsync();

            //Assert
            Assert.IsNotNull(products);
            Assert.IsNotEmpty(products);
            Assert.Greater(products.Count(), 0);
            Assert.DoesNotThrowAsync(getAllAction);
        }

        /// <summary>
        /// Tests the CreateAsync method of the ProductManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task CreateAsync_CreatesAProduct_IfArgumentsAreValid()
        {
            //Arrange
            Product testProduct = CreateTestProduct();


            //Act
            bool result = await _manager.CreateAsync(testProduct);

            //Cleanup
            await _manager.DeleteAsync(testProduct);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the ProductManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task GetByIdAsync_ReturnsAValidProduct_IfArgumentsAreValid()
        {
            //Arrange
            Product requestedProduct;
            Product testProduct = CreateTestProduct();
            await _manager.CreateAsync(testProduct);

            //Act
            requestedProduct = await _manager.GetByIdAsync(testProduct.Id);

            //Cleanup
            await _manager.DeleteAsync(testProduct);

            //Assert
            Assert.That(requestedProduct.Id, Is.EqualTo(testProduct.Id));
            Assert.That(requestedProduct.Name, Is.EqualTo(testProduct.Name));
            Assert.That(requestedProduct.Description, Is.EqualTo(testProduct.Description));
            Assert.That(requestedProduct.Price, Is.EqualTo(testProduct.Price));
            Assert.That(requestedProduct.Quantity, Is.EqualTo(testProduct.Quantity));
            Assert.That(requestedProduct.PhotoUrl, Is.EqualTo(testProduct.PhotoUrl));
            Assert.That(requestedProduct.CategoryId, Is.EqualTo(testProduct.CategoryId));
            Assert.That(requestedProduct.SubCategoryId, Is.EqualTo(testProduct.SubCategoryId));
        }

        /// <summary>
        /// Tests the UpdateAsync method of the ProductManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(4)]
        public async Task UpdateAsync_UpdatesExistingProduct_IfArgumentsAreValid()
        {
            //Arrange
            Product testProduct = CreateTestProduct();
            Product updatedProduct = CreateUpdateTestProduct();
            await _manager.CreateAsync(testProduct);

            //Act
            var result = await _manager.UpdateAsync(updatedProduct);

            //Cleanup
            await _manager.DeleteAsync(updatedProduct);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the RemoveObjectAsync method of the ProductManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(5)]
        public async Task RemoveObjectAsync_RemovesExistingProduct_IfArgumentsAreValid()
        {
            //Arrange
            Product testProduct = CreateTestProduct();
            await _manager.CreateAsync(testProduct);

            //Act
            var result = await _manager.DeleteAsync(testProduct);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>Product Object</returns>
        private Product CreateTestProduct()
        {
            Product testObject = ProductFactory.CreateProduct(1000, "Test Product", "This is a test", 100, 100, "", 1, 1);
            return testObject;
        }

        /// <summary>
        /// Method for getting a different test object
        /// </summary>
        /// <returns>Product Object</returns>
        private Product CreateUpdateTestProduct()
        {
            Product testObject = ProductFactory.CreateProduct(1000, "Updated Test Product", "This is an update test", 200, 50, "", 1, 1);
            return testObject;
        }
    }
}

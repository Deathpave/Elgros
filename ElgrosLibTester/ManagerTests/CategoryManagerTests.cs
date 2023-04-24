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
    internal class CategoryManagerTests
    {
        private ICategoryManager _manager;

        [SetUp]
        public void Setup()
        {
            var db = SqlConfigurationSetup.SetupDB();
            _manager = new CategoryManager(db);
        }

        /// <summary>
        /// Tests the GetAllAsync method of the CategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task GetAllAsync_HasData_IfCollectionIsNotNull()
        {
            //Act
            var categories = await _manager.GetAllAsync();
            AsyncTestDelegate getAllAction = async () => await _manager.GetAllAsync();

            //Assert
            Assert.IsNotNull(categories);
            Assert.IsNotEmpty(categories);
            Assert.Greater(categories.Count(), 0);
            Assert.DoesNotThrowAsync(getAllAction);
        }

        /// <summary>
        /// Tests the CreateAsync method of the CategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task CreateAsync_CreatesACategory_IfArgumentsAreValid()
        {
            //Arrange
            Category testCategory = CreateTestCategory();


            //Act
            bool result = await _manager.CreateAsync(testCategory);

            //Cleanup
            await _manager.DeleteAsync(testCategory);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the CategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task GetByIdAsync_ReturnsAValidObject_IfArgumentsAreValid()
        {
            //Arrange
            Category requestedCategory;
            Category testCategory = CreateTestCategory();
            await _manager.CreateAsync(testCategory);

            //Act
            requestedCategory = await _manager.GetByIdAsync(testCategory.Id);

            //Cleanup
            await _manager.DeleteAsync(testCategory);

            //Assert
            Assert.That(requestedCategory.Id, Is.EqualTo(testCategory.Id));
            Assert.That(requestedCategory.Name, Is.EqualTo(testCategory.Name));
        }

        /// <summary>
        /// Tests the UpdateAsync method of the CategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(4)]
        public async Task UpdateAsync_UpdatesExistingObject_IfArgumentsAreValid()
        {
            //Arrange
            Category testCategory = CreateTestCategory();
            Category updatedCategory = CreateUpdateTestCategory();
            await _manager.CreateAsync(testCategory);

            //Act
            var result = await _manager.UpdateAsync(updatedCategory);

            //Cleanup
            await _manager.DeleteAsync(updatedCategory);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the RemoveObjectAsync method of the CategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(5)]
        public async Task RemoveObjectAsync_RemovesExistingObject_IfArgumentsAreValid()
        {
            //Arrange
            Category testCategory = CreateTestCategory();
            await _manager.CreateAsync(testCategory);

            //Act
            var result = await _manager.DeleteAsync(testCategory);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>Category Object</returns>
        private Category CreateTestCategory()
        {
            Category testObject = CategoryFactory.CreateCategory(1000, "Test Category");
            return testObject;
        }

        /// <summary>
        /// Method for getting a different test object
        /// </summary>
        /// <returns>Category Object</returns>
        private Category CreateUpdateTestCategory()
        {
            Category testObject = CategoryFactory.CreateCategory(1000, "Updated Test Category");
            return testObject;
        }

    }
}

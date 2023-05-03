using ElgrosLib.DataModels;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using ElgrosLibTester.Setup;

namespace ElgrosLibTester.ManagerTests
{
    /// <summary>
    /// Testing class for the SubCategoryManager's class methods
    /// </summary>
    internal class SubCategoryManagerTests
    {
        private ISubCategoryManager _manager;
        private CategoryManager _categoryManager;

        [SetUp]
        public void Setup()
        {
            var db = SqlConfigurationSetup.SetupDB();
            _manager = new SubCategoryManager(db);
            _categoryManager = new CategoryManager(db);
        }

        /// <summary>
        /// Tests the GetAllAsync method of the SubCategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task GetAllAsync_HasData_IfCollectionIsNotNull()
        {
            //Act
            var subCategories = await _manager.GetAllAsync();
            AsyncTestDelegate getAllAction = async () => await _manager.GetAllAsync();

            //Assert
            Assert.IsNotNull(subCategories);
            Assert.IsNotEmpty(subCategories);
            Assert.Greater(subCategories.Count(), 0);
            Assert.DoesNotThrowAsync(getAllAction);
        }

        /// <summary>
        /// Tests the CreateAsync method of the SubCategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task CreateAsync_CreatesASubCategory_IfArgumentsAreValid()
        {
            //Arrange
            Category category = CreateTestCategory();
            SubCategory testSubCategory = CreateTestSubCategory();
            await _categoryManager.CreateAsync(category);


            //Act
            bool result = await _manager.CreateAsync(testSubCategory);

            //Cleanup
            await _manager.DeleteAsync(testSubCategory);
            await _categoryManager.DeleteAsync(category);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the SubCategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task GetByIdAsync_ReturnsAValidSubCategory_IfArgumentsAreValid()
        {
            //Arrange
            Category category = CreateTestCategory();
            SubCategory requestedSubCategory;
            SubCategory testSubCategory = CreateTestSubCategory();
            await _categoryManager.CreateAsync(category);
            await _manager.CreateAsync(testSubCategory);

            //Act
            requestedSubCategory = await _manager.GetByIdAsync(testSubCategory.Id);

            //Cleanup
            await _manager.DeleteAsync(testSubCategory);
            await _categoryManager.DeleteAsync(category);

            //Assert
            Assert.That(requestedSubCategory.Id, Is.EqualTo(testSubCategory.Id));
            Assert.That(requestedSubCategory.Name, Is.EqualTo(testSubCategory.Name));
            Assert.That(requestedSubCategory.CategoryId, Is.EqualTo(testSubCategory.CategoryId));
        }

        /// <summary>
        /// Tests the UpdateAsync method of the SubCategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(4)]
        public async Task UpdateAsync_UpdatesExistingSubCategory_IfArgumentsAreValid()
        {
            //Arrange
            Category category = CreateTestCategory();
            SubCategory testSubCategory = CreateTestSubCategory();
            SubCategory updatedSubCategory = CreateUpdateTestSubCategory();
            await _categoryManager.CreateAsync(category);
            await _manager.CreateAsync(testSubCategory);

            //Act
            var result = await _manager.UpdateAsync(updatedSubCategory);

            //Cleanup
            await _manager.DeleteAsync(updatedSubCategory);
            await _categoryManager.DeleteAsync(category);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the RemoveObjectAsync method of the SubCategoryManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(5)]
        public async Task RemoveObjectAsync_RemovesExistingSubCategory_IfArgumentsAreValid()
        {
            //Arrange
            Category category = CreateTestCategory();
            SubCategory testSubCategory = CreateTestSubCategory();
            await _categoryManager.CreateAsync(category);
            await _manager.CreateAsync(testSubCategory);

            //Act
            var result = await _manager.DeleteAsync(testSubCategory);

            //Cleanup
            await _categoryManager.DeleteAsync(category);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>Category Object</returns>
        private Category CreateTestCategory()
        {
            Category testObject = _categoryManager.ConvertToCategory("Test Category", 1000);
            return testObject;
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>SubCategory Object</returns>
        private SubCategory CreateTestSubCategory()
        {
            SubCategory testObject = _manager.ConvertToSubCategory("Test SubCategory", 1000, 1000);
            return testObject;
        }

        /// <summary>
        /// Method for getting a different test object
        /// </summary>
        /// <returns>SubCategory Object</returns>
        private SubCategory CreateUpdateTestSubCategory()
        {
            SubCategory testObject = _manager.ConvertToSubCategory("Updated Test SubCategory", 1000, 1000);
            return testObject;
        }
    }
}

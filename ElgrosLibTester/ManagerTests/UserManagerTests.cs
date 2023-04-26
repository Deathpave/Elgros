using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using ElgrosLibTester.Setup;

namespace ElgrosLibTester.ManagerTests
{
    /// <summary>
    /// Testing class for the UserManager's class methods
    /// </summary>
    internal class UserManagerTests
    {
        private IUserManager _manager;

        [SetUp]
        public void Setup()
        {
            var db = SqlConfigurationSetup.SetupDB();
            _manager = new UserManager(db);
        }

        /// <summary>
        /// Tests the CreateAsync method of the UserManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task CreateAsync_CreatesAUser_IfArgumentsAreValid()
        {
            //Arrange
            User testUser = CreateTestUser();

            //Act
            bool result = await _manager.CreateAsync(testUser);

            //Cleanup
            await _manager.DeleteAsync(testUser);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the UserManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task GetByNameAsync_ReturnsAValidUser_IfArgumentsAreValid()
        {
            //Arrange
            User requestedUser;
            User testUser = CreateTestUser();
            await _manager.CreateAsync(testUser);

            //Act
            requestedUser = await _manager.GetByNameAsync(testUser.Username);

            //Cleanup
            await _manager.DeleteAsync(testUser);

            //Assert
            Assert.That(requestedUser.Id, Is.EqualTo(testUser.Id));
            Assert.That(requestedUser.Username, Is.EqualTo(testUser.Username));
            Assert.That(requestedUser.Password, Is.EqualTo(testUser.Password));
        }

        /// <summary>
        /// Tests the UpdateAsync method of the UserManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task UpdateAsync_UpdatesExistingUser_IfArgumentsAreValid()
        {
            //Arrange
            User testUser = CreateTestUser();
            User updatedUser = CreateUpdateTestUser();
            await _manager.CreateAsync(testUser);

            //Act
            var result = await _manager.UpdateAsync(updatedUser);

            //Cleanup
            await _manager.DeleteAsync(updatedUser);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the RemoveObjectAsync method of the UserManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(4)]
        public async Task RemoveObjectAsync_RemovesExistingUser_IfArgumentsAreValid()
        {
            //Arrange
            User testUser = CreateTestUser();
            await _manager.CreateAsync(testUser);

            //Act
            var result = await _manager.DeleteAsync(testUser);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>User Object</returns>
        private User CreateTestUser()
        {
            User testUser = _manager.ConvertToUser("test user", "123", 1000);
            return testUser;
        }

        /// <summary>
        /// Method for getting a different test object
        /// </summary>
        /// <returns>User Object</returns>
        private User CreateUpdateTestUser()
        {
            User testUser = _manager.ConvertToUser("updated test user", "321", 1000);
            return testUser;
        }
    }
}

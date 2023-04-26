using ElgrosLib.DataModels;
using ElgrosLib.Factories;
using ElgrosLib.Interfaces;
using ElgrosLib.Managers;
using ElgrosLibTester.Setup;

namespace ElgrosLibTester.ManagerTests
{
    internal class UserInformationManagerTests
    {
        private IUserInformationManager _manager;
        private IUserManager _UserManager;

        [SetUp]
        public void Setup()
        {
            var db = SqlConfigurationSetup.SetupDB();
            _manager = new UserInformationManager(db);
            _UserManager = new UserManager(db);
        }

                /// <summary>
        /// Tests the CreateAsync method of the UserInformationManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(1)]
        public async Task CreateAsync_CreatesAUserInformation_IfArgumentsAreValid()
        {
            //Arrange
            User user = CreateTestUser();
            UserInformation testUserInformation = CreateTestUserInformation();
            await _UserManager.CreateAsync(user);


            //Act
            bool result = await _manager.CreateAsync(testUserInformation);

            //Cleanup
            await _manager.DeleteAsync(testUserInformation);
            await _UserManager.DeleteAsync(user);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the GetByIdAsync method of the UserInformationManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(2)]
        public async Task GetByIdAsync_ReturnsAValidUserInformation_IfArgumentsAreValid()
        {
            //Arrange
            User user = CreateTestUser();
            UserInformation requestedUserInformation;
            UserInformation testUserInformation = CreateTestUserInformation();
            await _UserManager.CreateAsync(user);
            await _manager.CreateAsync(testUserInformation);

            //Act
            requestedUserInformation = await _manager.GetByIdAsync(testUserInformation.Id);

            //Cleanup
            await _manager.DeleteAsync(testUserInformation);
            await _UserManager.DeleteAsync(user);

            //Assert
            Assert.That(requestedUserInformation.Id, Is.EqualTo(testUserInformation.Id));
            Assert.That(requestedUserInformation.FirstName, Is.EqualTo(testUserInformation.FirstName));
            Assert.That(requestedUserInformation.LastName, Is.EqualTo(testUserInformation.LastName));
            Assert.That(requestedUserInformation.Email, Is.EqualTo(testUserInformation.Email));
            Assert.That(requestedUserInformation.Address, Is.EqualTo(testUserInformation.Address));
            Assert.That(requestedUserInformation.Zipcode, Is.EqualTo(testUserInformation.Zipcode));
            Assert.That(requestedUserInformation.City, Is.EqualTo(testUserInformation.City));
            Assert.That(requestedUserInformation.Phone, Is.EqualTo(testUserInformation.Phone));
        }

        /// <summary>
        /// Tests the UpdateAsync method of the UserInformationManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(3)]
        public async Task UpdateAsync_UpdatesExistingUserInformation_IfArgumentsAreValid()
        {
            //Arrange
            User testUser = CreateTestUser();
            UserInformation testUserInformation = CreateTestUserInformation();
            UserInformation updatedUserInformation = CreateUpdateTestUserInformation();
            await _UserManager.CreateAsync(testUser);
            await _manager.CreateAsync(testUserInformation);

            //Act
            var result = await _manager.UpdateAsync(updatedUserInformation);

            //Cleanup
            await _manager.DeleteAsync(updatedUserInformation);
            await _UserManager.DeleteAsync(testUser);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the RemoveObjectAsync method of the UserInformationManager class
        /// </summary>
        /// <returns></returns>
        [Test]
        [Order(4)]
        public async Task RemoveObjectAsync_RemovesExistingUserInformation_IfArgumentsAreValid()
        {
            //Arrange
            User user = CreateTestUser();
            UserInformation testUserInformation = CreateTestUserInformation();
            await _UserManager.CreateAsync(user);
            await _manager.CreateAsync(testUserInformation);

            //Act
            var result = await _manager.DeleteAsync(testUserInformation);

            //Cleanup
            await _UserManager.DeleteAsync(user);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>UserInformation Object</returns>
        private User CreateTestUser()
        {
            User testObject = UserFactory.CreateUser(1000, "Test User", "123");
            return testObject;
        }

        /// <summary>
        /// Method for making a test object
        /// </summary>
        /// <returns>UserInformation Object</returns>
        private UserInformation CreateTestUserInformation()
        {
            UserInformation testObject = UserInformationFactory.CreateUserInformation(1000, "Test", "Testsen", "Test@Test.com", "TestGade", "4290", "TestBy", "12345678");
            return testObject;
        }

        /// <summary>
        /// Method for getting a different test object
        /// </summary>
        /// <returns>UserInformation Object</returns>
        private UserInformation CreateUpdateTestUserInformation()
        {
            UserInformation testObject = UserInformationFactory.CreateUserInformation(1000, "UpdatedTest", "UpdatedTestsen", "UpdatedTest@Test.com", "UpdatedTestGade", "4290", "UpdatedTestBy", "12345678");
            return testObject;
        }
    }
}

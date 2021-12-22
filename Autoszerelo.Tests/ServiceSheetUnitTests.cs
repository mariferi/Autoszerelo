using Microsoft.VisualStudio.TestTools.UnitTesting;
using Munkafelvevo;

namespace Autoszerelo.Tests
{
    [TestClass]
    public class ServiceSheetUnitTests
    {
        // customerName

        [TestMethod]
        public void IsValidCustomername_WithValidArgument_ReturnTrue()
        {
            //Arrange
            string customerName = "Teszt";
            //Act
            bool result = ServiceSheetWindow.IsValidCustomerName(customerName);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidCustomername_WithEmptyString_ReturnFalse()
        {
            //Arrange
            string empty = "";
            //Act
            bool resultEmpty = ServiceSheetWindow.IsValidCustomerName(empty);
            //Assert
            Assert.IsFalse(resultEmpty);
        }
        [TestMethod]
        public void IsValidCustomername_WithWhiteSpace_ReturnFalse()
        {
            //Arrange
            string whiteSpace = "\t";
            //Act
            bool resultWhiteSpace = ServiceSheetWindow.IsValidCustomerName(whiteSpace);
            //Assert
            Assert.IsFalse(resultWhiteSpace);
        }
        [TestMethod]
        public void IsValidCustomername_WithSpecialCharacter_ReturnFalse()
        {
            //Arrange
            string nameWithSpecialCharacter = "Teszt! Elek";
            //Act
            bool resultWithSpecialCharacter = ServiceSheetWindow.IsValidCustomerName(nameWithSpecialCharacter);
            //Assert
            Assert.IsFalse(resultWithSpecialCharacter);
        }

        // carType

        [TestMethod]
        public void IsValidCarType_WithValidArgument_ReturnTrue()
        {
            //Arrange
            string carType = "Volkswagen";
            //Act
            bool result = ServiceSheetWindow.IsValidCarType(carType);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidCarType_WithEmptyString_ReturnFalse()
        {
            //Arrange
            string empty = "";
            //Act
            bool resultEmpty = ServiceSheetWindow.IsValidCarType(empty);
            //Assert
            Assert.IsFalse(resultEmpty);
        }

        [TestMethod]
        public void IsValidCarType_WithWhiteSpace_ReturnFalse()
        {
            //Arrange
            string whiteSpace = "\t";
            //Act
            bool resultWhiteSpace = ServiceSheetWindow.IsValidCarType(whiteSpace);
            //Assert
            Assert.IsFalse(resultWhiteSpace);
        }
        [TestMethod]
        public void IsValidCarType_WithSpecialCharacter_ReturnFalse()
        {
            //Arrange
            string carTypeWithSpecialCharacter = "Volkswagen*";
            //Act
            bool resultWithSpecialCharacter = ServiceSheetWindow.IsValidCarType(carTypeWithSpecialCharacter);
            //Assert
            Assert.IsFalse(resultWithSpecialCharacter);
        }

        // licensePlate
        [TestMethod]
        public void IsValidLicensePlate_WithValidArgument_ReturnTrue()
        {
            //Arrange
            string licensePlate = "AEN-333";
            //Act
            bool result = ServiceSheetWindow.IsValidLicensePlate(licensePlate);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IsValidLicensePlate_WithEmptyString_ReturnFalse()
        {
            //Arrange
            string empty = "";
            //Act
            bool resultEmpty = ServiceSheetWindow.IsValidLicensePlate(empty);
            //Assert
            Assert.IsFalse(resultEmpty);
        }
        [TestMethod]
        public void IsValidLicensePlate_WithInvalidArgument_ReturnFalse()
        {
            //Arrange
            string s1 = "XXX000";
            string s2 = "XX-0000";
            string s3 = "000-XXX";
            string s4 = "000-000";
            string s5 = "X-XX000";
            //Act
            bool r1 = ServiceSheetWindow.IsValidLicensePlate(s1);
            bool r2 = ServiceSheetWindow.IsValidLicensePlate(s2);
            bool r3 = ServiceSheetWindow.IsValidLicensePlate(s3);
            bool r4 = ServiceSheetWindow.IsValidLicensePlate(s4);
            bool r5 = ServiceSheetWindow.IsValidLicensePlate(s5);
            //Assert
            Assert.IsFalse(r1);
            Assert.IsFalse(r2);
            Assert.IsFalse(r3);
            Assert.IsFalse(r4);
            Assert.IsFalse(r5);
        }

    }
}
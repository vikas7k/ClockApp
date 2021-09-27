using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppServices;
namespace AppServicesTest
{
    [TestClass]
    public class ValidationServiceTests
    {
        [TestMethod]
        public void ValidationService_Is_Time_Valid()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("11:20", out message);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidationService_Is_Time_InValid()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("ABCD", out message);
            Assert.AreEqual(false, result);
            Assert.AreEqual("Invalid Time Format- Use HH:MM", message);
        }

        [TestMethod]
        public void ValidationService_Is_Time_Hour_InValid()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("AB:23", out message);
            Assert.AreEqual(false, result); 
            Assert.AreEqual("Invalid Hours", message);
        }

        [TestMethod]
        public void ValidationService_Is_Time_Hour_Out_Of_Range()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("60:23", out message);
            Assert.AreEqual(false, result);
            Assert.AreEqual("Hours out of range of 0 to 23", message);
        }

        [TestMethod]
        public void ValidationService_Is_Time_Minutes_InValid()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("11:AB", out message);
            Assert.AreEqual(false, result);
            Assert.AreEqual("Invalid Minutes", message);
        }

        [TestMethod]
        public void ValidationService_Is_Time_Minutes_Out_Of_Range()
        {
            var validationService = new ValidationService();
            var message = string.Empty;
            var result = validationService.IsTimeValid("11:93", out message);
            Assert.AreEqual(false, result);
            Assert.AreEqual("Minutes out of range of 0 to 59", message);
        }
    }
}

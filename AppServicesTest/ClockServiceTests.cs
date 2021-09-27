using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppServices;
namespace AppServicesTest
{
    [TestClass]
    public class ClockServiceTests
    {
        [TestMethod]
        public void ClockServiceTests_Is_Time_Correct()
        {
            var clockService = new ClockService();
            var result = clockService.getTimeText("1:00");
            Assert.AreEqual("One o' clock ",result);
        }

        [TestMethod]
        public void ClockServiceTests_Is_Time_Quater_Past_Correct()
        {
            var clockService = new ClockService();
            var result = clockService.getTimeText("11:15");
            Assert.AreEqual("Quarter Past Eleven", result);
        }


        [TestMethod]
        public void ClockServiceTests_Is_Time_Half_Past_Correct()
        {
            var clockService = new ClockService();
            var result = clockService.getTimeText("12:30");
            Assert.AreEqual("Half Past Twelve", result);
        }

        [TestMethod]
        public void ClockServiceTests_Is_Time_Past_Correct()
        {
            var clockService = new ClockService();
            var result = clockService.getTimeText("5:11");
            Assert.AreEqual("Eleven Past Five", result);
        }

        [TestMethod]
        public void ClockServiceTests_Is_Time_To_Correct()
        {
            var clockService = new ClockService();
            var result = clockService.getTimeText("4:50");
            Assert.AreEqual("Ten To Five", result);
        }

        [TestMethod]
        public void ClockServiceTests_Is_Current_Time_Available()
        {
            var clockService = new ClockService();
            var result = clockService.getCurrentTimeText();
            Assert.IsNotNull(result);
        }
    }
}

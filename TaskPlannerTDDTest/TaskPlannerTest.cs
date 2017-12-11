//using NUnit.Framework;
//using System;

//namespace TaskPlanner
//{

//    [TestFixture]
//    public class TaskPlannerTest
//    {
//        private TaskPlanner _tut;


//        [SetUp]
//        public void setup()
//        {
//            _tut = new TaskPlanner();
//        }


//        [Test]
//        public void OnStartAndDurationEnter_withDateAndTime_ShouldReturnEndDate()
//        {


//            //Arrange
//            DateTime startDate = new DateTime(2004, 05, 24, 18, 05, 00);
//            double days = -5.5;

//            //Arrange1
//            DateTime startDate1 = new DateTime(2004, 05, 24, 19, 03, 00);
//            double days1 = 44.723656;

//            //Arrange2
//            DateTime startDate2 = new DateTime(2004, 05, 24, 18, 03, 00);
//            double days2 = -6.7470217;

//            //Arrange3
//            DateTime startDate3 = new DateTime(2004, 05, 24, 08, 03, 00);
//            double days3 = 12.782709;

//            //Arrange4
//            DateTime startDate4 = new DateTime(2004, 05, 24, 07, 03, 00);
//            double days4 = 8.276628;



//            //Test2
//            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
//            DateTime expected = new DateTime(2004, 05, 14, 12, 00, 00);

//            //Test3
//            DateTime result1 = _tut.GetTaskFinishingDate(startDate1, days1);
//            DateTime expected1 = new DateTime(2004, 07, 27, 13, 47, 00);

//            //Test4
//            DateTime result2 = _tut.GetTaskFinishingDate(startDate2, days2);
//            DateTime expected2 = new DateTime(2004, 05, 13, 10, 02, 00);

//            //Test5
//            DateTime result3 = _tut.GetTaskFinishingDate(startDate3, days3);
//            DateTime expected3 = new DateTime(2004, 06, 10, 14, 18, 00);

//            //Test6
//            DateTime result4 = _tut.GetTaskFinishingDate(startDate4, days4);
//            DateTime expected4 = new DateTime(2004, 06, 04, 07, 03, 00);


//            Assert.AreEqual(expected, result);
//            Assert.AreEqual(expected1, result1);
//            Assert.AreEqual(expected2, result2);
//            Assert.AreEqual(expected3, result3);
//            Assert.AreEqual(expected4, result4);


//            // Assert.Inconclusive();

//        }

//    }
//}

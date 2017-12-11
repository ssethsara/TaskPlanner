using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TaskPlanner.Tests
{
    [TestClass]
    public class TaskPlannerTest
    {

        private ITaskPlanner _tut;

        [TestInitialize]
        public void TestSetUp()
        {
            _tut = new TaskPlanner();

            _tut.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));

            _tut.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            // _tut.SetRecurringHoliday(new DateTime(2004, 5, 24, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));
        }


        //Test For GetTaskFinishingDate() Method

   

        [TestMethod]
        public void Assignment_Test1_Minus()
        {

            // Test1

            DateTime startDate = new DateTime(2004, 05, 24, 18, 05, 0);
            double days = -5.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2004, 05, 14, 12, 00, 0);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void Assignment_Test2_Plus()
        {

            //Test2

            DateTime startDate1 = new DateTime(2004, 05, 24, 19, 03, 0);
            double days1 = 44.723656;

            DateTime result1 = _tut.GetTaskFinishingDate(startDate1, days1);
            DateTime expected1 = new DateTime(2004, 07, 27, 13, 47, 0);

            Assert.AreEqual(expected1, result1);


        }


        [TestMethod]
        public void Assignment_Test3_Minus()
        {

            //Test3

            DateTime startDate2 = new DateTime(2004, 05, 24, 18, 03, 0);
            double days2 = -6.7470217;

            DateTime result2 = _tut.GetTaskFinishingDate(startDate2, days2);
            DateTime expected2 = new DateTime(2004, 05, 13, 10, 01, 0);

            Assert.AreEqual(expected2, result2);


        }

        [TestMethod]
        public void Assignment_Test4_Plus()
        {

            //Test4

            DateTime startDate3 = new DateTime(2004, 05, 24, 08, 03, 0);
            double days3 = 12.782709;

            DateTime result3 = _tut.GetTaskFinishingDate(startDate3, days3);
            DateTime expected3 = new DateTime(2004, 06, 10, 14, 18, 0);

            Assert.AreEqual(expected3, result3);


        }

        [TestMethod]
        public void Assignment_Test5_Plus()
        {

            //Test5

            DateTime startDate4 = new DateTime(2004, 05, 24, 07, 03, 0);
            double days4 = 8.276628;

            DateTime result4 = _tut.GetTaskFinishingDate(startDate4, days4);
            DateTime expected4 = new DateTime(2004, 06, 04, 10, 12, 0);

            Assert.AreEqual(expected4, result4);


        }

        [TestMethod]
        public void Assignment_Test6_Minus()
        {

            //Test6

            var startDate5 = new DateTime(2004, 5, 24, 18, 3, 0);
            double days5 = -6.7470217;

            DateTime result5 = _tut.GetTaskFinishingDate(startDate5, days5);
            DateTime expected5 = new DateTime(2004, 5, 13, 10, 1, 0);

            Assert.AreEqual(expected5, result5);


        }





        [TestMethod]
        public void OnStartAndDurationEnter_withPlusDays_ShouldReturnEndDate2()
        {
            
            _tut.SetRecurringHoliday(new DateTime(2017, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            
            DateTime startDate = new DateTime(2017, 12, 4,8, 00, 0);
            double days = 2;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017,12, 5, 16, 00, 0);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withPlusDays_ShouldReturnEndDate3()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 01, 08, 00, 00);
            double days = 2;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 04, 16, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withPlusDays_ShouldReturnEndDate4()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 01, 12, 00, 00);
            double days = 6;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 13, 12, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withPlusDays_ShouldReturnEndDate5()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 08, 00, 00);
            double days = 2;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 12, 16, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withMinusDays_ShouldReturnEndDate_1()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 08, 00, 00);
            double days = -2;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 05, 8, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withMinusDays_ShouldReturnEndDate_2()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 08, 00, 00);
            double days = -2.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 04, 12, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withNoDays_ShouldReturnEndDate()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 08, 00, 00);
            double days = 0;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 08, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withHoursOnly_ShouldReturnEndDate()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 11, 14, 00, 00);
            double days = 0.25;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 11, 16, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withHoursOnly_ShouldReturnEndDate_2()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 11, 14, 00, 00);
            double days = 0.125;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 11, 15, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withPlusDaysAndTwoHolidays_ShouldReturnEndDate3()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 05, 16, 00, 00);
            double days = 1;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 16, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withMinusDaysAndTwoHolidays_ShouldReturnEndDate3()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 16, 00, 00);
            double days = -1;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 08, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withMinusDaysAndTwoHolidays_ShouldReturnEndDate_3()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 08, 00, 00);
            double days = -1;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 05, 08, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withMinusHoursOnly_ShouldReturnEndDate()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 12, 00, 00);
            double days = -0.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 08, 00, 00);

            Assert.AreEqual(expected, result);


        }


        [TestMethod]
        public void OnStartAndDurationEnter_withMinusHoursOnly_ShouldReturnEndDate_2()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 10, 00, 00);
            double days = -0.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 05, 14, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withPlusHoursOnly_ShouldReturnEndDate()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 12, 00, 00);
            double days = 0.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 16, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withPlusHoursOnly_ShouldReturnEndDate_2()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 08, 14, 00, 00);
            double days = 0.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 09, 10, 00, 00);

            Assert.AreEqual(expected, result);


        }

        [TestMethod]
        public void OnStartAndDurationEnter_withPlusHoursAndTwoVacations_ShouldReturnEndDate()
        {

            _tut.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            _tut.SetHoliday(new DateTime(2017, 12, 6, 0, 0, 0));
            _tut.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            DateTime startDate = new DateTime(2017, 12, 05, 14, 00, 00);
            double days = 0.5;

            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 08, 10, 00, 00);

            Assert.AreEqual(expected, result);


        }

    }
}

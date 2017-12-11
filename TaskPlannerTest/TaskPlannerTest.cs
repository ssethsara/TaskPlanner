using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner.Test
{


    [TestFixture]
    public class TaskPlannerTest
    {
        private TaskPlanner _tut;


        [SetUp]
        public void setup()
        {
            _tut = new TaskPlanner();
        }


        [Test]
        public void OnStartAndDurationEnter_withDateAndTime_ShouldReturnEndDate()
        {


            //Arrange
            DateTime startDate = new DateTime(2017, 12, 6, 12, 30, 00);
            double days = 3;

            //Act
            DateTime result = _tut.GetTaskFinishingDate(startDate, days);
            DateTime expected = new DateTime(2017, 12, 11, 12, 30, 00);

            Assert.AreEqual(expected, result);


            // Assert.Inconclusive();

        }

    }
}

using System;

namespace TaskPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TaskPlanner taskPlanner = new TaskPlanner();


            taskPlanner.SetWorkdayStartAndStop(new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 12, 11, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2017, 12, 06, 0, 0, 0));
            taskPlanner.SetRecurringHoliday(new DateTime(2004, 12, 7, 0, 0, 0));

            taskPlanner.SetRecurringHoliday(new DateTime(2004, 5, 17, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 27, 0, 0, 0));
            taskPlanner.SetHoliday(new DateTime(2004, 5, 21, 0, 0, 0));
            // Arrange
            var startDate = new DateTime(2017, 12, 05, 14, 00, 00);
            double days = 0.5;




            Console.WriteLine("end: {0:f}", taskPlanner.GetTaskFinishingDate(startDate,days));
           

            Console.ReadLine();
        }
    }
}

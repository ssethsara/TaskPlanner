using System;
using System.Collections.Generic;
using System.Text;

namespace TaskPlanner
{
   public class TaskPlanner:ITaskPlanner
    {
        IList<DateTime> Holidays = new List<DateTime>();
        IList<DateTime> RecurringHolidays = new List<DateTime>();

        private TimeSpan startTime;
        private TimeSpan stopTime;

        public void SetWorkdayStartAndStop(TimeSpan startTime, TimeSpan stopTime)
        {
            this.startTime = startTime;
            this.stopTime = stopTime;
        }

        public void SetHoliday(DateTime date)
        {
            Holidays.Add(date);
        }

        public void SetRecurringHoliday(DateTime dateTime)
        {
            RecurringHolidays.Add(dateTime);
        }


        public DateTime GetTaskFinishingDate(DateTime startDate, double days)
        {

            Console.WriteLine("start: {0:f}", startDate);
            Console.WriteLine("Add "+ days);

            DateTime CalculatedDate = new DateTime();
            double decimalPartOfday;

            CalculatedDate = startDate;
            decimalPartOfday = days%1 ;

            CalculatedDate = CountTime(CalculatedDate, decimalPartOfday , days);
            CalculatedDate = CountDays(CalculatedDate, days);
          
            Console.WriteLine("end: {0:f}", CalculatedDate);

            return CalculatedDate;
        }

        bool CheckHolidays(DateTime CalculatedDate)
        {
            foreach (DateTime holiday in Holidays)
            {
                if (DateTime.Equals(CalculatedDate.Date, holiday.Date))
                {
                    return true;
                }

            }
            foreach (DateTime RecurringHoliday in RecurringHolidays)
            {
                if (RecurringHoliday.Month == CalculatedDate.Month && RecurringHoliday.Day == CalculatedDate.Day)
                { 
                     return true;
                }
            }
           
            return false;
        }

        DateTime CountDays(DateTime date,double estimatedDays)
        {
            int days = (int)estimatedDays;
            DateTime endDate= date;
            DateTime loopingDate = date;


            if (estimatedDays >= 0)
            {


                if (estimatedDays < 1)
                {
                    loopingDate = loopingDate.AddDays(-1);
                }
                else
                {
                    endDate = endDate.AddDays(days);
                }
                while (!DateTime.Equals(loopingDate, endDate))
                {
                    loopingDate = loopingDate.AddDays(1);
                    
                    if (CheckHolidaysAndWeekDays(loopingDate))
                    {
                        endDate=endDate.AddDays(1);
                    }
                }
                
            }
            else if (estimatedDays < 0)
            {
                if (days == 0)
                {
                    endDate = endDate.AddDays(-1);
                }
                else
                {
                    endDate = endDate.AddDays(days);
                }
                while (!DateTime.Equals(loopingDate, endDate))
                {
                    loopingDate = loopingDate.AddDays(-1);

                    if (CheckHolidaysAndWeekDays(loopingDate))
                    {
                        endDate=endDate.AddDays(-1);
                    }
                   
                    
                }
            }
            return endDate;
        }


        DateTime CountTime(DateTime calculatedDate,double decimalPartOfday,double estimatedDays)
        {
            TimeSpan Workingduration = stopTime - startTime;
            TimeSpan timeDuration;
            TimeSpan wholeTime;

            timeDuration = Workingduration * decimalPartOfday;

            int days = (int)estimatedDays;

            if (estimatedDays > 0)
            {
                if (CheckHolidays(calculatedDate))
                {
                    wholeTime = startTime + timeDuration;
                    calculatedDate = calculatedDate.AddDays(1);
                }
                else if (calculatedDate.TimeOfDay>startTime && calculatedDate.TimeOfDay< stopTime)
                {
                    wholeTime = calculatedDate.TimeOfDay + timeDuration;

                }
                else if (calculatedDate.TimeOfDay<=startTime)
                {
                    wholeTime = stopTime + timeDuration;
                    calculatedDate = calculatedDate.AddDays(-1);
                }
                else if (calculatedDate.TimeOfDay > stopTime)
                {
                    calculatedDate = calculatedDate.AddDays(1);
                    wholeTime = startTime + timeDuration; 
                }
                else if (calculatedDate.TimeOfDay == stopTime)
                {
                    wholeTime = stopTime + timeDuration;
                }
            }
            else
            {
                if (CheckHolidays(calculatedDate))
                {
                    wholeTime = stopTime + timeDuration;
                }
                else if (calculatedDate.TimeOfDay > startTime && calculatedDate.TimeOfDay< stopTime)
                {
                    wholeTime = calculatedDate.TimeOfDay + timeDuration;
                }
                else if (calculatedDate.TimeOfDay <= startTime && decimalPartOfday!=0)
                {
                    wholeTime = stopTime + timeDuration;
                    calculatedDate = calculatedDate.AddDays(-1);
                }
                else if (calculatedDate.TimeOfDay == startTime && decimalPartOfday == 0)
                {
                    wholeTime = startTime + timeDuration;
                }
                else if (calculatedDate.TimeOfDay > stopTime)
                {
                    wholeTime = stopTime + timeDuration;

                }
                else if (calculatedDate.TimeOfDay == stopTime && decimalPartOfday == 0)
                {
                    wholeTime = startTime - timeDuration;
                    calculatedDate = calculatedDate.AddDays(1);

                }
            }

            return SplitTime(calculatedDate, wholeTime, estimatedDays, decimalPartOfday);

        }

        bool CheckHolidaysAndWeekDays(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || CheckHolidays(date))
                return true;
            else
                return false;


        }


        DateTime SplitTime(DateTime calculatedDate,TimeSpan wholeTime,double estimatedDays,double decimalPartOfday)
        {

            TimeSpan endTime;
            if (estimatedDays >= 0)
            {
                if (wholeTime < startTime)
                {
                    TimeSpan splitTime = startTime - wholeTime;
                    endTime = stopTime - splitTime;
                }
                else if (wholeTime > stopTime)
                {
                    TimeSpan splitTime = wholeTime - stopTime;
                    endTime = startTime + splitTime;
                    calculatedDate = calculatedDate.AddDays(1);
                }
                else
                {
                    endTime = wholeTime;
                }
            }
            else
            {
                if (wholeTime < startTime)
                {
                    TimeSpan splitTime = startTime - wholeTime;
                    endTime = stopTime - splitTime;
                    calculatedDate = calculatedDate.AddDays(-1);
                }
                else if (wholeTime > stopTime)
                {
                    endTime = stopTime;
                }
                else if (wholeTime == startTime && decimalPartOfday < 0)
                {
                    endTime = wholeTime;
                    calculatedDate = calculatedDate.AddDays(1);
                }
                else
                {
                    endTime = wholeTime;
                }
 
            }
            return new DateTime(calculatedDate.Year, calculatedDate.Month, calculatedDate.Day, endTime.Hours, endTime.Minutes, 00);

        }

    }
}


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


            CalculatedDate = countTime(CalculatedDate, decimalPartOfday , days);
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
            DateTime loopinDate = date;


            if (estimatedDays >= 0)
            {
                
                    endDate = endDate.AddDays(days);
                

                while (!DateTime.Equals(loopinDate, endDate))
                {
                    loopinDate = loopinDate.AddDays(1);

                    if (loopinDate.DayOfWeek == DayOfWeek.Saturday || loopinDate.DayOfWeek == DayOfWeek.Sunday || CheckHolidays(loopinDate))
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
                
             
                

                while (!DateTime.Equals(loopinDate, endDate))
                {
                    loopinDate = loopinDate.AddDays(-1);

                    if (loopinDate.DayOfWeek == DayOfWeek.Saturday || loopinDate.DayOfWeek == DayOfWeek.Sunday || CheckHolidays(loopinDate))
                    {
                        endDate=endDate.AddDays(-1);
                    }
                   
                    
                }
            }
            return endDate;
        }


        DateTime countTime(DateTime CalculatedDate,double decimalPartOfday,double estimatedDays)
        {
            TimeSpan Workingduration = stopTime - startTime;
            TimeSpan timeDuration;
            TimeSpan wholeTime;
            TimeSpan endTime;

            timeDuration = Workingduration * decimalPartOfday;







            int days = (int)estimatedDays;

            

            if (estimatedDays > 0)
            {
                


                if(CalculatedDate.TimeOfDay>startTime && CalculatedDate.TimeOfDay< stopTime)
                {
                    wholeTime = CalculatedDate.TimeOfDay + timeDuration;
                }
                else if (CalculatedDate.TimeOfDay<=startTime)
                {
                    wholeTime = stopTime + timeDuration;
                    CalculatedDate = CalculatedDate.AddDays(-1);
                }
                else if (CalculatedDate.TimeOfDay > stopTime)
                {
                    CalculatedDate = CalculatedDate.AddDays(1);
                    wholeTime = startTime + timeDuration; 
                }
                else if (CalculatedDate.TimeOfDay == stopTime)
                {
                    wholeTime = stopTime + timeDuration;
                }




            }
            else
            {
                if (CalculatedDate.TimeOfDay > startTime && CalculatedDate.TimeOfDay< stopTime)
                {
                    wholeTime = CalculatedDate.TimeOfDay + timeDuration;
                }
                else if (CalculatedDate.TimeOfDay <= startTime && decimalPartOfday!=0)
                {
                    wholeTime = stopTime + timeDuration;
                    CalculatedDate = CalculatedDate.AddDays(-1);
                }
                else if (CalculatedDate.TimeOfDay == startTime && decimalPartOfday == 0)
                {
                    wholeTime = startTime + timeDuration;
                }
                else if (CalculatedDate.TimeOfDay > stopTime)
                {
                    wholeTime = stopTime + timeDuration;

                }
                else if (CalculatedDate.TimeOfDay == stopTime && decimalPartOfday == 0)
                {
                    wholeTime = startTime - timeDuration;
                    CalculatedDate = CalculatedDate.AddDays(1);

                }
            }



            if (estimatedDays >= 0)
            {
                if (wholeTime < startTime)
                {
                    TimeSpan splitTime = startTime - wholeTime;
                    endTime = stopTime- splitTime;
                }
                else if (wholeTime > stopTime)
                {
                    TimeSpan splitTime = wholeTime - stopTime;
                    endTime = startTime + splitTime;
                    CalculatedDate = CalculatedDate.AddDays(1);
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
                    CalculatedDate = CalculatedDate.AddDays(-1);
                }
                else if (wholeTime > stopTime)
                {
                    endTime = stopTime;
                }
                else if (wholeTime == startTime && decimalPartOfday<0)
                {
                    endTime = wholeTime;
                    CalculatedDate = CalculatedDate.AddDays(1);
                }
                else
                {
                    endTime = wholeTime;
                }


            }




                return new DateTime(CalculatedDate.Year, CalculatedDate.Month, CalculatedDate.Day, endTime.Hours, endTime.Minutes, 00);


        }

    }
}


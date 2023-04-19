using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob) {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dob.Year;
            //if they haven't had their birthday yet this year
            //then remove a year from 'age'
            if(dob > today.AddYears(-age)) age--;

            return age;
            //Note, we haven't accounted for leap years and such.
            //Probably won't get more robust than this.
        }
    }
}
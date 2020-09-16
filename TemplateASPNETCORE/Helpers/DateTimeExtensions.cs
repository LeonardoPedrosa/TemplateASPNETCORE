using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repository.Helpers
{
  //DATETIME EXTENSIONS
  public static class DateTimeExtensions
  {
    //this method uses a date to get years so far
    public static int GetCurrentYears(this DateTime date)
    {
      var currentDate = DateTime.UtcNow;
      int years = currentDate.Year - date.Year;

      if (currentDate < date.AddYears(years))
        years--;

      return years;
    }
  }
}

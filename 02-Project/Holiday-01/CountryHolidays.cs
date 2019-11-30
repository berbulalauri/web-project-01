using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using workshop2.Helpers;

namespace workshop2
{
    public class CountryHolidays
    {
        public static string NameFromApi { get; set; }
        public static string CountryCodeFromApi { get; set; }
        public static string DateFromApi { get; set; }
        public static string FixedFromApi { get; set; }
        public static string GlobalFromApi { get; set; }
        public static string LaunchYearFromApi { get; set; }
        public CountryHolidays() {  }

        public override string ToString()
        {
            return $"Name: {NameFromApi} \n " +
                $"CountryCode: {CountryCodeFromApi} \n " +
                $"Date: {DateFromApi} \n " +
                $"Is Fixed or Not: {FixedFromApi} \n ";
        }
        public async static Task<bool> GenerateNewCountryHoliday(string name)
        {
            var nameResult = await ApiForCountryHoliday.GetHolidayAsync(name);
            try
            {
                if (nameResult.Count != 0)
                {
                    Console.WriteLine("|{0,33}|{1,12}|{2,13}|{3,8}|{4,8}|{5,11}|", "Name", "Country Code", "Date", "Fixed", "Global", "Launch Year");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    for (int i = 1; i <= nameResult.Count; i++)
                    {
                        NameFromApi = nameResult[i].Item1;
                        CountryCodeFromApi = nameResult[i].Item2;
                        DateFromApi = nameResult[i].Item3;
                        FixedFromApi = nameResult[i].Item4;
                        GlobalFromApi = nameResult[i].Item5;
                        LaunchYearFromApi = nameResult[i].Item6;
                        Console.WriteLine(String.Format("|{0,33}|{1,12}|{2,13}|{3,8}|{4,8}|{5,11}|", NameFromApi, CountryCodeFromApi, DateFromApi, FixedFromApi, GlobalFromApi, LaunchYearFromApi));
                    }
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    return true;
                } 
                else if (nameResult.Count == 0)  
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Goes Wring! " + ex.Message);
                //throw;
            }

            return false;
        }

    }
}


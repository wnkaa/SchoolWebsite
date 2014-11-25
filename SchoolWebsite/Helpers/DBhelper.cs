using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWebsite.Models;
namespace SchoolWebsite.Helpers
{
    public static class DBhelper
    {
        public static HashSet<int> assignedPrzedmiots(Course course)
        {
            HashSet<int> sprawdzone = new HashSet<int>();
            foreach (var item in course.Przedmioty)
            {
                sprawdzone.Add(item.PrzedmiotID);
            }
            return sprawdzone;
        }
        public static HashSet<int> assignedLectors(Course course)
        {
            HashSet<int> sprawdzone = new HashSet<int>();
            foreach (var item in course.Lectors)
            {
                sprawdzone.Add(item.LectorID);
            }
            return sprawdzone;
        }
    }
}
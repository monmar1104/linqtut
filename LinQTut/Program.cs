using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinQTut
{
    class Program
    {
        static void Main(string[] args)
        {

            ////GroupJoin
            //var countries = Country.GetAllCountries().GroupJoin(
                                          //City.GetAllCities(),
                                          //co => co.Id,
                                          //ci => ci.CountryId,
                                          //(country, city) => new
                                          //{
                                          //    Country = country,
                                          //    Cities = city
                                          //      .GroupJoin(
                                          //      Student.GetAllStudents(),
                                          //      c => c.Id,
                                          //      s => s.CityId,
                                          //      (ci, student) => new
                                          //      {
                                          //          City = ci,
                                          //          Students = student
                                          //      })
                                          //});

            //GroupJoin
            var students = from co in Country.GetAllCountries()
                           join ci in City.GetAllCities()
                           on co.Id equals ci.CountryId
                           join st in Student.GetAllStudents()
                           on ci.Id equals st.CityId into stGroup
                           select new
                           {
                               Country = co,
                               City = ci.Name,
                               Students = stGroup
                           };

            ////InnerJoin
            //var students = from co in Country.GetAllCountries()
            //join ci in City.GetAllCities()
            //on co.Id equals ci.CountryId
            //join st in Student.GetAllStudents()
            //on ci.Id equals st.CityId 
            //select new
            //{
            //    Country = co,
            //    City = ci.Name,
            //    Students = st.Name
            //};


            foreach (var c in students)
            {
                Console.WriteLine(c.Country.Name + " " + c.City);
                foreach (var s in c.Students)
                {
                    Console.WriteLine("\t\t" + s.Name);
                }

                Console.WriteLine();
            }


            ////LeftJoin
            //var result = from s in Student.GetAllStudents()
            //join ci in City.GetAllCities()
            //on s.CityId equals ci.Id into sGroup
            //from ci in sGroup.DefaultIfEmpty()
            //select new
            //{
            //    Student = s.Name,
            //    City = ci == null ? "null" : ci.Name

            //};

            //LeftJoin - LINQ
            var result = Student.GetAllStudents()
                                .GroupJoin(City.GetAllCities(),
                                            st => st.CityId,
                                            c => c.Id,
                                            (student, city) => new
                                            {
                                                Student = student,
                                                City = city
                                            }
                                )
                                .SelectMany(c => c.City.DefaultIfEmpty(),
                                (a, b) => new
                                        {
                                            Student = a.Student.Name,
                                            City = b == null ? "null" : b.Name
                                        }
                        );

                

            foreach(var st in result)
            {
                Console.WriteLine( "{0} - {1}", st.Student, st.City);
            }



            var avgSt = from co in Country.GetAllCountries()
                           join ci in City.GetAllCities()
                           on co.Id equals ci.CountryId
                           join st in Student.GetAllStudents()
                           on ci.Id equals st.CityId into stGroup
                           select new
                           {
                               Country = co.Name,
                               City = ci.Name,
                               Count = stGroup.Count(),
                               Avg = stGroup.Sum((arg) => arg.TotalMarks)

                           };

            foreach(var s in avgSt)
            {
                Console.WriteLine(s);
            }
        }
    }
}

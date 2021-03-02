using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentOneMethod.Models
{
    public class MockData
    {
        public static IEnumerable<Student> GetItemTest()
        {
            var _students = new List<Student>()
            {
                new Student()
                    {
                        id = 70,
                        CIN = "HA18887",
                        FName = "Imad",
                        LName = "Elber",
                        Address = "Dis. alqods"
                    },
                new Student()
                    {
                        id = 71,
                        CIN = "HA188",
                        FName = "Samado",
                        LName = "Massif",
                        Address = "Casa"
                    },
                new Student()
                    {
                        id = 73,
                        CIN = "HA1866",
                        FName = "Nadifi",
                        LName = "Fayz",
                        Address = "Raya"
                    }
            };

            return _students;
        }
    }
}

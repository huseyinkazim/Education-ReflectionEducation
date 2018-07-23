using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var personType = Type.GetType("Reflection.Person");

            var personProperties = personType.GetProperties();

            var nameProperty = personType.GetProperty("Name");
            var lastNameProperty = personType.GetProperty("LastName");

            var personInst = Activator.CreateInstance(personType);
            nameProperty.SetValue(personInst, "Call is Life");
            lastNameProperty.SetValue(personInst, "Call is life 's LastName");

            personProperties[1].SetValue(personInst, "Call is Life");
            personProperties[2].SetValue(personInst, "Call is life 's LastName");

            var personMethods = personType.GetMethods();

            var methodTest = personType.GetMethod("methodTest");
            var getFullName = personType.GetMethod("getFullName");
            
            methodTest.Invoke(personInst, null);
            var personFullName = getFullName.Invoke(personInst, null);

            Console.WriteLine($"Person's fullname is {getFullName.Invoke(personInst, null)}");

            personMethods[6].Invoke(personInst, null);//testMethod
            Console.WriteLine($"Person's fullname is {personMethods[7].Invoke(personInst, null)}");//getFullName


            Console.ReadKey();
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public void methodTest() { Console.WriteLine("Method test is successfully runned."); }
        public string getFullName() { return $"{Name} {LastName}"; }
    }
}

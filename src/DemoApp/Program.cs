using ICS.Domain.Data.Adapters;
using ICS.Domain.Entities;
using System;
using System.IO;
using System.Linq;

namespace DemoApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            File.Move(" ", " ");

            var ttt = typeof(Program).GetMethod("Test").GetCustomAttributes(typeof(TestAttribute), false);

            var domainContext = new DomainContext("Host=localhost;Port=5433;Username=postgres;Password=47H8Ms5a;Database=postgres;Pooling=true;");

            var test1 = domainContext.Set<Invitation>().ToArray();
            var test2 = domainContext.Set<Passport>().ToArray();
            var test3 = domainContext.Set<Document>().ToArray();
            var test4 = domainContext.Set<Contact>().ToArray();
            var test5 = domainContext.Set<Alien>().ToArray();
            var test6 = domainContext.Set<Employee>().ToArray();
            var test8 = domainContext.Set<Organization>().ToArray();
            var test9 = domainContext.Set<StateRegistration>().ToArray();
            var test10 = domainContext.Set<VisitDetail>().ToArray();
            var testError = domainContext.Set<ForeignParticipant>().ToArray();


           /* var invitation2 = domainContext.Set<Invitation>().Where(i => i.Status == InvitationStatus.Sending)
                .Include("Alien")
                //.Include("VisitDetail")
                //.Include("Employee")
                .ToList();

            var invitation3 = domainContext.Set<Invitation>().Where(i => i.Status == InvitationStatus.Sending)
                .Include(i => i.Alien)
                .Include(i => i.VisitDetail)
                //.Include("Employee")
                .ToList();*/

            Console.ReadKey();
            return;
        }

        [Test(Name = "TEST")]
        private void Test()
        {

        }

        public class TestAttribute : Attribute
        {
            public string Name { get; set; }
        }
    }
}

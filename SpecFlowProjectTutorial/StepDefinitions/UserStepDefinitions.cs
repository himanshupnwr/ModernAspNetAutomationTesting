using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;

namespace SpecFlowProjectTutorial.StepDefinitions
{
    [Binding]
    internal class UserStepDefinitions
    {
        [Given(@"I enter random user data")]
        public void GivenIEnterRandomUserData()
        {
            //var person = new Fixture().Create<User>();
            var person = new Fixture()
                .Build<User>()
                .With(x => x.Email, "karthik@techgeek.co.in")
                .Create();
            Console.WriteLine($"The User {person.Name} has email {person.Email}" +
                              $"and his address {person.Address} with his phone {person.Phone}");
        }
    }

    public record User
    {
        public string Name { get; init; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }
}

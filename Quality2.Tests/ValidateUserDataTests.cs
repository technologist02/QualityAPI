using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quality2.Entities;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.ViewModels;
using System.Xml.Linq;

namespace Quality2.Tests
{
    [TestFixture]
    public class ValidateUserDataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("dima", "dima@mail.ru", "dima", "imba")]
        [TestCase("lolpro123", "lolpro@mail.ru", "dmitry", "ivanov")]
        public void ValidateUser(string Login, string Email, string Name, string Surname)
        {
            var userReg = new UserRegisterView { Name = Name, Email = Email, Login = Login, Surname = Surname };
            var user = new User { Name = Name, Email = Email, Login = Login, Surname = Surname };
            Assert.DoesNotThrow(user.Validate);
            Assert.DoesNotThrow(userReg.Validate);
        }

        [TestCase("dima", "dima@mai", "123", "imba", 2)]
        [TestCase("dima", "dima@mail.ru", "123", "imba", 1)]
        [TestCase("", "", "", "", 2)]
        [TestCase("", "dima@mail.ru", "123", "imba", 2)]
        [TestCase("", "", "123", "123", 4)]
        [TestCase("@aff", "", "123", "123", 4)]
        public void ValidateThrowException(string login, string email, string name, string surname, int errorsCount)
        {
            var user = new User { Name = name, Email = email, Login = login, Surname = surname };

            Assert.Throws<BadRequestException>(user.Validate);
            try
            {
                user.Validate();
            }
            catch (BadRequestException ex)
            {
                Assert.That(ex.Errors, Has.Count.EqualTo(errorsCount));
            }
        }


    }
}
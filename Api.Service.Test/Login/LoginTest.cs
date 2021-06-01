using Api.Domain.Dtos;

namespace Api.Service.Test.User
{
    public class LoginTest
    {
        public LoginDto loginDto = new LoginDto();

        public LoginTest()
        {
            var loginDto = new LoginDto() 
            {
                Email = Faker.Internet.Email()
            };
        }
    }
}
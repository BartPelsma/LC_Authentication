
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;
using LC_Authentication;
using Microsoft.EntityFrameworkCore;

namespace LiveChat_Authentication.tests
{
    public class AccountTests
    {
        private readonly ApplicationDbContext _dbContext;
        public AccountTests([CallerMemberName] string callerName = "")
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "InMemoryProductDb_" + callerName).Options;
            var context = new ApplicationDbContext(options);
            InMemoryDatabasesWithData.InMemoryDatabaseWithData(context);
            _dbContext = context;
        }

        [Fact]
        private async Task Login_ShouldValidateAccount()
        {
            //Initialize Controller
            var controller = new AccountController(_dbContext);
            var tc = new TokenController();

            //New Data
            var loginaccount = new LoginForm()
            {
                Email = "Barry@gmail.com",
                Password = "Barry123",
            };

            //Run and get result
            var result = await controller.Login(loginaccount);
            var actionResult = result as OkObjectResult;
            ResponseValue test = actionResult.Value as ResponseValue;
            var account = tc.TokenToAccount(actionResult.Value.ToString());

            //Check
            Assert.IsType<OkObjectResult>(result);
            //Assert.Equal(1, account.AccountID);
            //Assert.Equal("Barry@gmail.com", account.Email);
        }

        [Fact]
        private async Task Login_ShouldReturnErrorAccount_Not_Found()
        {
            //Initialize Controller
            var controller = new AccountController(_dbContext);
            var tc = new TokenController();

            //New Data
            var loginaccount = new LoginForm()
            {
                Email = "test",
                Password = "test",
            };

            //Run and get result
            var result = await controller.Login(loginaccount);
            var actionResult = result as BadRequestObjectResult;

            //Check
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionResult.StatusCode);
            Assert.Equal("Account_Not_Found", actionResult.Value.ToString());
        }

        [Fact]
        private async Task Login_ShouldReturnErrorMissingEmail()
        {
            //Initialize Controller
            var controller = new AccountController(_dbContext);
            var tc = new TokenController();

            //New Data
            var loginaccount = new LoginForm()
            {
                Email = "",
                Password = "test",
            };

            //Run and get result
            var result = await controller.Login(loginaccount);
            var actionResult = result as BadRequestObjectResult;

            //Check
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionResult.StatusCode);
            Assert.Equal("Missing_Email", actionResult.Value.ToString());
        }

        [Fact]
        private async Task Login_ShouldReturnErrorMissingPassword()
        {
            //Initialize Controller
            var controller = new AccountController(_dbContext);
            var tc = new TokenController();

            //New Data
            var loginaccount = new LoginForm()
            {
                Email = "test",
                Password = "",
            };

            //Run and get result
            var result = await controller.Login(loginaccount);
            var actionResult = result as BadRequestObjectResult;

            //Check
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionResult.StatusCode);
            Assert.Equal("Missing_Password", actionResult.Value.ToString());
        }
    }
}
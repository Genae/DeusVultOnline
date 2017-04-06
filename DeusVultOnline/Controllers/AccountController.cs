using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Management;
using DeusVultOnline.Authentication;
using Microsoft.AspNet.Identity.Owin;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        public UserManager UserManager => Request.GetOwinContext().GetUserManager<UserManager>();
        public SignInManager SignInManager => Request.GetOwinContext().Get<SignInManager>();

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult CreateUser(UserContract userContract)
        {
            if (!userContract.Password.Equals(userContract.PasswordConfirm))
                return new ActionResult(false, "Passwords did not match");
            var user = new User() { UserName = userContract.UserName, EmailAddress = userContract.EmailAdress };
            var res = UserManager.CreateAsync(user, userContract.Password).Result;
            if(!res.Succeeded)
                return new ActionResult(false, string.Concat(res.Errors));
            SignInManager.SignInAsync(user, false, false).GetAwaiter().GetResult();
            return new ActionResult(true);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("signin")]
        public ActionResult SignIn(SignInContract signInContract)
        {
            var signInStatus = SignInManager.PasswordSignInAsync(signInContract.UserName, signInContract.Password, true, false).Result;
            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return new ActionResult(true);
                case SignInStatus.LockedOut:
                    return new ActionResult(false, "User Locked out");
                case SignInStatus.RequiresVerification:
                    return new ActionResult(false, "Please Confirm your Email first.");
                case SignInStatus.Failure:
                    return new ActionResult(false, "Wrong Username or Password");
                default:
                    throw new ArgumentOutOfRangeException();
            }

            /*
             * var user = UserManager.FindByNameAsync(signInContract.UserName).GetAwaiter().GetResult();
            if (user == null)
                return BadRequest("Wrong Username or Password");
            var passwordCorrect = UserManager.CheckPasswordAsync(user, signInContract.Password).GetAwaiter().GetResult();
            if(!passwordCorrect)
                return BadRequest("Wrong Username or Password");
            SignInManager.SignInAsync(user, false, false).GetAwaiter().GetResult();
            return Ok();
             */
        }
    }

    public class ActionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ActionResult(bool success, string message = "")
        {
            Success = success;
            Message = message;
        }
    }

    public class SignInContract
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserContract
    {
        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
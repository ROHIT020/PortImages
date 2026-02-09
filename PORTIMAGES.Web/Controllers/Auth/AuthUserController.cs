using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PORTIMAGES.Application.Auth.AuthEmployee.Interfaces;
using PORTIMAGES.Application.Auth.AuthUser.Commands;

namespace PORTIMAGES.Web.Controllers.Auth
{
    public class AuthUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IAuthRepository _authService;

        public AuthUserController(IMediator mediator, IAuthRepository authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                await _authService.SignInAsync(new()
                {
                    ID = result.UserID,
                    Name = result.Name,
                    Email = result.Email,
                    RoleName = result.RoleName,
                    Action = result.Action,
                    Controller = result.Controller
                });
                return RedirectToAction(result.Action, result.Controller);
            }
            ModelState.AddModelError("", result.Message);
            return View(command);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "AuthUser");
        }

    }
}

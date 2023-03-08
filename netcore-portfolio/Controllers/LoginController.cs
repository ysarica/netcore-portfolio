using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using netcore_portfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using netcore_portfolio.ViewModels;
using netcore_portfolio.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace netcore_portfolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SmtpEmailSender _smtpEmailSender;
        private readonly Context _context;


        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,SmtpEmailSender smtpEmailSender,Context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _smtpEmailSender = smtpEmailSender;
            _context = context;

        }
         
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult Index(string ReturnUrl=null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {                  
                    await _signInManager.SignInAsync(user, model.RememberMe);

             
                    if (ReturnUrl == null)
                    {
                        
                        return Redirect("/Admin/Index/");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
                ModelState.AddModelError(string.Empty, "Geçersiz oturum açma girişimi.");
                return View(model);
            }
            return View(model);
        }
        public IActionResult Setup()
        {
            int userCount = _userManager.Users.ToList().Count;

            ViewBag.Message = userCount;

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Setup(RegisterViewModel model)
        {
            int userCount = _userManager.Users.ToList().Count;
            if (userCount < 1)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                user.Name = "Bilinmiyor";
                user.Surname = "bilinmiyor";
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                                       await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Bu email adresine sahip bir kullanıcı bulunamadı");
                    return View();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Login", new { token, email = user.Email }, protocol: HttpContext.Request.Scheme);

                await _smtpEmailSender.SendEmailAsync(user.Email, "Şifrenizi yenileme", $"Lütfen şifrenizi yenilemek için <a href='{callbackUrl}'>buraya</a> tıklayın.");

                ViewBag.MailMessage = "Mail Adresinize Şifre Sıfırlama Bağlantısı Gönderilmiştir";
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Code = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Bu email adresine sahip bir kullanıcı bulunamadı");
                    return View(model);
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }

            return View(model);
        }
    }
}

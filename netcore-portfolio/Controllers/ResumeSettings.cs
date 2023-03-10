using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_portfolio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using netcore_portfolio.Models;
using System.IO;

namespace netcore_portfolio.Controllers
{
    [Authorize]

    public class ResumeSettings : Controller
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ResumeSettings(Context context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> UpdateResume(Resume model)
        {
            var resume = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            resume.Name = model.Name;
            resume.Surname = model.Surname;
            resume.TitleDescription = model.TitleDescription;
            resume.Title = model.Title;
            resume.Phone = model.Phone;
            resume.Mail = model.Mail;
            resume.Location = model.Location;
            resume.ResumeAbout = model.ResumeAbout;

            _context.SaveChanges();

            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                await _userManager.UpdateAsync(user);
            }

            return Json(new { success = true });
        }
        public IActionResult GetResume()
        {
            var resume = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            return Json(resume);
        }

        [HttpPost]
        public async Task<IActionResult> ResumeImageUpdate(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Resim dosyası seçilmedi");

            if (!IsImage(file))
                return BadRequest("Yalnızca resim dosyaları yüklenebilir");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userImage = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            var oldImage = userImage.ResumeImage;
            userImage.ResumeImage = "/images/resume/" + fileName;
            _context.SaveChanges();
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                user.UserImage = "/images/resume/" + fileName;
                await _userManager.UpdateAsync(user);
            }
            if (oldImage != "/images/default/no-profile-photo.webp")
            {
                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
            }
            return Json(new { success = true });
        }

        private bool IsImage(IFormFile file)
        {
            if (file.ContentType.ToLower() != "image/jpg" &&
                file.ContentType.ToLower() != "image/jpeg" &&
                file.ContentType.ToLower() != "image/pjpeg" &&
                file.ContentType.ToLower() != "image/gif" &&
                file.ContentType.ToLower() != "image/x-png" &&
                file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            return true;
        }
        public IActionResult GetEducation()
        {
            var user = _userManager.FindByEmailAsync(User.Identity.Name);

            return Json(user.Result);
        }

    }
}

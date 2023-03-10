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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetResume()
        {
            var resume = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            return Json(resume);
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

        public IActionResult UpdateResumeSwitcs(int id,bool value)
        {
            var resumeSwitch = _context.Resume.FirstOrDefault(x=> x.ResumeID==1);
            if (id==1)//WorkState
            {
                resumeSwitch.WorkState = value;
            }
            else if (id == 2)
            {
                resumeSwitch.ServiceState = value;
            }
            else if (id==3)
            {
                resumeSwitch.WorkProccesState = value;
            }
            else if (id == 4)
            {
                resumeSwitch.WorkPartnersState = value;
            }
            else if (id == 5)
            {
                resumeSwitch.HobbiesState = value;
            }
            else if (id == 6)
            {
                resumeSwitch.WorkHistoryState = value;
            }
            else if (id ==7)
            {
                resumeSwitch.EducationState = value;
            }
            else if (id == 8)
            {
                resumeSwitch.TestimonialState = value;
            }

            _context.SaveChanges();

            return Json(new { success = true });
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

        [HttpPost]
        public async Task<IActionResult> ResumeCvUpdate(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Cv dosyası seçilmedi");

            if (file.ContentType.ToLower() != "application/pdf")
                return BadRequest("Cv dosyası Pdf Formatında Olmalı");


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "docs", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var userCv = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            var oldCv = userCv.PdfCV;
            userCv.PdfCV = "/docs/" + fileName;
            _context.SaveChanges();

            if (!string.IsNullOrEmpty(oldCv))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldCv.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                    System.IO.File.Delete(oldFilePath);
            }

            return Json(new { success = true });
        }

        public IActionResult GetService()
        {
            var service = _context.Service.Where(x => x.ResumeID == 1).ToList();

            return Json(service);
        }
        [HttpPost]
        public async Task<IActionResult> AddService([FromForm] Service service, IFormFile ServiceImage)
        {
            if (ServiceImage != null && ServiceImage.Length > 0)
            {
                // Resmi belirtilen klasöre yükle
                string fileName = Path.GetFileName(ServiceImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ServiceImage.CopyToAsync(stream);
                }

                // Servis bilgilerini de kaydet
                service.ServiceImage = "/images/resume/" + fileName;
                _context.Service.Add(service);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Resim yüklenirken hata oluştu." });
            }
        }
        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Service.FirstOrDefault(s => s.ServiceID == id);
            if (service != null)
            {
                _context.Service.Remove(service);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}

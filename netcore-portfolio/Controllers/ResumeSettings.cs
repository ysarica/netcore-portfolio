﻿using Microsoft.AspNetCore.Http;
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

        public IActionResult UpdateResumeSwitcs(int id, bool value)
        {
            var resumeSwitch = _context.Resume.FirstOrDefault(x => x.ResumeID == 1);
            if (id == 1)//WorkState
            {
                resumeSwitch.WorkState = value;
            }
            else if (id == 2)
            {
                resumeSwitch.ServiceState = value;
            }
            else if (id == 3)
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
            else if (id == 7)
            {
                resumeSwitch.EducationState = value;
            }
            else if (id == 8)
            {
                resumeSwitch.TestimonialState = value;
            }
            else if (id == 9)
            {
                resumeSwitch.SkillCategoryState = value;
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
        //SkillCategory Start
        public IActionResult GetSkillCategory()
        {
            var skillcategory = _context.SkillCategory.Where(x => x.ResumeID == 1).ToList();

            return Json(skillcategory);
        }
        [HttpPost]
        public IActionResult AddSkillCategory([FromForm] SkillCategory skillCategory)
        {
            _context.SkillCategory.Add(skillCategory);
            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteSkillCategory(int id)
        {
            var skillCategory = _context.SkillCategory.FirstOrDefault(s => s.SCID == id);
            var skill = _context.Skill.Where(x => x.SCID == skillCategory.SCID).ToList();
            if (skill != null)
            {
                foreach (var s in skill)
                {
                    var deleteSkill = _context.Skill.FirstOrDefault(x => x.SkillID == s.SkillID);
                    _context.Skill.Remove(deleteSkill);
                    _context.SaveChanges();
                }
            }
            if (skillCategory != null)
            {
                _context.SkillCategory.Remove(skillCategory);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetSkillCategoryById(int id)
        {
            var skillCategory = _context.SkillCategory.FirstOrDefault(s => s.SCID == id && s.ResumeID == 1);
            return Json(skillCategory);
        }
        [HttpPost]
        public IActionResult UpdateSkillCategory([FromForm] SkillCategory skillCategory)
        {
            var oldSkillCategory = _context.SkillCategory.FirstOrDefault(x => x.SCID == skillCategory.SCID);

            oldSkillCategory.SCName = skillCategory.SCName;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //SkillCategory Finish
        //Skill Start
        public IActionResult GetSkill()
        {
            var skill = _context.Skill.ToList();
            return Json(skill);
        }
        [HttpPost]
        public IActionResult AddSkill([FromForm] Skill skill)
        {
            _context.Skill.Add(skill);
            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skill.FirstOrDefault(s => s.SkillID == id);
            if (skill != null)
            {
                _context.Skill.Remove(skill);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        //Skill Finish
        //Service Start
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
                string fileName= Guid.NewGuid().ToString() + Path.GetExtension(ServiceImage.FileName);
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
                if (!string.IsNullOrEmpty(service.ServiceImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", service.ServiceImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                _context.Service.Remove(service);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetServiceById(int id)
        {
            var service = _context.Service.FirstOrDefault(s => s.ServiceID == id && s.ResumeID == 1);
            return Json(service);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService([FromForm] Service service, IFormFile ServiceImage)
        {
            var oldService = _context.Service.FirstOrDefault(x => x.ServiceID == service.ServiceID);
            var oldImage = oldService.ServiceImage;
            if (ServiceImage != null && ServiceImage.Length > 0)
            {
                // Resmi belirtilen klasöre yükle
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ServiceImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ServiceImage.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                oldService.ServiceImage = "/images/resume/" + fileName;

            }
            oldService.ServiceName = service.ServiceName;
            oldService.ServiceDescription = service.ServiceDescription;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //Service Finish
        //WProcces Start
        public IActionResult GetProcces()
        {
            var procces = _context.WorkProces.Where(x => x.ResumeID == 1).ToList().OrderBy(x=> x.WpOrder);

            return Json(procces);
        }
        [HttpPost]
        public async Task<IActionResult> AddProcces([FromForm] WorkProces procces, IFormFile WpImage)
        {
            if (WpImage != null && WpImage.Length > 0)
            {
                // Resmi belirtilen klasöre yükle
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(WpImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await WpImage.CopyToAsync(stream);
                }

                // Servis bilgilerini de kaydet
                procces.WpImage = "/images/resume/" + fileName;
                _context.WorkProces.Add(procces);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Resim yüklenirken hata oluştu." });
            }
        }
        [HttpPost]
        public IActionResult DeleteProcces(int id)
        {
            var procces = _context.WorkProces.FirstOrDefault(s => s.WorkProcesID == id);
            if (procces != null)
            {
                if (!string.IsNullOrEmpty(procces.WpImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", procces.WpImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                _context.WorkProces.Remove(procces);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetProccesById(int id)
        {
            var procces = _context.WorkProces.FirstOrDefault(s => s.WorkProcesID == id && s.ResumeID == 1);
            return Json(procces);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProcces([FromForm] WorkProces procces, IFormFile WpImage)
        {
            var oldProcces = _context.WorkProces.FirstOrDefault(x => x.WorkProcesID == procces.WorkProcesID);
            var oldImage = oldProcces.WpImage;
            if (WpImage != null && WpImage.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(WpImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await WpImage.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                oldProcces.WpImage = "/images/resume/" + fileName;

            }
            oldProcces.WpName = procces.WpName;
            oldProcces.WpOrder = procces.WpOrder;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //WProcces Finish
        //WPartners Start
        public IActionResult GetPartners()
        {
            var partners = _context.WorkPartners.Where(x => x.ResumeID == 1).ToList();

            return Json(partners);
        }
        [HttpPost]
        public async Task<IActionResult> AddPartners([FromForm] WorkPartners partners, IFormFile WpsLogo)
        {
            if (WpsLogo != null && WpsLogo.Length > 0)
            {
                // Resmi belirtilen klasöre yükle
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(WpsLogo.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await WpsLogo.CopyToAsync(stream);
                }

                // Servis bilgilerini de kaydet
                partners.WpsLogo = "/images/resume/" + fileName;
                _context.WorkPartners.Add(partners);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Resim yüklenirken hata oluştu." });
            }
        }
        [HttpPost]
        public IActionResult DeletePartners(int id)
        {
            var partners = _context.WorkPartners.FirstOrDefault(s => s.WorkPartnersID == id);
            if (partners != null)
            {
                if (!string.IsNullOrEmpty(partners.WpsLogo))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", partners.WpsLogo.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                _context.WorkPartners.Remove(partners);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetPartnersById(int id)
        {
            var partners = _context.WorkPartners.FirstOrDefault(s => s.WorkPartnersID == id && s.ResumeID == 1);
            return Json(partners);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePartners(WorkPartners partners, IFormFile WpsLogo)
        {
            var oldPartners = _context.WorkPartners.FirstOrDefault(x => x.WorkPartnersID == partners.WorkPartnersID);
            if (WpsLogo != null && WpsLogo.Length > 0)
            {
                var oldImage = oldPartners.WpsLogo;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(WpsLogo.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await WpsLogo.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                oldPartners.WpsLogo = "/images/resume/" + fileName;
            }
            oldPartners.WpsName = partners.WpsName;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //WPartners Finish
        //Hobbies Start
        public IActionResult GetHobbies()
        {
            var hobbies = _context.Hobbies.Where(x => x.ResumeID == 1).ToList();

            return Json(hobbies);
        }
        [HttpPost]
        public async Task<IActionResult> AddHobbies([FromForm] Hobbies hobbies, IFormFile HobbieImage)
        {
            if (HobbieImage != null && HobbieImage.Length > 0)
            {
                // Resmi belirtilen klasöre yükle
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(HobbieImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await HobbieImage.CopyToAsync(stream);
                }

                // Servis bilgilerini de kaydet
                hobbies.HobbieImage = "/images/resume/" + fileName;
                _context.Hobbies.Add(hobbies);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Resim yüklenirken hata oluştu." });
            }
        }
        [HttpPost]
        public IActionResult DeleteHobbies(int id)
        {
            var hobbies = _context.Hobbies.FirstOrDefault(s => s.HobbieID == id);
            if (hobbies != null)
            {
                if (!string.IsNullOrEmpty(hobbies.HobbieImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", hobbies.HobbieImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                _context.Hobbies.Remove(hobbies);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetHobbiesById(int id)
        {
            var hobbies = _context.Hobbies.FirstOrDefault(s => s.HobbieID == id && s.ResumeID == 1);
            return Json(hobbies);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHobbies([FromForm] Hobbies hobbies, IFormFile HobbieImage)
        {
            var oldHobbies = _context.Hobbies.FirstOrDefault(x => x.HobbieID == hobbies.HobbieID);
            var oldImage = oldHobbies.HobbieImage;
            if (HobbieImage != null && HobbieImage.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(HobbieImage.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "resume", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await HobbieImage.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(oldImage))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
                oldHobbies.HobbieImage = "/images/resume/" + fileName;

            }
            oldHobbies.HobbieName = hobbies.HobbieName;
            _context.SaveChanges();
            return Json(new { success = true });

        }
        //Hobbies Finish
        //WHistory Start
        public IActionResult GetHistory()
        {
            var history = _context.WorkHistory.Where(x => x.ResumeID == 1).ToList();

            return Json(history);
        }
        [HttpPost]
        public IActionResult AddHistory([FromForm] WorkHistory history)
        {
                _context.WorkHistory.Add(history);
                _context.SaveChanges();
                return Json(new { success = true });          
        }
        [HttpPost]
        public IActionResult DeleteHistory(int id)
        {
            var history = _context.WorkHistory.FirstOrDefault(s => s.WorkHistoryID == id);
            if (history != null)
            {              
                _context.WorkHistory.Remove(history);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetHistoryById(int id)
        {
            var history = _context.WorkHistory.FirstOrDefault(s => s.WorkHistoryID == id && s.ResumeID == 1);
            return Json(history);
        }
        [HttpPost]
        public IActionResult UpdateHistory([FromForm] WorkHistory history)
        {
            var oldHistory = _context.WorkHistory.FirstOrDefault(x => x.WorkHistoryID == history.WorkHistoryID);

            oldHistory.StartDate = history.StartDate;
            oldHistory.FinishDate = history.FinishDate;
            oldHistory.WorkTitle = history.WorkTitle;
            oldHistory.CompanyName = history.CompanyName;
            oldHistory.WorkDescription = history.WorkDescription;

            _context.SaveChanges();
            return Json(new { success = true });

        }
        //WHistory Finish
        //Education Start
        public IActionResult GetEducation()
        {
            var education = _context.Education.Where(x => x.ResumeID == 1).ToList();

            return Json(education);
        }
        [HttpPost]
        public IActionResult AddEducation([FromForm] Education education)
        {
            _context.Education.Add(education);
            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Education.FirstOrDefault(s => s.EducationID == id);
            if (education != null)
            {
                _context.Education.Remove(education);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetEducationById(int id)
        {
            var education = _context.Education.FirstOrDefault(s => s.EducationID == id && s.ResumeID == 1);
            return Json(education);
        }
        [HttpPost]
        public IActionResult UpdateEducation([FromForm] Education education)
        {
            var oldEducation = _context.Education.FirstOrDefault(x => x.EducationID == education.EducationID);

            oldEducation.StartDate = education.StartDate;
            oldEducation.FinishDate = education.FinishDate;
            oldEducation.EducationBranch = education.EducationBranch;
            oldEducation.SchoolName = education.SchoolName;
            oldEducation.EducationDescription = education.EducationDescription;

            _context.SaveChanges();
            return Json(new { success = true });

        }
        //Education Finish
        //Testimonial Start
        public IActionResult GetTestimonial()
        {
            var testimonials = _context.Testimonials.Where(x => x.ResumeID == 1).ToList();

            return Json(testimonials);
        }
        [HttpPost]
        public IActionResult AddTestimonial([FromForm] Testimonials testimonials)
        {
            _context.Testimonials.Add(testimonials);
            _context.SaveChanges();
            return Json(new { success = true });
        }
        [HttpPost]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonials = _context.Testimonials.FirstOrDefault(s => s.TestimonialID == id);
            if (testimonials != null)
            {
                _context.Testimonials.Remove(testimonials);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonials = _context.Testimonials.FirstOrDefault(s => s.TestimonialID == id && s.ResumeID == 1);
            return Json(testimonials);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial([FromForm] Testimonials testimonials)
        {
            var oldTestimonials = _context.Testimonials.FirstOrDefault(x => x.TestimonialID == testimonials.TestimonialID);

            oldTestimonials.TName = testimonials.TName;
            oldTestimonials.TCompany = testimonials.TCompany;
            oldTestimonials.TDescription = testimonials.TDescription;

            _context.SaveChanges();
            return Json(new { success = true });

        }
        //Testimonial Finish

    }
}

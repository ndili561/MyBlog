using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using AutoMapper;
using NToastNotify;
using MyBlog.Common;
using MyBlog.DAL.Model;
using MyBlog.Common.Entities;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMapper mapper;

        private readonly ICommentService common;

        private readonly IToastNotification _toastNotification;

        public HomeController(IMapper mapp,  IToastNotification toastNotification, ICommentService ctx)
        {
            mapper = mapp;
            common = ctx;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            ViewData["Message"] = "Index";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult BlogOne()
        {
            var model = new CommentDTO();
            var comments = common.GetallComment(1);
            model.comments = comments.ConvertAll(x => (Comment)x);
            return View("Main",model);
        }

        public IActionResult BlogTwo()
        {
         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Info(InfoDTO info)
        {
            if (TryValidateModel(info))
            {
                var nfo = Mapper.Map<Info>(info);
                var result = await common.addInfo(nfo);

            }
            _toastNotification.AddSuccessToastMessage("Your Info have been submitted");
            return View("Contact");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Stayupdated(CommentDTO subscribe)
        {
            if (ModelState.GetFieldValidationState("info.email")== Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                var nfo = Mapper.Map<Info>(subscribe.info);
                var result = await common.addInfo(nfo);
                return Json(new { messagge = "You are subscribed to the newsletter", success = true });
            }
            return Json(new { messagge = "Please enter a valid email address", success = false });

        }


     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> postComment(CommentDTO dto)
        {
            if (TryValidateModel(dto))
            {
                var cmt = Mapper.Map<Comment>(dto);
                var result = await common.addComment(cmt);
                _toastNotification.AddSuccessToastMessage("Comment added successfully");
                return RedirectToAction("BlogOne","Home");

            }
            return RedirectToAction("BlogOne", "Home");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

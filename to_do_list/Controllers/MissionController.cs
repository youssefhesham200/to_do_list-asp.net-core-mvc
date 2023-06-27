﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using to_do_list.Models;
using to_do_list.Contracts;
using Microsoft.AspNetCore.Identity;
using to_do_list.Areas.Identity.Data;

namespace to_do_list.Controllers
{
    public class MissionController : Controller
    {

        private readonly ILogger<MissionController> _logger;
        private readonly IRepoMission _RepoMission;
        private readonly UserManager<AppUser> _userManager;

        public MissionController(ILogger<MissionController> logger, IRepoMission mission, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _RepoMission = mission;
            _userManager = userManager;
        }

        public IActionResult Home()
        {
            if (_userManager.GetUserId(this.User) != null)
            {
                return RedirectToAction("GetMissions");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMission()
        {            
            return View(new Mission());
        }

        [HttpPost]
        public IActionResult CreateMission(Mission mission)
        {
            if (ModelState.IsValid)
            {
                var UserId = _userManager.GetUserId(this.User);
                mission.UserId = UserId;
                _RepoMission.CreateMission(mission);
                return RedirectToAction("GetMissions");
            }

            return View(mission);
        }

        [HttpGet]
        public IActionResult GetMissions()
        {
            var UserId = _userManager.GetUserId(this.User);

            if (UserId == null)
            {
                return RedirectToAction("Home");
            }
  
            var missions = _RepoMission.GetAllMissions(UserId).ToList();

            return View(missions);
        }

        [HttpPost]
        public IActionResult MarkSelectedMissions(string[] selectedTaskIds, string submitButton)
        {

            var UserId = _userManager.GetUserId(this.User);

            if(UserId == null)
            {
                return RedirectToAction("Home");
            }


             if (submitButton == "completed")
             {
                foreach (var task in selectedTaskIds)
                {
                    Console.WriteLine(task);
                }

                _RepoMission.MarkAsCompleted(selectedTaskIds, UserId);
             }
             else if (submitButton == "notcompleted")
             {
                _RepoMission.MarkNotCompleted(selectedTaskIds, UserId);
             }

            return RedirectToAction("GetMissions");
        }


        [HttpGet]
        public IActionResult UpdateMission(string id)
        {
            Mission mission = new Mission();
            var UserId = _userManager.GetUserId(this.User);

            if (UserId == null)
            {
                return RedirectToAction("Home");
            }

            var missions = _RepoMission.GetAllMissions(UserId).ToList();
              
            foreach(var m in missions)
            {
                if(m.Id.ToString() == id)
                {
                    mission = m;
                    break;
                }
            }

            return View(mission);
        }

        [HttpPost]
        public IActionResult UpdateMission(Mission mission)
        {
            if (ModelState.IsValid)
            {

                var UserId = _userManager.GetUserId(this.User);

                if (UserId == null)
                {
                    return RedirectToAction("Home");
                }

                _RepoMission.UpdateMission(mission, UserId);
                return RedirectToAction("GetMissions");
            }

            return View(mission);
        }

        //i know i should use Httpdelete here but there is a problem with iis server that get 405 error 
        [HttpGet]
        public IActionResult DeleteMission(string id)
        {
            var UserId = _userManager.GetUserId(this.User);

            if (UserId == null)
            {
                return RedirectToAction("Home");
            }

            _RepoMission.DeleteMission(id, UserId);

            return RedirectToAction("GetMissions");
        }
    }
}
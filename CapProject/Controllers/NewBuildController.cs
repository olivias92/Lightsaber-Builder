using System.Diagnostics;
using CapProject.Models;
using CapProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CapProject.Controllers {
    public class NewBuildController : Controller {

        private LightsaberContext context { get; set; }

        public NewBuildController(LightsaberContext ctx) => context = ctx;


        // Method to create dropdown options for each component/color
        public static List<SelectListItem> createDrop(string type, LightsaberContext context) {
            return context.Components
                .Where(c => c.component_type == type)
                .Select(c => new SelectListItem {
                    Value = c.component_id.ToString(),
                    Text = c.component_name
                }).ToList();

        } // End method

        public static List<SelectListItem> colorList() {
            var colors = new List<SelectListItem> {
                new SelectListItem {Value = "Blue", Text = "Blue"},
                new SelectListItem {Value = "Green", Text = "Green"},
                new SelectListItem {Value = "Red", Text = "Red"},
                new SelectListItem {Value = "Purple", Text = "Purple"},
                new SelectListItem {Value = "Yellow", Text = "Yellow"},
                new SelectListItem {Value = "Orange", Text = "Orange"}
            };  // End var

            return colors;
        } // End method


        [HttpGet]
        public IActionResult Index() {
            return View();
        } // End method


        [HttpPost]
        public IActionResult Index(LightSaberVM model) {
             
            if (string.IsNullOrWhiteSpace(model.nameSelected)) { 
                ModelState.AddModelError("nameSelected", "Name is required.");
                return View(model);
            } // End if

            //TempData["Name"]= model.nameSelected;
            //TempData.Peek("Name");
            HttpContext.Session.SetString("Name", model.nameSelected);

            return RedirectToAction("Emitter");
        } // End method


        [HttpGet]
        public IActionResult Emitter() {

            var viewMod = new LightSaberVM {
                emitterOptions = createDrop("Emitter", context)
            }; // End var

            return View(viewMod);

        } // End method


        [HttpPost]
        public IActionResult Emitter(LightSaberVM model) {

            if (string.IsNullOrWhiteSpace(model.emitterSelected.ToString())) {
                ModelState.AddModelError("emitterSelected", "Emitter is required");
                model.emitterOptions = createDrop("Emitter", context);
            } // End if

            //ViewBag.EM = model.emitterSelected;
            //TempData["Emitter"] = model.nameSelected;
            //TempData.Peek("Emitter");

            HttpContext.Session.SetInt32("Emitter", model.emitterSelected);
            return RedirectToAction("Switch");

        } // End method


        [HttpGet]
        public IActionResult Switch() {
            var viewMod = new LightSaberVM {
                switchOptions = createDrop("Switch", context)
            }; // End var

            return View(viewMod);
        } // End method


        [HttpPost]
        public IActionResult Switch(LightSaberVM model) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("Switch", "Switch is required");
                model.switchOptions = createDrop("Switch", context);
            } // End if

            //ViewBag.SW = model.switchSelected;
            //TempData["Switch"] = model.nameSelected;
            //TempData.Peek("Switch");

            HttpContext.Session.SetInt32("Switch", model.switchSelected);
            return RedirectToAction("Hilt");
        } // End method


        [HttpGet]
        public IActionResult Hilt() {
            var viewMod = new LightSaberVM {
                hiltOptions = createDrop("Hilt", context)
            }; // End var
            return View(viewMod);
        } // End method


        [HttpPost]
        public IActionResult Hilt(LightSaberVM model) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("Hilt", "Hilt is required");
                model.hiltOptions = createDrop("Hilt", context);
            } // End if

            //ViewBag.HT = model.hiltSelected;
            //TempData["Hilt"] = model.nameSelected;
            //TempData.Peek("Hilt");
            HttpContext.Session.SetInt32("Hilt", model.hiltSelected);
            return RedirectToAction("Pommel");
        } // End method


        [HttpGet]
        public IActionResult Pommel() {
            var viewMod = new LightSaberVM {
                pommelOptions = createDrop("Pommel", context)
            }; // End var
            return View(viewMod);
        } // End method

        [HttpPost]
        public IActionResult Pommel(LightSaberVM model) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("Pommel", "Pommel is required");
                model.pommelOptions = createDrop("Pommel", context);
            } // End if

            //ViewBag.PO = model.pommelSelected;
            //TempData["Pommel"] = model.nameSelected;
            //TempData.Peek("Pommel");
            HttpContext.Session.SetInt32("Pommel", model.pommelSelected);
            return RedirectToAction("Color");
        } // End method


        [HttpGet]
        public IActionResult Color() {

            var viewMod = new LightSaberVM {
                colorOptions = colorList()
            }; // End var

            return View(viewMod);
        } // End method


        [HttpPost]
        public IActionResult Color (LightSaberVM model) {
            if (!ModelState.IsValid) {
                ModelState.AddModelError("Color", "Color is required.");
            } // End if

            HttpContext.Session.SetString("Color", model.colorSelected);         
            Console.WriteLine(HttpContext.Session.GetString("Name"));
            Console.WriteLine((int)HttpContext.Session.GetInt32("Emitter"));
            Console.WriteLine((int)HttpContext.Session.GetInt32("Switch"));
            Console.WriteLine((int)HttpContext.Session.GetInt32("Hilt"));
            Console.WriteLine((int)HttpContext.Session.GetInt32("Pommel"));
            Console.WriteLine(HttpContext.Session.GetString("Color"));


            var lightsaber = new Lightsaber {
                name = HttpContext.Session.GetString("Name"),
                Emitter = (int)HttpContext.Session.GetInt32("Emitter"),
                Switch = (int)HttpContext.Session.GetInt32("Switch"),
                Hilt = (int)HttpContext.Session.GetInt32("Hilt"),
                Pommel = (int)HttpContext.Session.GetInt32("Pommel"),
                blade_color = HttpContext.Session.GetString("Color")
            }; // End var


                context.Lightsabers.Add(lightsaber);
                context.SaveChanges();
                return RedirectToAction("Success");

                //return RedirectToAction("Confirm");

            } // End method


        [HttpGet]
        public IActionResult Success() {
            return View();
        } // End method


    } // End class
} // End namespace

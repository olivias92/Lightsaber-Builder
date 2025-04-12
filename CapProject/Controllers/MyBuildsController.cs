using System.Diagnostics;
using CapProject.Models;
using CapProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CapProject.Controllers {
    public class MyBuildsController : Controller {

        private LightsaberContext context { get; set; }

        public MyBuildsController(LightsaberContext ctx) => context = ctx;


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

            var lightsabers = context.Lightsabers
                .OrderBy(l => l.name)
                .ToList();
            Debug.WriteLine($"{lightsabers.Count}");
            return View(lightsabers);
        } // End method


        [HttpGet]
        public IActionResult Edit(int lsID) {
            Console.WriteLine($"Received lsID: {lsID}");
            ViewBag.Action = "Edit";
            Console.WriteLine($"Edit method called with lsID: {lsID}");
            var lightsaber = context.Lightsabers.Find(lsID);
            Console.WriteLine($"Edit method called with lsID: {lsID}");

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                nameSelected = lightsaber.name,
                emitterSelected = lightsaber.Emitter,
                switchSelected = lightsaber.Switch,
                hiltSelected = lightsaber.Hilt,
                pommelSelected = lightsaber.Pommel,
                colorSelected = lightsaber.blade_color
            }; // End var

            return RedirectToAction("EditName", new {lsId = lsID});
        } // End method


        [HttpGet]
        public IActionResult Delete(int lsID) {
            ViewBag.Action = "Delete";
            return View();  
        } // End method



        // EditName methods
        [HttpGet]
        public IActionResult EditName(int lsID) {

            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                nameSelected = lightsaber.name
            }; // End var

            return View(viewMod);
        } // End method


        [HttpPost]
        public IActionResult EditName(LightSaberVM model) {
            Console.WriteLine($"EditName called with idGiven: {model.idGiven}");

            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.nameSelected.ToString())) {
                ModelState.AddModelError("nameSelected", "Name is required.");
                return View(model);
            } // End if

            lightsaber.name = model.nameSelected;
            //model.nameSelected = lightsaber.name;
            //context.SaveChanges();


            return RedirectToAction("EditEmitter", new { lsId = model.idGiven });
        } // End method



        // EditEmitter methods
        [HttpGet]
        public IActionResult EditEmitter(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                emitterSelected = lightsaber.Emitter,
                emitterOptions = createDrop("Emitter", context)
            }; // End var

            return View(viewMod);

        } // End method

        [HttpPost]
        public IActionResult EditEmitter(LightSaberVM model) {
            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.emitterSelected.ToString())) {
                ModelState.AddModelError("emitterSelected", "Emitter is required.");
                model.emitterOptions = createDrop("Emitter", context);
                return View(model);
            } // End if

            lightsaber.Emitter = model.emitterSelected;
            //context.SaveChanges();


            return RedirectToAction("EditSwitch", new { lsId = model.idGiven });
        } // End method



        // EditSwitch methods
        [HttpGet]
        public IActionResult EditSwitch(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                switchSelected = lightsaber.Switch,
                switchOptions = createDrop("Switch", context)
            }; // End var

            return View(viewMod);
        } // End method

        [HttpPost]
        public IActionResult EditSwitch(LightSaberVM model) {
            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.switchSelected.ToString())) {    
                ModelState.AddModelError("switchSelected", "Switch is required.");
                model.switchOptions = createDrop("Switch", context);
                return View(model);
            } // End if

            lightsaber.Switch = model.switchSelected;
            //context.SaveChanges();


            return RedirectToAction("EditHilt", new { lsId = model.idGiven });
        } // End method



        // EditHilt methods
        [HttpGet]
        public IActionResult EditHilt(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                hiltSelected = lightsaber.Hilt,
                hiltOptions = createDrop("Hilt", context)
            }; // End var

            return View(viewMod);
        } // End method

        [HttpPost]
        public IActionResult EditHilt(LightSaberVM model) {
            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.hiltSelected.ToString())) {
                ModelState.AddModelError("hiltSelected", "Hilt is required.");
                model.hiltOptions = createDrop("Hilt", context);
                return View(model);
            } // End if

            lightsaber.Hilt = model.hiltSelected;
            //context.SaveChanges();


            return RedirectToAction("EditPommel", new { lsId = model.idGiven });
        } // End method



        // EditPommel methods
        [HttpGet]
        public IActionResult EditPommel(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                pommelSelected = lightsaber.Pommel,
                pommelOptions = createDrop("Pommel", context)
            }; // End var

            return View(viewMod);
        } // End method

        [HttpPost]
        public IActionResult EditPommel(LightSaberVM model) {
            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.pommelSelected.ToString())) {
                ModelState.AddModelError("pommelSelected", "Pommel is required.");
                model.pommelOptions = createDrop("Pommel", context);
                return View(model);
            } // End if

            lightsaber.Pommel = model.pommelSelected;
            //context.SaveChanges();


            return RedirectToAction("EditColor", new { lsId = model.idGiven });
        } // End method



        // EditColor methods
        [HttpGet]
        public IActionResult EditColor(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);

            var viewMod = new LightSaberVM {
                idGiven = lsID,
                colorSelected = lightsaber.blade_color,
                colorOptions = colorList()
            }; // End var

            return View(viewMod);
        } // End method


        [HttpPost]
        public IActionResult EditColor(LightSaberVM model) {
            var lightsaber = context.Lightsabers.Find(model.idGiven);

            if (string.IsNullOrWhiteSpace(model.colorSelected.ToString())) {
                ModelState.AddModelError("colorSelected", "Color is required.");
                model.colorOptions = colorList();
                return View(model);
            } // End if

            lightsaber.blade_color = model.colorSelected;
            //context.SaveChanges();


            return RedirectToAction("EditConfirm");
        } // End method


        public IActionResult EditConfirm(int lsID) {
            var lightsaber = context.Lightsabers.Find(lsID);
            context.SaveChanges();
            return RedirectToAction("EditSuccess");
        } // End method


        // Success page
        public IActionResult EditSuccess() {
            return View();
        } // End method


    } // End class
} // End namespace
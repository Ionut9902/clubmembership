using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class AnnouncementController : Controller
    {
        private AnnouncementRepository announcementRepository;
        public AnnouncementController(ApplicationDbContext dbContext)
        {
             announcementRepository = new AnnouncementRepository(dbContext);
        }
        // GET: AnnouncementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    announcementRepository.InsertAnnouncement(model);
                }
                return View("CreateAnnouncement");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

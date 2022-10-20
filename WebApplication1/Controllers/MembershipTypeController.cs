using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class MembershipTypeController : Controller
    {
        private MembershipTypeRepository membershipTypeRepository;
        public MembershipTypeController(ApplicationDbContext dbContext)
        {
            membershipTypeRepository = new MembershipTypeRepository(dbContext);
        }
        // GET: MembershipTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MembershipTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MembershipTypeController/Create
        public ActionResult Create()
        {
            return View("CreateMembershipType");
        }

        // POST: MembershipTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipTypeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    membershipTypeRepository.InsertMembershipType(model);
                }
                return View("CreateMembershipType");
            }
            catch
            {
                return View("CreateMembershipType");
            }
        }

        // GET: MembershipTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembershipTypeController/Edit/5
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

        // GET: MembershipTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembershipTypeController/Delete/5
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

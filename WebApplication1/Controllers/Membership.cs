using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class Membership : Controller
    {
        private MemberShipRepository membershipRepository;
        public Membership(ApplicationDbContext dbContext)
        {
            membershipRepository = new MemberShipRepository(dbContext);
        }
        // GET: Membership
        public ActionResult Index()
        {
            return View();
        }

        // GET: Membership/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Membership/Create
        public ActionResult Create()
        {
            return View("CreateMembership");
        }

        // POST: Membership/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    membershipRepository.InsertMembership(model);
                }
                return View("CreateMembership");
            }
            catch
            {
                return View("CreateMembership");
            }
        }

        // GET: Membership/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Membership/Edit/5
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

        // GET: Membership/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Membership/Delete/5
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

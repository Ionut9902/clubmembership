using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class CodeSnippetController : Controller
    {
        private CodeSnippetRepository codeSnippetRepository;

        private MemberRepository memberRepository;
        public CodeSnippetController(ApplicationDbContext dbContext)

        {

            memberRepository = new MemberRepository(dbContext);

            codeSnippetRepository = new CodeSnippetRepository(dbContext);

        }
        // GET: CodeSnippetController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CodeSnippetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CodeSnippetController/Create
        public ActionResult Create()
        {
            var members = memberRepository.GetAllMembers();

            //SelectList memberList = new SelectList(members.Select(x => new SelectListItem(x.Name, x.Idmember.ToString())));

            var memberList = members.Select(x => new SelectListItem(x.Name, x.IdMember.ToString()));

            //var memberList = members.Select(x => new SelectListItem() { Text = x.Name, Value = x.Idmember.ToString() });

            ViewBag.MemberList = memberList;

            return View("Create");
        }

        // POST: CodeSnippetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try

            {

                var model = new CodeSnippetModel();

                var task = TryUpdateModelAsync(model);

                task.Wait();

                if (task.Result)

                {

                    codeSnippetRepository.InsertCodeSnippet(model);

                }



                return View("Index");

            }

            catch (Exception error)

            {

                return View("Create");

            }
        }

        // GET: CodeSnippetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CodeSnippetController/Edit/5
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

        // GET: CodeSnippetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CodeSnippetController/Delete/5
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

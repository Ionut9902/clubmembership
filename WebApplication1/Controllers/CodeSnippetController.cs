using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{
    public class CodeSnippetController : Controller
    {
        private CodeSnippetRepository codeSnippetRepository;
        public CodeSnippetController(ApplicationDbContext dbContext)
        {
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
            return View("CreateCodeSnippet");
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
                return View("CreateCodeSnippet");
            }
            catch
            {
                return View("CreateCodeSnippet");
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

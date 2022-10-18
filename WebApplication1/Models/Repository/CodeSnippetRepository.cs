using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBObjects;

namespace WebApplication1.Models.Repository
{
    public class CodeSnippetRepository
    {
         private readonly CodeSnippetDbContext _DBContext;
        public CodeSnippetRepository(CodeSnippetDbContext dBContext)
        {
            _DBContext = dBContext;
        }
        private CodeSnippetModel MapDBObjectToModel(CodeSnippet dbobject)
        {
            var model = new CodeSnippetModel();
            if(dbobject != null)
            {
                model.IdCodeSnippet = dbobject.IdAnnouncement;
                model.Title = dbobject.Title;
                model.ContentCode = dbobject.ContentCode;
                model.IdMember = dbobject.IdMember;
                model.Revision = dbobject.Revision;
                model.IdSnippetPreviousVersion = dbobject.IdSnippetPreviousVersion;
                model.DateTimeAdded = dbobject.DateTimeAdded;
                model.IsPublished = dbobject.IsPublished;
            }
            return model;
        }

        private CodeSnippet MapModelToDBObject(CodeSnippetModel model)
        {
            var dbobject = new CodeSnippet();
            if (dbobject != null)
            {
                dbobject.IdCodeSnippet = model.IdAnnouncement;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.IdMember = model.IdMember;
                dbobject.Revision = model.Revision;
                dbobject.IdSnippetPreviousVersion = model.IdSnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
                dbobject.IsPublished = model.IsPublished;
            }
            return dbobject;
        }

        public List<CodeSnippetModel> GetAllCodeSnippets()
        {
            var list = new List<CodeSnippetModel>();
            foreach(var dbobject in _DBContext.CodeSnippets)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public CodeSnippetModel GetCodeSnippetByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id));
        }

        public void InsertCodeSnippet(CodeSnippetModel model)
        {
            model.IdCodeSnippet = Guid.NewGuid();
            _DBContext.Annoucements.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel model)
        {
            var dbobject = _DBContext.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == model.IdCodeSnippet);
            if(dbobject != null)
            {
                dbobject.IdCodeSnippet = model.IdAnnouncement;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.IdMember = model.IdMember;
                dbobject.Revision = model.Revision;
                dbobject.IdSnippetPreviousVersion = model.IdSnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
                dbobject.IsPublished = model.IsPublished;
                _DBContext.SaveChanges();
            }
            
            
        }

        public void DeleteCodeSnippet(CodeSnippetModel model)
        {
            var dbobject = _DBContext.CodeSnippet.FirstOrDefault(x => x.IdCodeSnippet == model.IdCodeSnippet);
            if(dbobject != null)
            {
                _DBContext.CodeSnippets.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}

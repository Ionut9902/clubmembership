using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBObjects;

namespace WebApplication1.Models.Repository
{
    public class MemberRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public MemberRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }
        private MemberModel MapDBObjectToModel(Member dbobject)
        {
            var model = new MemberModel();
            if(dbobject != null)
            {
                model.IdMember = dbobject.IdMember;
                model.Name = dbobject.Name;
                model.Title = dbobject.Title;
                model.Position = dbobject.Position;
                model.Description = dbobject.Description;
                model.Resume = dbobject.Resume;
            }
            return model;
        }

        private Member MapModelToDBObject(MemberModel model)
        {
            var dbobject = new Member();
            if (dbobject != null)
            {
                dbobject.IdMember = model.IdMember;
                dbobject.Name = model.Name;
                dbobject.Title = model.Title;
                dbobject.Position = model.Position;
                dbobject.Description = model.Description;
                dbobject.Resume = model.Resume;
            }
            return dbobject;
        }

        public List<MemberModel> GetAllMembers()
        {
            var list = new List<MemberModel>();
            foreach(var dbobject in _DBContext.Members)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MemberModel GetMemberByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Members.FirstOrDefault(x => x.IdMember == id));
        }

        public void InsertMember(MemberModel model)
        {
            model.IdMember = Guid.NewGuid();
            _DBContext.Members.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateMember(MemberModel model)
        {
            var dbobject = _DBContext.Members.FirstOrDefault(x => x.IdMember == model.IdMember);
            if(dbobject != null)
            {
                dbobject.IdMember = model.IdMember;
                dbobject.Name = model.Name;
                dbobject.Title = model.Title;
                dbobject.Position = model.Position;
                dbobject.Description = model.Description;
                dbobject.Resume = model.Resume;
                _DBContext.SaveChanges();
            }
            
            
        }

        public void DeleteMember(MemberModel model)
        {
            var dbobject = _DBContext.Members.FirstOrDefault(x => x.IdMember == model.IdMember);
            if(dbobject != null)
            {
                _DBContext.Members.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}

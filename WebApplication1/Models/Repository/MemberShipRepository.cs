using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBObjects;

namespace WebApplication1.Models.Repository
{
    public class MemberShipRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public MemberShipRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }
        private MembershipModel MapDBObjectToModel(Membership dbobject)
        {
            var model = new MembershipModel();
            if(dbobject != null)
            {
                model.IdMembership = dbobject.IdMembership;
                model.Name = dbobject.Name;
                model.IdMember = dbobject.IdMember;
                model.IdMembershipType = dbobject.IdMembershipType;
                model.StartDate = dbobject.StartDate;
                model.EndDate = dbobject.EndDate;
                model.Level = dbobject.Level;
            }
            return model;
        }

        private Membership MapModelToDBObject(MembershipModel model)
        {
            var dbobject = new Membership();
            if (dbobject != null)
            {
                dbobject.IdMembership = model.IdMembership;
                dbobject.Name = model.Name;
                dbobject.IdMember = model.IdMember;
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.StartDate = model.StartDate;
                dbobject.EndDate = model.EndDate;
                dbobject.Level = model.Level;
            }
            return dbobject;
        }

        public List<MembershipModel> GetAllMemberships()
        {
            var list = new List<MembershipModel>();
            foreach(var dbobject in _DBContext.Memberships)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MembershipModel GetMembershipByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Memberships.FirstOrDefault(x => x.IdMembership == id));
        }

        public void InsertMembership(MembershipModel model)
        {
            model.IdMembership = Guid.NewGuid();
            _DBContext.Memberships.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateMembership(MembershipModel model)
        {
            var dbobject = _DBContext.Memberships.FirstOrDefault(x => x.IdMembership == model.IdMembership);
            if(dbobject != null)
            {
                dbobject.IdMembership = model.IdMembership;
                dbobject.Name = model.Name;
                dbobject.IdMember = model.IdMember;
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.StartDate = model.StartDate;
                dbobject.EndDate = model.EndDate;
                dbobject.Level = model.Level;
                _DBContext.SaveChanges();
            }
            
            
        }

        public void DeleteMembership(MembershipModel model)
        {
            var dbobject = _DBContext.Memberships.FirstOrDefault(x => x.IdMembership == model.IdMembership);
            if(dbobject != null)
            {
                _DBContext.Memberships.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
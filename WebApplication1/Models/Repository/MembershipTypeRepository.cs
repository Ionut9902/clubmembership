using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBObjects;

namespace WebApplication1.Models.Repository
{
    public class MembershipTypeRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public MembershipTypeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }
        private MembershipTypeModel MapDBObjectToModel(MembershipType dbobject)
        {
            var model = new MembershipTypeModel();
            if(dbobject != null)
            {
                model.IdMembershipType = dbobject.IdMembershipType;
                model.Name = dbobject.Name;
                model.Description = dbobject.Description;
                model.SubscriptionLengthInMonths = dbobject.SubscriptionLengthInMonths;

            }
            return model;
        }

        private MembershipType MapModelToDBObject(MembershipTypeModel model)
        {
            var dbobject = new MembershipType();
            if (dbobject != null)
            {
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
            }
            return dbobject;
        }

        public List<MembershipTypeModel> GetAllMembershipTypes()
        {
            var list = new List<MembershipTypeModel>();
            foreach(var dbobject in _DBContext.MembershipTypes)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public MembershipTypeModel GetMembershipTypeByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id));
        }

        public void InsertMembershipType(MembershipTypeModel model)
        {
            model.IdMembershipType = Guid.NewGuid();
            _DBContext.Members.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateMembershipType(MembershipTypeModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == model.IdMembershipType);
            if(dbobject != null)
            {
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
                _DBContext.SaveChanges();
            }
            
            
        }

        public void DeleteMembershipType(MembershipTypeModel model)
        {
            var dbobject = _DBContext.MembershipType.FirstOrDefault(x => x.IdMembershipType == model.IdMembershipType);
            if(dbobject != null)
            {
                _DBContext.MembershipTypes.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}

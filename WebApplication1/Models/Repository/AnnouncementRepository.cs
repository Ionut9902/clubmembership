using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DBObjects;

namespace WebApplication1.Models.Repository
{
    public class AnnouncementRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public AnnouncementRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }
        private AnnouncementModel MapDBObjectToModel(Annoucement dbobject)
        {
            var model = new AnnouncementModel();
            if(dbobject != null)
            {
                model.IdAnnouncement = dbobject.IdAnnouncement;
                model.ValidFrom = dbobject.ValidFrom;
                model.ValidTo = dbobject.ValidTo;
                model.Title = dbobject.Title;
                model.Text = dbobject.Text;
                model.EventDateTime = dbobject.EventDateTime;
                model.Tags = dbobject.Tags;
            }
            return model;
        }

        private Annoucement MapModelToDBObject(AnnouncementModel model)
        {
            var dbobject = new Annoucement();
            if (dbobject != null)
            {
                dbobject.IdAnnouncement = model.IdAnnouncement;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime = model.EventDateTime;
                dbobject.Tags = model.Tags;
            }
            return dbobject;
        }

        public List<AnnouncementModel> GetAllAnnouncements()
        {
            var list = new List<AnnouncementModel>();
            foreach(var dbobject in _DBContext.Annoucements)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public AnnouncementModel GetAnnouncementByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Annoucements.FirstOrDefault(x => x.IdAnnouncement == id));
        }

        public void InsertAnnouncement(AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid();
            _DBContext.Annoucements.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateAnnouncement(AnnouncementModel model)
        {
            var dbobject = _DBContext.Annoucements.FirstOrDefault(x => x.IdAnnouncement == model.IdAnnouncement);
            if(dbobject != null)
            {
                dbobject.IdAnnouncement = model.IdAnnouncement;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime = model.EventDateTime;
                dbobject.Tags = model.Tags;
                _DBContext.SaveChanges();
            }
            
            
        }

        public void DeleteAnnouncement(AnnouncementModel model)
        {
            var dbobject = _DBContext.Annoucements.FirstOrDefault(x => x.IdAnnouncement == model.IdAnnouncement);
            if(dbobject != null)
            {
                _DBContext.Annoucements.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}

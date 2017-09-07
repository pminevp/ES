using ES.Data;
using ES.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ES.Core.Handlers.Services
{
    public class NotificationService : BaseServices
    {
        public NotificationService(ApplicationDbContext context) : base(context)
        {           
        }

        public NotificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        /// <summary>
        /// Add Notification
        /// </summary>
        /// <param name="notif"></param>
        /// <returns></returns>
        public Notification AddNotification(Notification notif)
        {
            _unitOfWork.Notifications.Add(notif);
            _unitOfWork.SaveChanges();

            return notif;
        }

        public Notification Get(int Id) => _unitOfWork.Notifications.Get(Id);

        public List<Notification> GetGlobalNotifications() => GetAll().Where(x => x.BuildingId == 0).ToList();

        public List<Notification> GetByBuilding(int buildingId) => GetAll().Where(x => x.BuildingId == buildingId).ToList();

        public List<Notification> GetByFloor(int floorId) => GetAll().Where(x => x.BuildingFloorId == floorId).ToList();

        public List<Notification> GetUnread(int buildingId, int floorId)
        {
           return  GetAll().Where(x => (x.BuildingId == 0 || 
                                        x.BuildingId == buildingId || 
                                        x.BuildingFloorId == floorId) && x.IsRead == false ).ToList();
        }


        public Notification SetNotificaitonPin(int notificationId, bool isPinned)
        {
            var notificaiton = _unitOfWork.Notifications.Get(notificationId);

            if (notificaiton == null)
                return null;

            notificaiton.IsPinned = isPinned;

            _unitOfWork.Notifications.Update(notificaiton);
            _unitOfWork.SaveChanges();

            return notificaiton;
        }

        public Notification SetNotificationRead(int notificationId, bool isReaded)
        {
            var notificaiton = _unitOfWork.Notifications.Get(notificationId);

            if (notificaiton == null)
                return null;

            notificaiton.IsRead = isReaded;

            _unitOfWork.Notifications.Update(notificaiton);
            _unitOfWork.SaveChanges();

            return notificaiton;
        }

        private List<Notification> GetAll() => _unitOfWork.Notifications.GetAll().ToList();
    }
}
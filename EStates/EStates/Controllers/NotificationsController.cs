using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ES.Core.Handlers.Services;
using ES.Core.Handlers;
using ES.Data.Models;
using EStates.ViewModels;
using ES.Data.Managers.Interfaces;

namespace EStates.Controllers
{
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private NotificationService _notificationService;
        public IAccountManager _accountManager { get; }

        public NotificationsController(IUnitOfWork unitOfWork, IAccountManager accountManager)
        {
            _notificationService = new NotificationService(unitOfWork);
            _accountManager = accountManager;
        }


        [HttpGet("ByBuilding/{buildingId}")]
        public List<Notification> GetByBuilding(int buildingId)
        {
            var global = _notificationService.GetGlobalNotifications();
            var byBuilding = _notificationService.GetByBuilding(buildingId);
            global.AddRange(byBuilding);

            return global;
        }

        [HttpGet("ByBuilding/{buildingId}/ByFloor/{floorId}")]
        public IEnumerable<Notification> GetByBuildingFloor(int floorId, int buildingId)
        {
            var result = GetByBuilding(buildingId);
            var byfloor = _notificationService.GetByFloor(floorId);
            result.AddRange(byfloor);

            return result;
        }

        [HttpGet("ByBuilding/{buildingId}/ByFloor/{floorId}/unread")]
        public IEnumerable<Notification> GetUnreadedNotifications(int floorId, int buildingId)
        {
            return _notificationService.GetUnread(buildingId, floorId);
        }

        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            return _notificationService.GetGlobalNotifications();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Notification Get(int id) => _notificationService.Get(id);

        // POST api/values
        [HttpPost]
        public async Task<NotificationAddViewModel> Post([FromBody]NotificationAddViewModel newNotification)
        {
            var user = await _accountManager.GetUserByIdAsync(newNotification.ownerId);

            var notification = new Notification
            {
                Body = newNotification.Body,
                BuildingEntranceId = newNotification.BuildingEntranceId,
                BuildingFloorId = newNotification.BuildingFloorId,
                BuildingId = newNotification.BuildingId,
                Creator = user,
                Date = DateTime.Now,
                Header = newNotification.Header

            };

            notification = _notificationService.AddNotification(notification);
            newNotification.Id = notification.Id;

            return newNotification;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpPut("{id}/readable/{isReadable}/")]
        public List<Notification> UpdateIsReadable(int[] id, bool isReadable)
        {
            var listNotif = new List<Notification>();
            foreach (var currentId in id)
            {
                var reuslt = _notificationService.SetNotificationRead(currentId, isReadable);
                listNotif.Add(reuslt);
            }

            return listNotif;
        }

        [HttpPut("{id}/pinned/{isPinned}/")]
        public Notification UpdateIsReadable(int id, bool isPinned)
        {
            return _notificationService.SetNotificaitonPin(id, isPinned);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

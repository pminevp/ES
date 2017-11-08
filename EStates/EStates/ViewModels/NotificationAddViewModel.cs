using System;

namespace EStates.ViewModels
{
    public class NotificationAddViewModel
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public int BuildingId { get; set; }

        public int BuildingEntranceId { get; set; }

        public int BuildingFloorId { get; set; }

        public string ownerId { get; set; }

        public bool IsReaded { get; set; }

        public bool IsPinned { get; set; }

        public DateTime deadline { get; set; }

        public bool haveDeadline { get; set; }
    }
}

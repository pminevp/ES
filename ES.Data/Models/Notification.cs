using System;

namespace ES.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public bool IsRead { get; set; }

        public bool IsPinned { get; set; }

        public DateTime Date { get; set; }

        public int BuildingId { get; set; }

        public int BuildingEntranceId { get; set; }

        public int BuildingFloorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public DateTime? Deadline { get; set; }

        public bool HaveDeadline { get; set; }
    }
}
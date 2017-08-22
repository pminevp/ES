namespace EStates.ViewModels
{
    public class ApartamentViewModel
    {
        public int id { get; set; }

        public int buildingEntranceId { get; set; }

        public int buildingId { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public int parentFloorId { get; set; }

        public string status { get; set; }
    }
}
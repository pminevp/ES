namespace EStates.ViewModels
{
    public class DocumentFileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DocumentId { get; set; }

        public int TypeId { get; set; }

        public string WebPath { get; set; }

        public string DocumentName { get; set; }

        public int BuildingFloorId { get; set; }

        public int BuildingId { get; set; }
    }
}
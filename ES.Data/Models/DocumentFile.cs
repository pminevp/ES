namespace ES.Data.Models
{
    public class DocumentFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DocumentId { get; set; }

        public int BuildingId { get; set; }

        public int BuildingFloorId { get; set; }

        public DocumentDataType Type { get; set; }

        public ApplicationUser creator { get; set; }

        public string WebPath { get; set; }
    }
}
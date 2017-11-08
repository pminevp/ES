using System.ComponentModel.DataAnnotations;

namespace ES.Data.Models
{
    public class DocumentDataType
    {
        [Key]
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
    }
}
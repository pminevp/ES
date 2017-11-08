using ES.Data.Models;
using ES.Data.Repositories.Interfaces;

namespace ES.Data.Repositories
{
    public class DocumentDataTypeRepository :Repository<DocumentDataType> , IDocumentDataTypeRepository
    {
        public DocumentDataTypeRepository(ApplicationDbContext context) : base(context)
        { }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}
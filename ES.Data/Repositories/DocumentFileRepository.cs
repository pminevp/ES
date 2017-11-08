using ES.Data.Models;
using ES.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ES.Data.Repositories
{
    public class DocumentFileRepository : Repository<DocumentFile>, IDocumentFileRepository
    {
        public DocumentFileRepository(DbContext context) : base(context)
        {
        }

        private ApplicationDbContext appContext
        {
            get { return (ApplicationDbContext)_context; }
        }
    }
}

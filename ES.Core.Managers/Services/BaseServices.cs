using ES.Data;

namespace ES.Core.Handlers.Services
{
  public abstract class BaseServices
    {
        protected ApplicationDbContext _context;
        protected IUnitOfWork _unitOfWork;

        public BaseServices(ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }

        public BaseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

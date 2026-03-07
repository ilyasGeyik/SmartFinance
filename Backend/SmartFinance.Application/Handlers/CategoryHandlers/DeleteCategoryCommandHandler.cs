using MediatR;
using SmartFinance.Application.Commands.CategoryCommands;
using SmartFinance.Application.Interfaces; // Repository ve UoW burada demiştik
using SmartFinance.Shared.Constants;
using SmartFinance.Shared.Utilities.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SmartFinance.Application.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Önce veritabanında böyle bir kategori var mı diye ID ile arıyoruz.
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            // Eğer kategori yoksa (null geldiyse), işlem başarısız diyoruz.
            if (category == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            // 2. Kategori bulunduysa depocuya "Bunu sil" diyoruz.
            // (Not: Repository yapına göre metodun adı Remove veya DeleteAsync olabilir, Delete yazdım).
            _categoryRepository.Delete(category);

            // 3. Değişiklikleri kaydet (Commit).
            await _unitOfWork.SaveChangesAsync();

            // 4. API'ye Başarılı tepsisini dön!
            return new SuccessResult(Messages.CategoryDeleted);
        }
    }
}
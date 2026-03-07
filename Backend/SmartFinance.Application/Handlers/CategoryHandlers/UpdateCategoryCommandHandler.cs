using MediatR;
using SmartFinance.Application.Commands.CategoryCommands;
using SmartFinance.Application.Interfaces; // Repository ve UnitOfWork arayüzlerimiz burada
using SmartFinance.Shared.Constants;
using SmartFinance.Shared.Utilities.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SmartFinance.Application.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Önce veritabanında bu ID'ye sahip kategori var mı diye bakıyoruz.
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            // Bulamazsak işlemi iptal et ve hata dön.
            if (category == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            // 2. Kategori bulundu! Şimdi eski verilerin üzerine yenilerini yazıyoruz.
            category.Name = request.Name;
            category.Icon = request.Icon;

            // 3. Depocuya "Bunu güncelle" diyoruz.
            _categoryRepository.Update(category);

            // 4. Değişiklikleri veritabanına yansıt (Commit).
            await _unitOfWork.SaveChangesAsync();

            // 5. API'ye Başarılı tepsisini dön!
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
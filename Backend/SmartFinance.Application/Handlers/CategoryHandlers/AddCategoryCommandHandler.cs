using MediatR;
using SmartFinance.Application.Commands.CategoryCommands;
using SmartFinance.Application.Interfaces;
using SmartFinance.Domain.Entities;
using SmartFinance.Shared.Constants;
using SmartFinance.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Handlers.CategoryHandlers
{
    // IRequestHandler<CreateCategoryCommand, IResult> diyerek diyoruz ki:
    // "Ben bir komandoyum. Bana CreateCategoryCommand emrini getirirsen, karşılığında IResult hazırlarım."
    public class AddCategoryCommandHandler:IRequestHandler<AddCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        // Komandomuz işini yapabilmek için depocuyu (Repository) ve işlem yöneticisini (UnitOfWork) çağırıyor.
        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        // Kurye mektubu getirdiğinde çalışacak asıl metod burası!
        public async Task<IResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Gelen emri (request), veritabanının anlayacağı çiğ "Entity" formatına çeviriyoruz.
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Icon = request.Icon,
                CreatedDate = DateTime.UtcNow //BaseEntity'den gelen alan
            };

            //2. Depocuyu  "Bunu veritabanına ekle" diye çağırıyoruz."

            await _categoryRepository.AddAsync(category);

            // 3. Değişiklikleri UnitOfWork ile onaylıyoruz (Commit).
            await _unitOfWork.SaveChangesAsync();

            // 4. API'ye (Garsona) kendi yazdığımız o şık tepsiyle cevabı dönüyoruz!
            return new SuccessResult(Messages.CategoryAdded);
        }


    }
}

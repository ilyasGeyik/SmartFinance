using MediatR;
using SmartFinance.Application.DTOs.CategoryDtos;
using SmartFinance.Application.Interfaces;
using SmartFinance.Application.Queries.CategoryQueries;
using SmartFinance.Shared.Constants;
using SmartFinance.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Handlers.CategoryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IDataResult<IEnumerable<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // DÜZELTİLDİ: Buradaki parametre GetAllCategoriesQueryHandler'dan GetAllCategoriesQuery'ye çevrildi!
        public async Task<IDataResult<IEnumerable<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Veritabanından bütün kategorileri çekiyoruz.
            var categories = await _categoryRepository.GetAllAsync();

            // Çektiğimiz kategorileri, API'ye (Garsona) göstermek istediğimiz formatta
            // (CategoryDto) dönüştürüyoruz.
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id, // DÜZELTİLDİ: ID yerine Id yazıldı (C# büyük/küçük harf duyarlıdır)
                Name = c.Name,
                Icon = c.Icon
            }).ToList();

            // Son olarak, bu güzel tepsiyi (IDataResult) API'ye geri gönderiyoruz!
            return new SuccessDataResult<IEnumerable<CategoryDto>>(categoryDtos, Messages.CategoryListed);
        }
    }
}
using MediatR;
using SmartFinance.Application.DTOs.CategoryDtos;
using SmartFinance.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Queries.CategoryQueries
{
    // Kuryeye diyoruz ki: "Bu bir listeleme talebidir.
    // Geriye içinde CategoryDto listesi olan dolu bir tepsi (IDataResult) getir."
    public class GetAllCategoriesQuery:IRequest<IDataResult<IEnumerable<CategoryDto>>>
    {
        // Bütün kategorileri çekeceğimiz için dışarıdan hiçbir parametre (Id, isim vb.) istemiyoruz.
        // İçi boş kalacak.
    }
}

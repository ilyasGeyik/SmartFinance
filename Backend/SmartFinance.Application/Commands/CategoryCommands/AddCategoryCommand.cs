using MediatR;
using SmartFinance.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Commands.CategoryCommands
{

    // IRequest<IResult> diyerek MediatR'a diyoruz ki: 
    // "Bu bir emirdir. Bu emir işlenince bana sadece Başarılı/Başarısız durumunu taşıyan(IResult) getir."
    public class AddCategoryCommand:IRequest<IResult>
    {
        //Kullanıcudan kategori eklerken yalnızca istenilen bilgiler eklensin
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
    }
}

using MediatR;
using SmartFinance.Shared.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Commands.CategoryCommands
{
    // Kuryeye diyoruz ki: "Bu bir silme emridir, bana sadece Başarılı/Başarısız tepsisi dön."
    public class DeleteCategoryCommand:IRequest<IResult>
    {
        //sadece id bilsek yeterli silmek için 
        public Guid Id { get; set; }
    }
}

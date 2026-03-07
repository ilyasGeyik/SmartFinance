using MediatR;
using SmartFinance.Shared.Utilities.Results;
using System;

namespace SmartFinance.Application.Commands.CategoryCommands
{
    // Kuryeye diyoruz ki: "Bu bir güncelleme emridir, bana sonucu Başarılı/Başarısız tepsisiyle getir."
    public class UpdateCategoryCommand : IRequest<IResult>
    {
        // Güncellemek için hem ID lazım, hem de yeni veriler lazım.
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Icon { get; set; }
    }
}
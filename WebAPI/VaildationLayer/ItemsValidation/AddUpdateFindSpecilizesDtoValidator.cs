using Dtos.ItemWithSpeclizeDtos;
using FluentValidation;

namespace VaildationLayer.ItemsValidation
{
    public class AddUpdateFindSpecilizesDtoValidator: AbstractValidator<addUpdateSpecilizesDto>
    {
        public AddUpdateFindSpecilizesDtoValidator()
        {
            RuleFor(x => x.specilizeName)
                .NotEmpty().WithMessage("اسم التخصص مطلوب");
        }

    }
}

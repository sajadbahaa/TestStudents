using Dtos;
using FluentValidation;

namespace VaildationLayer
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

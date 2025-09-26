using Dtos.ItemWithSpeclizeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.ItemsValidation
{
    public  class addItemValidation:AbstractValidator<addItemsToSpeiclzeDtos>
    {
        public addItemValidation()
        {
            RuleForEach(x => x.Items).ChildRules
                (x => x.RuleFor(y=>y.itemName).NotEmpty()
                         .WithMessage("لا يمكن ان يكون فارغ")
            );
            RuleFor(x => x.specilizeId).GreaterThan((short)0)
                .WithMessage(" لا يجب ان يكون فارغ ");
        }
    }
}

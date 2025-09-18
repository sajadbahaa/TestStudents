using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer
{
    public  class addItemsFTVaildation:AbstractValidator<addItemsToSpecilzeFirstTimeDtos>
    {
        public addItemsFTVaildation() 
        {
            RuleForEach(x => x.Items).ChildRules(items =>
            {
                items.RuleFor(y => y.itemName)
                     .NotEmpty()
                     .WithMessage("لا يمكن ان يكون فارغ");
            
    // Set Validator applied rules  created in this class before.
                RuleFor(x => x.speclize).SetValidator(new AddUpdateFindSpecilizesDtoValidator());

            });

        }
       
    }
}

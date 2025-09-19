using Dtos.ItemWithSpeclizeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer.ItemsValidation
{
    public  class updateItemsWithSpecilzeValidation:AbstractValidator<UpdateItemsWithSpecilzeDtos>
    { 
        public updateItemsWithSpecilzeValidation()
        {
            RuleFor(x=>x.item).SetValidator(new updateItemsValidation());
            RuleFor(x => x.specilze).SetValidator(new AddUpdateFindSpecilizesDtoValidator());
        }
    }
}

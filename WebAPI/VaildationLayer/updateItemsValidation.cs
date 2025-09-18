using Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VaildationLayer
{
    public  class updateItemsValidation:AbstractValidator<UpdateItemsDto>
    {
        public updateItemsValidation() 
        {
           RuleFor(x=>x.itemID).LessThanOrEqualTo((short)0)
                .WithMessage(" لا يجب ان يكون فارغ ");
            RuleFor(x=>x.itemName).NotEmpty()
                .WithMessage(" لا يجب ان يكون فارغ ");
        }
    }
}

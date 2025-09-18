using AutoMapper;
using DTLayer.Entities;
using Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BsLayer.Services
{
    public  class ItemsService
    {

        readonly SpecilizeRepo _specilizeRepo;
        readonly ItemRepo _itemRepo;
        readonly IMapper _mapper;
        readonly TransactionService _transactionService;
        public ItemsService(SpecilizeRepo specilizeRepo,ItemRepo itemRepo,
            IMapper mapper, TransactionService transactionService)

        {
            _itemRepo = itemRepo;
            _specilizeRepo = specilizeRepo;
            _mapper = mapper;
            _transactionService = transactionService;
        }

        public async Task<List<FindItemsDtos>?> GetAllAsync()
        {
            return _mapper.Map<List<FindItemsDtos>>(await _itemRepo.GetAllAsync());
        }

        public async Task<FindItemsDtos?> GetByIdAsync(short id)
        {
            return _mapper.Map<FindItemsDtos>(await _itemRepo.FindItemDetialsAsync(id));
        }

        public async Task<bool> AddSpecilzeForItemsFirstTimeAsync(addItemsToSpecilzeFirstTimeDtos dto)
        {
            await _transactionService.BeginTransactionAsync();
            // chekc if specilze name exist or not.
            // add speclize new .
            // add item .
            if(await _specilizeRepo.IsExist(dto.speclize.specilizeName))
            {
                await _transactionService.RollbackAsync();
                return false;
            }

           var specilze =  _mapper.Map<Specilzeations>(dto.speclize);

           short Specilzid = await _specilizeRepo.AddAsync(specilze);

            if (Specilzid == 0)
            {
                await _transactionService.RollbackAsync();
                return false; 
            }

            // Map to list<Items>();
            var list = dto.Items.Select(x => new Items(x.itemName, Specilzid)).ToList();

            if (await _itemRepo.IsExistItemName(list))
            {
                await _transactionService.RollbackAsync();
                return false;
            }

            var res = await _itemRepo.AddAsync(list);
            if (!res)
            {
                await _transactionService.RollbackAsync();
                return false;
            }

            // 
            await _transactionService.CommitAsync();
            return true;
        }

        public async Task<bool> AddSpecilzeForItemsAsync(addItemsToSpeiclzeDtos dto)
        {
            await _transactionService.BeginTransactionAsync();
            // chekc if specilze name exist or not.
            // add speclize new .
            // add item .

            // Map to list<Items>();
            var list = dto.Items.Select(x => new Items(x.itemName, dto.specilizeId)).ToList();

            if (await _itemRepo.IsExistItemName(list))
            {
                await _transactionService.RollbackAsync();
                return false;
            }
            var res = await _itemRepo.AddAsync(list);
            if (!res)
            {
                await _transactionService.RollbackAsync();
                return false;
            }

            // 
            await _transactionService.CommitAsync();
            return true;
        }

        public async Task<bool> UpdateItemsAsync (UpdateItemsDto dto)
        {
            var res = await _itemRepo.UpdateAsync(_mapper.Map<Items>(dto));
            return res;
        }

        public async Task<bool> UpdateItemsWithSpecilizeAsync(UpdateItemsWithSpecilzeDtos dto)
        {
            await _transactionService.BeginTransactionAsync();
            var res   = await _specilizeRepo.UpdateAsync(_mapper.Map<Specilzeations>(dto.specilze));
            
            if (!res) 
            {
            await _transactionService.RollbackAsync();
            return false;
            }
           
            res  = await _itemRepo.UpdateAsync(_mapper.Map<Items>(dto.item));
            if (!res)
            {
                await _transactionService.RollbackAsync();
                return false;
            }
             await _transactionService.CommitAsync();
            return res;
        }

        public async Task<bool> DeleteAsync(short id)
        {
            var res = await _itemRepo.DeleteAsync(id);
            return res;
        }


    }
}

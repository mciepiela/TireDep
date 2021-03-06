﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TireDep.Domain.Model;



namespace TireDep.Domain.Interfaces
{
    public interface IDepositRepository
    {
        void DeleteDeposit(int depositId);


       // int AddDeposit(Deposit depositToAdd, Contact contact, Owner owner);
        int AddDeposit(Deposit depositToAdd);

        void UpdateDeposit(Deposit deposit);


         IQueryable<Deposit> GetDepositByOwnerId(int ownerId);

         IQueryable<Deposit> GetDepositByOwnerLastName(string ownerLastName);


         IQueryable<Deposit> GetAllActiveDeposits();
         IQueryable<Deposit> GetAllDepositsByPiceOfName(string piceOfName);


         Deposit GetDepositById(int depositId);
   

        // dodatkowe metody do SeasonTire

        IQueryable<SeasonTire> GetAllSeasonTire();
        SeasonTire GetSeason(int seasonTireId);

        //API
        Task<IEnumerable<Deposit>> ListAsync();
    }


}

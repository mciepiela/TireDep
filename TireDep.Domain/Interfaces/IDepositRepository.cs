﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TireDep.Domain.Model;



namespace TireDep.Domain.Interfaces
{
    public interface IDepositRepository
    {
        void DeleteDeposit(int depositId);


         int AddDeposit(Deposit depositToAdd);

         void UpdateDeposit(Deposit deposit);


         IQueryable<Deposit> GetDepositByOwnerId(int ownerId);

         IQueryable<Deposit> GetDepositByOwnerLastName(string ownerLastName);


         IQueryable<Deposit> GetAllActiveDeposits();


         Deposit GetDepositById(int depositId);
   

        // dodatkowe metody do SeasonTire

        IQueryable<SeasonTire> GetAllSeasonTire();


    }


}

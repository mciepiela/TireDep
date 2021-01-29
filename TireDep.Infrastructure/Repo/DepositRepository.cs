using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;

namespace TireDep.Infrastructure.Repo
{
    public class DepositRepository : IDepositRepository

    {
        private readonly Context _context;
        public DepositRepository(Context context)
        {
            _context = context;
        }

        public void DeleteDeposit(int depositId)
        {
            var depositToDel = _context.Deposits.Find(depositId);
            if (depositToDel != null)
            {
                _context.Deposits.Remove(depositToDel);
                _context.SaveChanges();
            }
        }

        //public int AddDeposit(Deposit depositToAdd, Contact contact, Owner owner)
        //{
        //    _context.Owners.Add(owner);
        //    _context.Contacts.Add(contact);
        //    _context.Deposits.Add(depositToAdd);
        //    _context.SaveChanges();
        //    return depositToAdd.Id;
        //}
        public int AddDeposit(Deposit depositToAdd)
        {
            _context.Deposits.Add(depositToAdd);
            _context.SaveChanges();
            return depositToAdd.Id;
        }

        public void UpdateDeposit(Deposit deposit)
        {
            _context.Deposits.Update(deposit);
            _context.SaveChanges();

        }

        public IQueryable<Deposit> GetDepositByOwnerId(int ownerId)
        {
            var deposits = _context.Deposits.Where(p => p.Owner.Id == ownerId);
            return deposits;
        }

        public IQueryable<Deposit> GetDepositByOwnerLastName(string ownerLastName)
        {
            var deposits = _context.Deposits.Where(p => p.Owner.LastName == ownerLastName);
            return deposits;
        }

        public IQueryable<Deposit> GetAllActiveDeposits()
        {
            var deposits = _context.Deposits.Where(p => p.IsActive == true);
            return deposits;
        }

        public IQueryable<Deposit> GetAllDepositsByPiceOfName(string piceOfName)
        {
            var deposits = _context.Deposits.Where(n => n.Owner.LastName.Contains(piceOfName));
            return deposits;
        }

        public Deposit GetDepositById(int depositId)
        {
            var deposit = _context.Deposits.FirstOrDefault(p => p.Id == depositId);
            return deposit;
        }

        // dodatkowe metody do SeasonTire

        public IQueryable<SeasonTire> GetAllSeasonTire()
        {
            var season = _context.SeasonTires;
            return season;
        }
    }
}

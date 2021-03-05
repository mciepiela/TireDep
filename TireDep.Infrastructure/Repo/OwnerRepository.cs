using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TireDep.Domain.Interfaces;
using TireDep.Domain.Model;

namespace TireDep.Infrastructure.Repo
{


    public class OwnerRepository : IOwnerRepository
    {
        private readonly Context _context;

        public OwnerRepository(Context context)
        {
            _context = context;
        }

        public int AddOwner(Owner ownerToAdd)
        {
            var owner = _context.Owners.Add(ownerToAdd);
            _context.SaveChanges();
            return ownerToAdd.Id;
        }

        public void DeleteOwner(Owner ownerToDel)
        {
            _context.Owners.Remove(ownerToDel);
            _context.SaveChanges();

        }

        public void DeleteOwnerById(int ownerId)
        {
            var owner = _context.Owners.Find(ownerId);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }

        public IQueryable<Owner> GetAllOwners()
        {
            var owners = _context.Owners.Include(x=>x.Contact);
            return owners;
        }

        public IQueryable<Owner> GetAllOwnersByLastName(string lastName)
        {
            var owners = _context.Owners.Where(p => p.LastName.StartsWith(lastName));
            return owners;
        }

        public Owner ReturnOwnerById(int id)
        {
            var owner = _context.Owners.FirstOrDefault(p => p.Id == id);
            return owner;
        }
        //metody do contact

        public int AddNewContactToOwner(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact.Id;
        }
        public void UpdateContactInformation(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();

        }

        public void RemoveContact(int id)
        {
            var contactToRemove = _context.Contacts.FirstOrDefault(p => p.Id == id);
            _context.SaveChanges();
        }

        public IQueryable<Contact> ReturnContactByOwnerId(int ownerId)
        {
            var contacts = _context.Contacts.Where(p => p.Owner.Id == ownerId);
            return contacts;
        }

        public Owner GetOwner(int ownerId)
        {
            var owner = _context.Owners.FirstOrDefault(predicate => predicate.Id == ownerId);
            return owner;
        }

        public Contact GetContact(int ownerRef)
        {
            var contact = _context.Contacts.FirstOrDefault(p => p.OwnerRef == ownerRef);
            return contact;
        }
    }
}

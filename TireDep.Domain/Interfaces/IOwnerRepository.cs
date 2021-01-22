using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TireDep.Domain.Model;

namespace TireDep.Domain.Interfaces
{
     public interface IOwnerRepository
    {
        int AddOwner(Owner ownerToAdd);


        void DeleteOwner(Owner ownerToDel);


        void DeleteOwnerById(int ownerId);


        IQueryable<Owner> GetAllOwners();


        IQueryable<Owner> GetAllOwnersByLastName(string lastName);


        Owner ReturnOwnerById(int id);

        //metody do contact

        int AddNewContactToOwner(Contact contact);

        void UpdateContactInformation(Contact contact);


        void RemoveContact(int id);


        IQueryable<Contact> ReturnContactByOwnerId(int ownerId);
    }
}

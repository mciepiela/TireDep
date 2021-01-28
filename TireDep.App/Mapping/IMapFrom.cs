using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TireDep.App.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
        //void Mapping(NestedProfile nestedProfile);
    }
}

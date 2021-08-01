using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Knight_Pratice.Models
{
    public class DataEntityMapperProfile : Profile
    {
        public DataEntityMapperProfile()
        {
            CreateMap<Data, DataEntity>()
                .ForMember(x => x.Id, y => y.MapFrom(o => o.Data_Id))
                .ForMember(x => x.Input, y => y.MapFrom(o => o.Data_Input))
                .ForMember(x => x.Result, y => y.MapFrom(o => o.Data_Result.ToUpper())).ReverseMap();
        }
    }
}

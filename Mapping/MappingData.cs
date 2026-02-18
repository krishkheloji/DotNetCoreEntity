using AutoMapper;
using DecBatch2025MVCCoreProject.DTO;
using DecBatch2025MVCCoreProject.Models;

namespace DecBatch2025MVCCoreProject.Mapping
{
    public class MappingData : Profile
    {
        public MappingData()
        {
            CreateMap<Emp, EmpDTO>().ForMember(x=>x.mname,x=>x.MapFrom(x=>x.managers.mname!=null? x.managers.mname:"No")).ReverseMap();

            CreateMap<Emp, EmpDTOAdd>().ReverseMap();
            CreateMap<Manager, ManagerDTO>().ReverseMap();
        }
    }
}

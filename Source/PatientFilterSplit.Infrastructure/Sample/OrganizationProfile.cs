using AutoMapper;
using PatientFilterSplit.Dto.Sample;
using PatientFilterSplit.EntityModel.Sample;
using PatientFilterSplit.Model.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientFilterSplit.Infrastructure.Sample
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<UserDto, ElkUser>();
            CreateMap<ElkUser, UserDto>();
        }
    }
}

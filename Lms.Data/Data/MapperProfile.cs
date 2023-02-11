using AutoMapper;
using Lms.Common.DTOs;
using Lms.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lms.Data.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Tournament, TournamentDto>().ReverseMap();

            CreateMap<Game, GameDto>().ReverseMap();


            CreateMap<Tournament, TournamentDto>()
                .ForMember(
                    dest => dest.EndTime,
                    from => from.MapFrom(s=>s.StartDate.AddMonths(3)))
                .ForMember(
                    dest => dest.StartTime,
                    from => from.MapFrom(s => s.StartDate));

            //CreateMap<Tournament, TournamentDto>()
            //    .ForMember(
            //        dest => dest.StartTime,
            //        from => from.MapFrom(s => s.StartDate));



            //CreateMap<Student, StudentDetailsViewModel>()
            //    .ForMember(
            //        dest => dest.NrOfEnrollments,
            //        from => from.MapFrom(s => s.Enrollments.Count));

        }
    }
}

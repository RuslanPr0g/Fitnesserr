using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.Models;

namespace WEBApi.Profiles
{
    public class TrainingProgramProfile : Profile
    {
        public TrainingProgramProfile()
        {
            CreateMap<TrainingProgram, TrainingProgramReadDto>();
            CreateMap<TrainingProgramCreateDto, TrainingProgram>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.EF;
using Core.Entities;
using AutoMapper;
using WEBApi.DTOs;

namespace WEBApi.Profiles
{
    public class TrainingsProfile : Profile
    {
        public TrainingsProfile()
        {
            CreateMap<Training, TrainingReadDto>();
            CreateMap<TrainingCreateDto, Training>();
            CreateMap<TrainingUpdateDto, Training>();
            CreateMap<Training, TrainingUpdateDto>();
        }
    }
}

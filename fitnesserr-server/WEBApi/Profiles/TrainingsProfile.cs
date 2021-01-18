using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.Models;
using AutoMapper;

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

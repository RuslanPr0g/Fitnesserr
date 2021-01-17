﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.DTOs.TrainingDoneDtos;
using WEBApi.Models;

namespace WEBApi.Profiles
{
    public class TrainingDoneProfile : Profile
    {
        public TrainingDoneProfile()
        {
            CreateMap<TrainingDone, TrainingDoneReadDto>();
            CreateMap<TrainingDoneCreateDto, TrainingDone>();
        }
    }
}

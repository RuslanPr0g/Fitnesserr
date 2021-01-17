﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.DTOs.ExerciseDtos;
using WEBApi.Models;

namespace WEBApi.Profiles
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<Exercise, ExerciseReadDto>();
            CreateMap<ExerciseCreateDto, Exercise>();
        }
    }
}

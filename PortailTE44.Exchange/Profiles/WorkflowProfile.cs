﻿using AutoMapper;
using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Exchange.Profiles
{
    public class WorkflowProfile : Profile
    {
        public WorkflowProfile()
        {
            CreateMap<WorkflowCreatePayloadDto, Workflow>();
            CreateMap<Workflow, WorkflowResponseDto>();
            CreateMap<Workflow, WorkflowItemResponseDto>();
            CreateMap<Workflow, WorkflowDuplicatePayloadDto>();
            CreateMap<WorkflowDuplicatePayloadDto, Workflow>();
            CreateMap<Workflow, WorkflowPaginatedResponseDto>().ForMember(dest => dest.Offres, opt => opt.MapFrom(src => src.SousThemes.Select(st => st.Libelle)));
        }
    }
}

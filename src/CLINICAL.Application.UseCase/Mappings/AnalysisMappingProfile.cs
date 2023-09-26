using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile: Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisReponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdReponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();

            CreateMap<UpdateAnalysisCommand, Analysis>();

            //CreateMap<DeleteAnalysisCommand, Analysis>();
        }
    }
}

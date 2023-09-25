using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdReponseDto>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public AnalysisByIdHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository; _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdReponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdReponseDto>();

            try
            {
                var analysis = await _analysisRepository.AnalysisById(request.AnalysisId);

                if(analysis == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Not exists data";
                    return response;
                }

                response.IsSuccess = true;
                response.Data =_mapper.Map<GetAnalysisByIdReponseDto>(analysis);
                response.Message = "Query Success";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
      

    }
}

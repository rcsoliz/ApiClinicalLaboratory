using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalyisHandler : IRequestHandler<GetAllAnalyisQuery, BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>>
{
    private readonly IAnalysisRepository _analysisRepository;
    private readonly IMapper _mapper;

    public GetAllAnalyisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
    {
        _analysisRepository = analysisRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>> Handle(GetAllAnalyisQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>();

        try
        {
            var analysis = await _analysisRepository.ListAnalysis();

            if(analysis is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<GetAllAnalysisReponseDto>>(analysis);
                response.Message = "Consult Success";
            }
        }
        catch (Exception ex)
        {
            response.Message =  ex.Message;
      
        }

        return response;
    }
}

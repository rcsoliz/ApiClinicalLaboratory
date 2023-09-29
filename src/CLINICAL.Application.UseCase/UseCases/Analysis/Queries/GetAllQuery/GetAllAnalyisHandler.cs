using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;
using CLINICAL.Utilities.Constants;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalyisHandler : IRequestHandler<GetAllAnalyisQuery, BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAnalyisHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>> Handle(GetAllAnalyisQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>();

        try
        {
            var analysis = await _unitOfWork.Analysis.GetAllAsync(SP.uspAnalyisList);

            if(analysis is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<GetAllAnalysisReponseDto>>(analysis);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
        }
        catch (Exception ex)
        {
            response.Message =  ex.Message;
      
        }

        return response;
    }
}

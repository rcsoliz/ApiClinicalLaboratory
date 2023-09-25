using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery: IRequest<BaseResponse<GetAnalysisByIdReponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}

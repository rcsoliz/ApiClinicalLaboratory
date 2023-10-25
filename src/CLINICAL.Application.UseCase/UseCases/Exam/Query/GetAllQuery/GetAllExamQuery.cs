using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Query.GetAllQuery
{
    public class GetAllExamQuery: IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {

    }
}

using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Query.GetByIdQuery
{
    public class GetExamByIdQuery : IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}

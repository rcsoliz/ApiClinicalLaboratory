using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Query.GetAllQuery
{
    public class GetAllExamQuery: IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {

    }
}

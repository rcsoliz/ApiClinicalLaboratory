using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;

public class GetAllAnalyisQuery: IRequest<BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>>
{
}

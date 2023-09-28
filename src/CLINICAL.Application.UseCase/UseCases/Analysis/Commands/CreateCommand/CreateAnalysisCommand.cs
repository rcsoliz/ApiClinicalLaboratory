using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;

public class CreateAnalysisCommand : IRequest<BaseResponse<bool>>
{
    public string? Name { get; set; }
}

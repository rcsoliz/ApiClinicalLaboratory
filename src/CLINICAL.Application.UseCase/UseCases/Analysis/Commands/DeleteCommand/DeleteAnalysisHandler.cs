using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Basess;
using CLINICAL.Domain.Entities;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;

public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnalysisHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var parameters = new { request.AnalysisId };
            response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisRemove", parameters);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = "Delete Is Success";
            }

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;    
    }
}

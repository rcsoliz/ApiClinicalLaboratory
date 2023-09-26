﻿using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisCommand: IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}

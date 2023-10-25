﻿using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand
{
    public class ChangeStateExamCommand: IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public int State { get; set; }
    }
}

﻿using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Basess;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;

public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdReponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnalysisByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork; _mapper = mapper;
    }

    public async Task<BaseResponse<GetAnalysisByIdReponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAnalysisByIdReponseDto>();

        try
        {
            var analysis = await _unitOfWork.Analysis.GetByIdAsync(SP.uspAnalysisById,
                request);

            if(analysis == null)
            {
                response.IsSuccess = false;
                response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data =_mapper.Map<GetAnalysisByIdReponseDto>(analysis);
            response.Message = GlobalMessages.MESSAGE_QUERY;

        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
  

}

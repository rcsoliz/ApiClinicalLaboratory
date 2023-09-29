using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Basess;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Query.GetByIdQuery
{
    public class GetExamByIdHandler : IRequestHandler<GetExamByIdQuery, BaseResponse<GetExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetExamByIdResponseDto>> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetExamByIdResponseDto>();

            try
            {
                var exam = await _unitOfWork.Exam.GetByIdAsync(SP.uspExamById,
                    request);

                if(exam is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetExamByIdResponseDto>(exam);
                response.Message = GlobalMessages.MESSAGE_QUERY;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

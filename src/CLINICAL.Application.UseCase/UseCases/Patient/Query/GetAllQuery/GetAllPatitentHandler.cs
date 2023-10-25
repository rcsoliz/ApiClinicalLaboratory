using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Basess;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Query.GetAllQuery
{
    public class GetAllPatitentHandler : IRequestHandler<GetAllPatitentQuery, BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatitentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatitentQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPatientResponseDto>>();

            try
            {
                var patients = await _unitOfWork.Patient.GetAllPatients(SP.uspPatientList);

                if(patients is not null)
                {
                    response.IsSuccess = true;
                    response.Data = patients;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

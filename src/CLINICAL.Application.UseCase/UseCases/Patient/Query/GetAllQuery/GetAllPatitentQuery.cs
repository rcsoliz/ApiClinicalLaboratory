using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Basess;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Query.GetAllQuery
{
    public class GetAllPatitentQuery: IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {

    }
}

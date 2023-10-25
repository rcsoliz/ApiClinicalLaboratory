using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Patient.Query.GetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListPatient")]
        public async Task<IActionResult> ListPatient()
        {
            var response = await _mediator.Send(new GetAllPatitentQuery());
            return Ok(response);
        }
    }
}

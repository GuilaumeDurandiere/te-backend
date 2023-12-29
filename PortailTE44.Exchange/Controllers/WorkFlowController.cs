using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.Common.Utils;
using Microsoft.EntityFrameworkCore;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/workflow")]
    public class WorkflowController
    {
        private readonly IWorkflowService _workflowService;
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(
            IWorkflowService workflowService,
            ILogger<WorkflowController> logger
        )
        {
            _workflowService = workflowService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> GetById(int id)
        {
            WorkflowResponseDto result = await _workflowService.GetById(id);
            return result != null ? Results.Ok(result) : Results.NotFound();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAll(int size, int page)
        {
            IEnumerable<WorkflowItemResponseDto> result = await _workflowService.GetAll();
            return Results.Ok(PaginatedList<WorkflowItemResponseDto>.Create(result.AsQueryable(), page, size));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> Create([FromBody] WorkflowCreatePayloadDto dto)
        {
            WorkflowResponseDto responseDto = await _workflowService.Create(dto);
            return Results.Created("", responseDto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> Update([FromBody] WorkflowUpdatePayloadDto dto)
        {
            WorkflowResponseDto responseDto = await _workflowService.Update(dto);
            return Results.Ok(responseDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IResult> Delete([FromRoute] int id)
        {
            await _workflowService.Delete(id);

            return Results.NoContent();
        }
    }
}

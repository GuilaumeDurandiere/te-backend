using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.Common.Utils;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/workflow")]
    public class WorkflowController
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowController(
            IWorkflowService workflowService
        )
        {
            _workflowService = workflowService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<WorkflowResponseDto> GetById(int id)
        {
            return await _workflowService.GetById(id);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<PaginatedList<WorkflowItemResponseDto>> GetAll(int size, int page)
        {
            IEnumerable<WorkflowItemResponseDto> result = await _workflowService.GetAll();
            return PaginatedList<WorkflowItemResponseDto>.Create(result.AsQueryable(), page, size);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<WorkflowResponseDto> Create([FromBody] WorkflowCreatePayloadDto dto)
        {
            return await _workflowService.Create(dto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<WorkflowResponseDto> Update([FromBody] WorkflowUpdatePayloadDto dto)
        {
            return await _workflowService.Update(dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task Delete([FromRoute] int id)
        {
            await _workflowService.Delete(id);
        }
    }
}

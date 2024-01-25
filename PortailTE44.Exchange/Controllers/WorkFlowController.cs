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

        [HttpGet("getActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<WorkflowItemResponseDto>> GetAllActive()
        {
            return await _workflowService.GetAllActive();
        }

        [HttpGet("paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public PaginatedList<WorkflowPaginatedResponseDto> GetAllPaginated(int size, int page)
        {
            return _workflowService.GetAllPaginated(size, page);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<WorkflowResponseDto> Create([FromBody] WorkflowCreatePayloadDto dto)
        {
            return await _workflowService.Create(dto);
        }

        [HttpPost("duplicate")]
        public async Task<WorkflowResponseDto> Duplicate(int id, string libelle)
        {
            return await _workflowService.Duplicate(id, libelle);
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

        [HttpGet("nameExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool NameExists(string name)
        {
            return _workflowService.NameAlreadyExists(name);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Workflow;

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

        [HttpGet]
        public async Task<WorkflowResponseDto> GetById(int id)
        {
            return await _workflowService.GetById(id);
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<WorkflowItemResponseDto>> GetAll()
        {
            return await _workflowService.GetAll();
        }

        [HttpPost("Create")]
        public async Task<WorkflowResponseDto> Create([FromBody] WorkflowCreatePayloadDto dto)
        {
            return await _workflowService.Create(dto);
        }

        [HttpPut("Update")]
        public async Task<WorkflowResponseDto> Update([FromBody] WorkflowUpdatePayloadDto dto)
        {
            return await _workflowService.Update(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _workflowService.Delete(id);
        }
    }
}

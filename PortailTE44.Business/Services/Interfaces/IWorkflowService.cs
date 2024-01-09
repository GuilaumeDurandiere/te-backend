using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;

namespace PortailTE44.Business.Services.Interfaces
{
    public interface IWorkflowService : IGenericService<Workflow>
    {
        Task<WorkflowResponseDto> Create(WorkflowCreatePayloadDto dto);
        Task<WorkflowResponseDto> GetById(int id);
        Task<IEnumerable<WorkflowItemResponseDto>> GetAllActive();
        Task<WorkflowResponseDto> Update(WorkflowUpdatePayloadDto dto);
        Task Delete(int id);
        PaginatedList<WorkflowPaginatedResponseDto> GetAllPaginated(int size, int page);
        Task<WorkflowResponseDto> Duplicate(int id);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.Common.Utils;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class WorkflowService : GenericService<Workflow>, IWorkflowService
    {
        public WorkflowService(
            IWorkflowRepository repository,
            IMapper mapper
        ) : base(repository, mapper)
        {
        }

        public async Task<WorkflowResponseDto> Create(WorkflowCreatePayloadDto dto)
        {
            if (NameAlreadyExists(dto.Libelle))
                throw new ArgumentException("WORKFLOW_NAME_ALREADY_EXISTS");

            if (dto.Etapes is null || !dto.Etapes.Any())
                throw new ArgumentException("Un workflow doit posséder au moins une étape");

            Workflow workflow = _mapper.Map<WorkflowCreatePayloadDto, Workflow>(dto);
            workflow.Actif = true;
            _repository.Add(workflow);
            await _repository.SaveAsync();
            return _mapper.Map<Workflow, WorkflowResponseDto>(workflow);
        }

        public async Task<WorkflowResponseDto> GetById(int id)
        {
            Workflow? workflow = await _repository.GetByIdAsync(id);
            if (workflow is null)
                throw new KeyNotFoundException($"Le workflow avec l'id {id} n'existe pas");

            return _mapper.Map<Workflow, WorkflowResponseDto>(workflow);
        }

        public async Task<IEnumerable<WorkflowItemResponseDto>> GetAllActive()
        {
            IEnumerable<Workflow> workflows = await _repository.GetAll()
                                                               .Where(w => w.Actif)
                                                               .ToListAsync();
            return _mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowItemResponseDto>>(workflows);
        }

        public PaginatedList<WorkflowPaginatedResponseDto> GetAllPaginated(int size, int page)
        {
            IQueryable<Workflow> workflows = _repository.GetAll();
            IQueryable<Workflow> results = workflows.Skip((page - 1) * size).Take(size);
            return new PaginatedList<WorkflowPaginatedResponseDto>
            {
                Results = _mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowPaginatedResponseDto>>(results),
                Total = workflows.Count(),
                PageIndex = page,
                PageSize = size,
            };
        }

        public async Task<WorkflowResponseDto> Update(WorkflowUpdatePayloadDto dto)
        {
            Workflow? workflow = await _repository.GetByIdAsync(dto.Id);
            if (workflow is null)
                throw new KeyNotFoundException($"Le workflow avec l'id {dto.Id} n'existe pas");

            if (NameAlreadyExists(dto.Libelle, dto.Id))
                throw new ArgumentException("WORKFLOW_NAME_ALREADY_EXISTS");

            workflow.Libelle = dto.Libelle;
            workflow.Actif = dto.Actif;
            _repository.Update(workflow);
            await _repository.SaveAsync();
            return _mapper.Map<Workflow, WorkflowResponseDto>(workflow);
        }

        public async Task Delete(int id)
        {
            Workflow? workflow = await _repository.GetByIdAsync(id);
            if (workflow is null)
                throw new KeyNotFoundException($"Le workflow avec l'id {id} n'existe pas");

            _repository.Delete(workflow);
            await _repository.SaveAsync();
        }

        public async Task<WorkflowResponseDto> Duplicate(int id, string libelle)
        {
            Workflow? originalWorkflow = await _repository.GetByIdAsync(id);
            if (originalWorkflow is null)
                throw new KeyNotFoundException($"Le workflow avec l'id {id} n'existe pas");

            if (NameAlreadyExists(libelle))
                throw new ArgumentException("WORKFLOW_NAME_ALREADY_EXISTS");

            WorkflowDuplicatePayloadDto workflow = _mapper.Map<Workflow, WorkflowDuplicatePayloadDto>(originalWorkflow);
            Workflow duplicateWorkflow = _mapper.Map<WorkflowDuplicatePayloadDto, Workflow>(workflow);
            duplicateWorkflow.Libelle = libelle;
            duplicateWorkflow.Actif = originalWorkflow.Actif;
            _repository.Add(duplicateWorkflow);
            await _repository.SaveAsync();
            return _mapper.Map<Workflow, WorkflowResponseDto>(duplicateWorkflow);
        }

        public bool NameAlreadyExists(string name, int? idToIgnore = null)
        {
            IQueryable<Workflow> query = _repository.GetAll();
            if (idToIgnore != null)
                query = query.Where(x => x.Id != idToIgnore);

            return query.Any(wf => wf.Libelle == name);
        }
    }
}

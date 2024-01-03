using AutoMapper;
using Microsoft.Extensions.Logging;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.Workflow;
using PortailTE44.DAL.Entities;
using PortailTE44.DAL.Repositories.Interfaces;

namespace PortailTE44.Business.Services
{
    public class WorkflowService : GenericService<Workflow>, IWorkflowService
    {
        ILogger<WorkflowService> _logger;
        public WorkflowService(
            IWorkflowRepository repository,
            IMapper mapper,
            ILogger<WorkflowService> logger
        ) : base(repository, mapper) {
            _logger = logger;
        }

        public async Task<WorkflowResponseDto> Create(WorkflowCreatePayloadDto dto)
        {
            if (dto.Etapes is null || !dto.Etapes.Any())
            {
                _logger.LogInformation("Un workflow doit posséder au moins une étape");
                throw new ArgumentException("Un workflow doit posséder au moins une étape");
            }
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
            {
                _logger.LogInformation($"Le workflow avec l'id {id} n'existe pas");
                throw new KeyNotFoundException($"Le workflow avec l'id {id} n'existe pas");
            }
            return _mapper.Map<Workflow, WorkflowResponseDto>(workflow);
        }

        public async Task<IEnumerable<WorkflowItemResponseDto>> GetAll()
        {
            IEnumerable<Workflow> workflows = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Workflow>, IEnumerable<WorkflowItemResponseDto>>(workflows);
        }

        public async Task<WorkflowResponseDto> Update(WorkflowUpdatePayloadDto dto)
        {
            Workflow? workflow = await _repository.GetByIdAsync(dto.Id);
            if (workflow is null)
            {
                _logger.LogInformation($"Le workflow avec l'id {dto.Id} n'existe pas");
                throw new KeyNotFoundException($"Le workflow avec l'id {dto.Id} n'existe pas");
            }
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
            {
                _logger.LogInformation($"Le workflow avec l'id {id} n'existe pas");
                throw new KeyNotFoundException($"Le workflow avec l'id {id} n'existe pas");
            }
            _repository.Delete(workflow);
            await _repository.SaveAsync();
        }
    }
}

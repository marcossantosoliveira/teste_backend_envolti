
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Entities;
using TesteBackend.Domain.Interfaces.Repository;
using TesteBackend.Domain.Interfaces.Services;

namespace TesteBackend.Domain.Services.Services
{
    public class TarefaService : ITarefaDomainService
    {

        private readonly ITarefaDomainRepository _tarefaRepository;

        public TarefaService(ITarefaDomainRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<TarefaResponseDto>> BuscarTarefasAsync()
        {
            var tarefasRepo = _tarefaRepository.BuscarTarefasAsync().Result;
            var tarefas = new List<TarefaResponseDto>();

            foreach (var item in tarefasRepo)
            {
                var tarefaItem = new TarefaResponseDto
                {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Concluida = item.Concluida
                };

                tarefas.Add(tarefaItem);
            }

            return tarefas;
        }

        public async Task<TarefaResponseDto> BuscarTarefasPorIdAsync(int id)
        {
            var tarefaRepo = await _tarefaRepository.BuscarTarefasPorIdAsync(id);
            var tarefa = new TarefaResponseDto();

            tarefa.Id = tarefaRepo.Id;
            tarefa.Titulo = tarefaRepo.Titulo;
            tarefa.Concluida = tarefaRepo.Concluida;

            return tarefa;
        }

        public async Task<int> CriarTarefaAsync(TarefaDto tarefa)
        {

            var tarefaEnti = new TarefaEntities();
           
            tarefaEnti.Titulo = tarefa.Titulo;
            tarefaEnti.Concluida = tarefa.Concluida;

            var tarefaId = await _tarefaRepository.CriarTarefaAsync(tarefaEnti);

            return tarefaId;
        }

        public async Task<bool> EditarTarefaAsync(int id, TarefaDto tarefa)
        {
            var tarefaEnti = new TarefaEntities();          

            tarefaEnti.Id = tarefa.Id;
            tarefaEnti.Titulo = tarefa.Titulo;
            tarefaEnti.Concluida = tarefa.Concluida;

            var tarefaRepo = await _tarefaRepository.EditarTarefaAsync(id, tarefaEnti);            

            return tarefaRepo;
        }

        public async Task<bool> ExcluirTarefaAsync(int id)
        {
            var tarefaRepo = await _tarefaRepository.ExcluirTarefaAsync(id);

            return tarefaRepo;
        }
    }
}

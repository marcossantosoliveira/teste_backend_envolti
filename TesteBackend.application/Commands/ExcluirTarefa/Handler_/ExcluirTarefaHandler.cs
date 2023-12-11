using MediatR;
using TesteBackend.Application.Commands.ExcluirTarefa.Dto_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Interfaces.Services;

namespace TesteBackend.Application.Commands.CriarTarefa.Handler_
{
    public class ExcluirTarefaHandler : IRequestHandler<ExcluirTarefaRequestDto, ExcluirTarefaResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public ExcluirTarefaHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<ExcluirTarefaResponseDto> Handle(ExcluirTarefaRequestDto request, CancellationToken cancellationToken)
        {       
         
            var tarefaResponse = new ExcluirTarefaResponseDto();

            if (request == null)
            {
                tarefaResponse.Mensagem = "Todos os campos são obrigatório";

                return tarefaResponse;
            }                        
      
            var tarefaRetornoService = await _tarefaService.ExcluirTarefaAsync(request.Id);

            if (!tarefaRetornoService)
            {
                tarefaResponse.Mensagem = "Não foi possivel excluir tarefa";

                return tarefaResponse;
            }

            tarefaResponse.Mensagem = "Tarefa excluida com sucesso";
           
            return tarefaResponse;
        }
    }
}

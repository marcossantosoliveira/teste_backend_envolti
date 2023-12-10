using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Application.Commands.CriarTarefa.Dto_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Interfaces.Services;

namespace TesteBackend.Application.Commands.CriarTarefa.Handler_
{
    public class CriarTarefaHandler : IRequestHandler<CriarTarefaRequestDto, CriarTarefaResponseDto>
    {

        private readonly ITarefaDomainService _tarefaService;

        public CriarTarefaHandler(ITarefaDomainService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public async Task<CriarTarefaResponseDto> Handle(CriarTarefaRequestDto request, CancellationToken cancellationToken)
        {         

            var tarefaDto = new TarefaDto();            
            var tarefaResponse = new CriarTarefaResponseDto();

            if (request == null)
            {
                tarefaResponse.menssagem = "Todos os campos são obrigatório";

                return tarefaResponse;
            }
                        
            tarefaDto.Titulo = request.Titulo;
            tarefaDto.Concluida = request.Concluida;

            var tarefaRetornoService = await _tarefaService.CriarTarefaAsync(tarefaDto);

            if (tarefaRetornoService ==  null)
            {
                tarefaResponse.menssagem = "Erro ao criar tarefa";

                return tarefaResponse;
            }

            tarefaResponse.menssagem = "Tarefa cadastrada com sucesso";
            tarefaResponse.Id = tarefaRetornoService;

            return tarefaResponse;
        }
    }
}

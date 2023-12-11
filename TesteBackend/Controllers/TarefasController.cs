using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteBackend.Application.Commands.CriarTarefa.Dto_;
using TesteBackend.Application.Commands.EditarTarefa.Dto_;
using TesteBackend.Application.Commands.ExcluirTarefa.Dto_;
using TesteBackend.Application.Queries.BuscarTarefas.Dto_;
using TesteBackend.Application.Queries.BuscarTerefaPorId.Dto_;

namespace TesteBackend.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {



        [HttpGet]
        public Task<List<BuscarTarefasResponseDto>> BuscarTodos([FromServices] IMediator mediator)
        {

            var tarefasRequest = new BuscarTarefasRequestDto();
            var tarefas = mediator.Send(tarefasRequest);

            return tarefas;

        }

        [HttpGet("id")]
        public Task<BuscarTarefaPorIdResponseDto> BuscarPorId([FromServices] IMediator mediator, int id)
        {

            var tarefaRequest = new BuscarTarefaPorIdRequestDto()
            {
                Id = id
            };

            var tarefa = mediator.Send(tarefaRequest);

            return tarefa;

        }

        [HttpPost]
        public Task<CriarTarefaResponseDto> Criar([FromServices] IMediator mediator,
                                                 CriarTarefaRequestDto tarefaRequest)
        {

            var tarefa = mediator.Send(tarefaRequest);

            return tarefa;

        }

        [HttpPut("id")]
        public Task<EditarTarefaResponseDto> Editar([FromServices] IMediator mediator,
                                                    EditarTarefaRequestDto tarefaRequest,
                                                    int id)
        {

            tarefaRequest.Id = id;
            var tarefa = mediator.Send(tarefaRequest);

            return tarefa;

        }

        [HttpDelete("id")]
        public Task<ExcluirTarefaResponseDto> Excluir([FromServices] IMediator mediator, 
                                                       int id)
        {
            var tarefaRequest = new ExcluirTarefaRequestDto
            {
                Id = id
            };

            var tarefa = mediator.Send(tarefaRequest);

            return tarefa;

        }
    }
}

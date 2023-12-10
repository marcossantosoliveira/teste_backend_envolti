using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteBackend.Application.Commands.CriarTarefa.Dto_;

namespace TesteBackend.Controllers
{
    [Route("api/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        

        //[HttpGet]
        //public async IActionResult BuscarTodos(CriarTarefaRequestDto tarefaRequest)
        //{

            

        //}

        //[HttpGet("id")]
        //public IActionResult BuscarPorId(int id)
        //{



        //}

        [HttpPost]
        public Task<CriarTarefaResponseDto> Criar([FromServices]IMediator mediator, 
                                                 CriarTarefaRequestDto tarefaRequest)
        {

            var tarefa = mediator.Send(tarefaRequest);

            return tarefa;

        }

        //[HttpPut("id")]
        //public IActionResult Editar(Tarefa tarefa)
        //{



        //}

        //[HttpDelete("id")]
        //public IActionResult Excluir(int id)
        //{



        //}
    }
}

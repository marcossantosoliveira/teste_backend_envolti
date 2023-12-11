using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Application.Commands.CriarTarefa.Handler_;
using TesteBackend.Application.Commands.EditarTarefa.Dto_;
using TesteBackend.Application.Commands.EditarTarefa.Handler_;
using TesteBackend.Application.Commands.ExcluirTarefa.Dto_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Services.Services;
using Xunit;

namespace TesteBackend.Tests.ApisCommands.Tarefas.ExcluirTarefa
{
    public class ExcluirTarefaHandlerTestCase
    {
        [Fact]
        public async void ExcluirTarefaComSucesso()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var excluirTarefaServiceMock = new Mock<TarefaService>();                
                int id = 0;

                excluirTarefaServiceMock.Setup(s => s.ExcluirTarefaAsync(id)).ReturnsAsync(true);

                var excluirTarefa = new ExcluirTarefaRequestDto()
                {
                };

                var excluirTarefaHandler = new ExcluirTarefaHandler(excluirTarefaServiceMock.Object);

                var tarefaResponse = await excluirTarefaHandler.Handle(excluirTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Tarefa excluida com sucesso");

            }

        }

        [Fact]
        public async void ExcluirTarefaqueNaoFoiConcluidaErro()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var excluirTarefaServiceMock = new Mock<TarefaService>();                
                int id = 1;

                var excluirTarefa = new ExcluirTarefaRequestDto()
                {
                };

                excluirTarefaServiceMock.Setup(s => s.ExcluirTarefaAsync(id)).ReturnsAsync(false);

                var excluirTarefaHandler = new ExcluirTarefaHandler(excluirTarefaServiceMock.Object);

                var tarefaResponse = await excluirTarefaHandler.Handle(excluirTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Não é possivel excluir tarefa que não foi concluida");

            }

        }       
    }
}

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Application.Commands.CriarTarefa.Dto_;
using TesteBackend.Application.Commands.CriarTarefa.Handler_;
using TesteBackend.Application.Commands.EditarTarefa.Dto_;
using TesteBackend.Application.Commands.EditarTarefa.Handler_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Services.Services;
using Xunit;

namespace TesteBackend.Tests.ApisCommands.Tarefas.EditarTarefa
{
    public class EditarTarefaHandlerTestCase
    {


        [Fact]
        public async void EditarTarefaComSucesso()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var editarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = false;
                int id = 0;


                editarTarefaServiceMock.Setup(s => s.EditarTarefaAsync(
                                                         id, tarefaDto
                    )).ReturnsAsync(true);

                var editarTarefa = new EditarTarefaRequestDto()
                {
                    Titulo = "teste",
                    Concluida = true
                };

                var editarTarefaHandler = new EditarTarefaHandler(editarTarefaServiceMock.Object);

                var tarefaResponse = await editarTarefaHandler.Handle(editarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Tarefa Editada com sucesso");
            }

        }

        [Fact]
        public async void EditarTarefaConcluidaErro()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var editarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = true;
                int id = 1;


                editarTarefaServiceMock.Setup(s => s.EditarTarefaAsync(
                    id,
                    tarefaDto
                    )).ReturnsAsync(null);

                var editarTarefa = new EditarTarefaRequestDto()
                {
                    Titulo = "teste",
                    Concluida = true
                };

                var editarTarefaHandler = new EditarTarefaHandler(editarTarefaServiceMock.Object);

                var tarefaResponse = await editarTarefaHandler.Handle(editarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Tarefa ja foi concluida");

            }

        }

        [Fact]
        public async void EditarTarefaComRequestVazio()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var editarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = true;
                int id = 1;


                editarTarefaServiceMock.Setup(s => s.EditarTarefaAsync(
                    id,
                    tarefaDto
                    )).ReturnsAsync(null);

                var editarTarefa = new EditarTarefaRequestDto()
                {
                };

                var editarTarefaHandler = new EditarTarefaHandler(editarTarefaServiceMock.Object);

                var tarefaResponse = await editarTarefaHandler.Handle(editarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Todos os campos são obrigatório");

            }

        }

    }
}

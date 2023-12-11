using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackend.Application.Commands.CriarTarefa.Dto_;
using TesteBackend.Application.Commands.CriarTarefa.Handler_;
using TesteBackend.Domain.Dto_;
using TesteBackend.Domain.Services.Services;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TesteBackend.Tests.ApisCommands.Tarefas.CriarTarefa
{
    public class CriarTarefaHandlerTestCase
    {


        [Fact]
        public async void CriarTarefaComSucesso()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var criarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = true;



                criarTarefaServiceMock.Setup(s => s.CriarTarefaAsync(
                    tarefaDto
                    )).ReturnsAsync(1);

                var criarTarefa = new CriarTarefaRequestDto()
                {
                    Titulo = "teste",
                    Concluida = true
                };

                var criarTarefaHandler = new CriarTarefaHandler(criarTarefaServiceMock.Object);

                var tarefaResponse = await criarTarefaHandler.Handle(criarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Tarefa cadastrada com sucesso");
            }

        }

        [Fact]
        public async void CriarTarefaComErro()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var criarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = true;



                criarTarefaServiceMock.Setup(s => s.CriarTarefaAsync(
                    tarefaDto
                    )).ReturnsAsync(null);

                var criarTarefa = new CriarTarefaRequestDto()
                {
                    Titulo = "teste",
                    Concluida = true
                };

                var criarTarefaHandler = new CriarTarefaHandler(criarTarefaServiceMock.Object);

                var tarefaResponse = await criarTarefaHandler.Handle(criarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Erro ao criar tarefa");

            }

        }

        [Fact]
        public async void CriarTarefaComRequestVazio()
        {
            using (var cts = new CancellationTokenRegistration())
            {

                var criarTarefaServiceMock = new Mock<TarefaService>();

                var tarefaDto = new TarefaDto();
                tarefaDto.Titulo = "teste";
                tarefaDto.Concluida = true;



                criarTarefaServiceMock.Setup(s => s.CriarTarefaAsync(
                    tarefaDto
                    )).ReturnsAsync(null);

                var criarTarefa = new CriarTarefaRequestDto()
                {
                };

                var criarTarefaHandler = new CriarTarefaHandler(criarTarefaServiceMock.Object);

                var tarefaResponse = await criarTarefaHandler.Handle(criarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                Assert.Equal(tarefaResponse.Mensagem, "Todos os campos são obrigatório");

            }

        }
    }
}

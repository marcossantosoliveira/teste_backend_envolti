﻿using Moq;
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
        public void CriarTarefaComSucesso()
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

                var tarefaResponse =  criarTarefaHandler.Handle(criarTarefa, cts.Token);

                Assert.NotNull(tarefaResponse);
                

            }


        }
    }
}

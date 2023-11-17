using System.ComponentModel;

namespace Estapar.Garagens.Application.Enums
{
    public enum ProcessamentoBaseExternaEnum
    {
        [Description("Base de dados não Localizada")]
        NaoLocalizada = 0,

        [Description("Base de dados processada com Sucesso")]
        ProcessadaComSucesso = 1,

        [Description("Base de dados já foi Processada")]
        JaProcessada = 2,

        [Description("Erro ao Processar a Base de dados externa")]
        ErroAoProcessar = 3
    }
}

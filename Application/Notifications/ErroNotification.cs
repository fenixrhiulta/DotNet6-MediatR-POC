using MediatR;

namespace MediatRSample.Application.Notifications;

public class ErroNotification : INotification
{
    public ErroNotification(string excecao, string pilhaErro)
    {
        this.Excecao = excecao;
        this.PilhaErro = pilhaErro;

    }
    public string Excecao { get; set; }
    public string PilhaErro { get; set; }
}
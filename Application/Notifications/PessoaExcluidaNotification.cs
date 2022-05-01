using MediatR;

namespace MediatRSample.Application.Notifications;

public class PessoaExcluidaNotification : INotification
{
    public PessoaExcluidaNotification(int id, bool isEfetivado)
    {
        this.Id = id;
        this.IsEfetivado = isEfetivado;
    }
    public int Id { get; set; }
    public bool IsEfetivado { get; set; }
}
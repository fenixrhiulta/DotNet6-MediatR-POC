using MediatR;

namespace MediatRSample.Application.Notifications;
public class PessoaAlteradaNotification : INotification
{
    public PessoaAlteradaNotification(int id, string nome, int idade, char sexo, bool isEfetivado)
    {
        this.Id = id;
        this.Nome = nome;
        this.Idade = idade;
        this.Sexo = sexo;
        this.IsEfetivado = isEfetivado;

    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
    public bool IsEfetivado { get; set; }
}
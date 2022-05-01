using MediatR;

public class CadastraPessoaCommand : IRequest<string>
{
    public CadastraPessoaCommand(string nome, int idade, char sexo)
    {
        this.Nome = nome;
        this.Idade = idade;
        this.Sexo = sexo;

    }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
}
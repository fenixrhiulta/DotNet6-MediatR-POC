using MediatR;

public class AlteraPessoaCommand : IRequest<string>
{
    public AlteraPessoaCommand(int id, string nome, int idade, char sexo)
    {
        this.Id = id;
        this.Nome = nome;
        this.Idade = idade;
        this.Sexo = sexo;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
}
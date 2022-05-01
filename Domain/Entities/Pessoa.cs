namespace MediatRSample.Domain.Entities;

public class Pessoa
{
    public Pessoa(string nome, int idade, char sexo)
    {
        this.Nome = nome;
        this.Idade = idade;
        this.Sexo = sexo;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public char Sexo { get; set; }
}
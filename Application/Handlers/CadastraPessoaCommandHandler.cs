using MediatR;
using MediatRSample.Application.Notifications;
using MediatRSample.Domain.Entities;
using MediatRSample.Infrastructure.Repository;

namespace MediatRSample.Application.Handlers;
public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Pessoa> _repository;
    public CadastraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
    {
        this._mediator = mediator;
        this._repository = repository;
    }

    public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
    {
        var pessoa = new Pessoa(request.Nome, request.Idade, request.Sexo);

        try
        {
            pessoa = await _repository.Add(pessoa);

            await _mediator.Publish(new PessoaCriadaNotification(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Sexo));

            return await Task.FromResult("Pessoa criada com sucesso");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new PessoaCriadaNotification(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Sexo));
            await _mediator.Publish(new ErroNotification(ex.Message, ex.StackTrace));
            return await Task.FromResult("Ocorreu um erro no momento da criação");
        }

    }
}
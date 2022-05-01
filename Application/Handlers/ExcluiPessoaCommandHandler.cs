using MediatR;
using MediatRSample.Application.Notifications;
using MediatRSample.Domain.Entities;
using MediatRSample.Infrastructure.Repository;

namespace MediatRSample.Application.Handlers;

public class ExcluiPessoaCommandHandler : IRequestHandler<ExcluiPessoaCommand, string>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Pessoa> _repository;
    public ExcluiPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
    {
        this._mediator = mediator;
        this._repository = repository;
    }

    public async Task<string> Handle(ExcluiPessoaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Delete(request.Id);

            await _mediator.Publish(new PessoaExcluidaNotification(request.Id, true));

            return await Task.FromResult("Pessoa excluída com sucesso");
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new PessoaExcluidaNotification(request.Id, false));
            await _mediator.Publish(new ErroNotification(ex.Message, ex.StackTrace));
            return await Task.FromResult("Ocorreu um erro no momento da exclusão");
        }

    }
}
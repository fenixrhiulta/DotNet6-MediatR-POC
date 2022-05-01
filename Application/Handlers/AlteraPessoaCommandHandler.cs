using MediatR;
using MediatRSample.Application.Notifications;
using MediatRSample.Domain.Entities;
using MediatRSample.Infrastructure.Repository;

namespace MediatRSample.Application.Handlers
{
    public class AlteraPessoaCommandHandler : IRequestHandler<AlteraPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;
        public AlteraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlteraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa(request.Nome, request.Idade, request.Sexo);

            try
            {
                await _repository.Edit(pessoa);

                await _mediator.Publish(new PessoaAlteradaNotification(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Sexo, true));

                return await Task.FromResult("Pessoa alterada com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new PessoaAlteradaNotification(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Sexo, false));
                await _mediator.Publish(new ErroNotification(ex.Message, ex.StackTrace));
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

        }
    }
}
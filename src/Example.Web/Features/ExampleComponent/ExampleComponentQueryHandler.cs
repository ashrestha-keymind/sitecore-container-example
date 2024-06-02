namespace Example.Web.Features.ExampleComponent
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class ExampleComponentQuery : IRequest<ExampleComponentViewModel>
    {
    }

    public class ExampleComponentQueryHandler : IRequestHandler<ExampleComponentQuery, ExampleComponentViewModel>
    {
        public Task<ExampleComponentViewModel> Handle(ExampleComponentQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ExampleComponentViewModel());
        }
    }
}

using MediatR;

namespace PfMsSalesPlatform.Application.Commands.Clients
{
    public record DeleteClientTypeCommand(int Id): IRequest<bool>;
}

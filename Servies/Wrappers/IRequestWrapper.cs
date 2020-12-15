using MediatR;

namespace Servies.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    { }

    public interface IHandlerWrapper<Tin, TOut> : IRequestHandler<Tin, Response<TOut>>
        where Tin : IRequestWrapper<TOut> { }
}

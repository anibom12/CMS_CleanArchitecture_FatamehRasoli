using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RestApi.Common;

public class QueryBus:IQueryBus
{
    private readonly ISender _sender;

    public QueryBus(ISender sender)
    {
        _sender = sender;
    }

    public Task<TResult> DispatchAsync<TResult>(IRequest<TResult> query, CancellationToken token = default)
    {
        return _sender.Send(query, token);
    }
}

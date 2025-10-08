using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RestApi.Common;

public interface ICommandBus
{

    Task<TResult> DispatchAsync<TResult>(IRequest<TResult> command, CancellationToken token = default);
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RestApi.Common;

public class BaseController:ControllerBase
{
    protected readonly ICommandBus commandBus;
    protected readonly IQueryBus queryBus;
    public BaseController(ICommandBus commandBus, IQueryBus queryBus)
    {
        this.commandBus = commandBus;
        this.queryBus = queryBus;
    }
}

﻿using App.Metrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteLiterature.Works.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected readonly IMetrics Metrics;
    protected readonly ILogger Logger;

    public BaseApiController(IMediator mediator, IMetrics metrics, ILogger logger)
    {
        Mediator = mediator;
        Metrics = metrics;
        Logger = logger;
    }
}
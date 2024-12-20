﻿using Microsoft.AspNetCore.Mvc;
using TestProject.API.Contracts;
using TestProject.Domain.Base;

namespace TestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApplicationController : ControllerBase
    {
        protected new ActionResult Ok(object? result = null)
        {
            var envelope = Envelope.Ok(result);

            return base.Ok(envelope);
        }

        protected IActionResult BadRequest(Error? error)
        {
            var errorInfo = new ErrorInfo(error);

            var envelope = Envelope.Error(errorInfo);

            return base.BadRequest(envelope);
        }

        protected IActionResult NotFound(Error? error)
        {
            var errorInfo = new ErrorInfo(error);

            var envelope = Envelope.Error(errorInfo);

            return base.NotFound(envelope);
        }
    }
}

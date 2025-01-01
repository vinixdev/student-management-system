using System;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers;

public class StudentsController : ControllerBase
{

    private readonly IServiceManager _service;

    public StudentsController(IServiceManager service) => _service = service;

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyMasterApi.Services;

namespace SpyMasterApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentsService _agentService;

        public AgentsController(IAgentsService agentService)
        {
            _agentService = agentService;
        }
    }
}

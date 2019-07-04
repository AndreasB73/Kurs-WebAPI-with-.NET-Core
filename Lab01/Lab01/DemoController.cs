using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    public class DemoController
    {
        private readonly IDemoService _demoService;
        private readonly ILogger _logger;

        public DemoController(IDemoService demoService, ILogger<DemoController> logger)
        {
            _demoService = demoService;
            _logger = logger;
        }

        public string Index(string firstname, string name)
        {
            string result = _demoService.Greet(firstname, name);
            _logger.LogDebug($"firstname: {firstname} - name: {name}");
            return result;
        }
    }
}

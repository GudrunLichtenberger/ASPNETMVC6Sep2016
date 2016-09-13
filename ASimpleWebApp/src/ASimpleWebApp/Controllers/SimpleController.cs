using ASimpleWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASimpleWebApp.Controllers
{
    public class SimpleController
    {
        private readonly ISampleService _sampleService;
        public SimpleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        public string Action1(string req)
        {
            return _sampleService.ToUpper(req);
        }
    }
}

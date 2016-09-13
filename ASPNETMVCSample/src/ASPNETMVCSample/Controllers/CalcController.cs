﻿using ASPNETMVCSample.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETMVCSample.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalcService _calcService;
        public CalcController(ICalcService calcService)
        {
            _calcService = calcService;
        }
        public IActionResult Add(int x, int y) =>  Ok(_calcService.Add(x, y));

        public int Add2(int x, int y) => _calcService.Add(x, y);
        public IActionResult Subtract(int x, int y) => Ok(_calcService.Subtract(x, y));
    }
}

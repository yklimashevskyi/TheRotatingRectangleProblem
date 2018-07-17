﻿// ----------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Derivco">
//   Copyright (C) Derivco 2017 All rights reserved
// </copyright>
// ----------------------------------------------------------------------------

namespace Derivco.FullStack.Assignment.Web.Controllers
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using AutoMapper;
  using Microsoft.AspNetCore.Mvc;
  using Models;
  using ViewModels;

  public class HomeController : Controller
  {
    public HomeController(IRectangleGenerator rectangleGenerator, ISolutionCalculator solutionCalculator, IMapper mapper)
    {
      _rectangleGenerator = rectangleGenerator;
      _solutionCalculator = solutionCalculator;
      _mapper = mapper;
    }

    [HttpPost]
    public ActionResult CalculateSolution(ParemetersViewModel parameters)
    {
      IList<Rectangle> inputRectangles = _rectangleGenerator.GenerateRandomRectangles(parameters.RectangleCount);
      Solution solution = _solutionCalculator.Calculate(inputRectangles);
      return View(_mapper.Map<SolutionViewModel>(solution));
    }

    public IActionResult Index()
    {
      return View(new ParemetersViewModel { RectangleCount = 7 });
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private readonly IRectangleGenerator _rectangleGenerator;
    private readonly ISolutionCalculator _solutionCalculator;
    private readonly IMapper _mapper;
  }
}
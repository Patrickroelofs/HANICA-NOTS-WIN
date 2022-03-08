using CalculatorWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalculatorWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculatorController : ControllerBase
{
    private readonly CalculatorContext _context;

    public CalculatorController(CalculatorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CalculatorModel>>> getAllCalculations()
    {
        return await _context.Calculations.ToListAsync();
    }

    [HttpGet("{id}")]
    public ActionResult<CalculatorModel> getCalculationById(int id)
    {
        return _context.Calculations.FirstOrDefault(CalculatorModel => CalculatorModel.Id == id);
    }

    [HttpPost("")]
    public CalculatorModel PostCalculation(CalculatorModel calculation)
    {
        _context.Calculations.Add(calculation);
        _context.SaveChanges();
        return calculation;
    }

    [HttpDelete("{id}")]
    public ActionResult<int> deleteCalculationByID(int id)
    {
         _context.Calculations.Remove(
            _context.Calculations.FirstOrDefault(CalculatorModel => CalculatorModel.Id == id));
        _context.SaveChanges();
        return id;
    }
}
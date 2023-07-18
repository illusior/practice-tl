using Microsoft.AspNetCore.Mvc.RazorPages;
using VisualCalc.Models;

namespace VisualCalc.Pages.Calculator
{
    public class CalculatorSubmitPageModel : PageModel
    {
        public CalculatorSubmitModel CalculatorSubmitModel { get; set; } = new();

        public void OnGet()
        {
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tarea_3.Pages
{
    public class FormularioModel : PageModel
    {
        public double Monto { get; set; }
        public double CantCuotas { get; set; }
        public double InteresAnual { get; set; }
        public double Cuota { get; set; }

        public FormularioModel()
        {
            Monto = 0;
        }

        public void OnGet(double monto, double cantCuotas, double interesAnual)
        {
            this.Monto = monto;
            this.CantCuotas = cantCuotas;
            this.InteresAnual = interesAnual / 100;
            double interesMensual = this.InteresAnual / 12;
            this.Cuota = (this.Monto * interesMensual) / (1 - Math.Pow(1 + interesMensual, -this.CantCuotas));
            this.Cuota = Math.Round(this.Cuota, 2);
        }
    }
}

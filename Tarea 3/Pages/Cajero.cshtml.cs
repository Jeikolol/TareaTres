using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tarea_3.Pages
{
    public class CajeroModel : PageModel
    {
        public string NombreBanco { get; set; }
        public double Monto { get; set; }
        public int BilletesMil { get; set; }
        public int BilletesQuinientos { get; set; }
        public int BilletesCien { get; set; }
        public double MontoDisponible { get; set; }
        public double Limite { get; set; }
        public double MontoDispensado { get; set; }
        public string Mensaje { get; set; }

        public CajeroModel()
        {
            this.MontoDispensado = 0;
        }

        public void OnGet(double montoSolicitado, string banco = "")
        {
            this.NombreBanco = banco;
            this.Monto = montoSolicitado;
            this.BilletesMil = 9;
            this.BilletesQuinientos = 19;
            this.BilletesCien = 99;
            this.MontoDisponible = (this.BilletesMil * 1000) + (this.BilletesQuinientos * 500) + (this.BilletesCien * 100);
            
            double montoDispensado = this.Monto;
            int billetesMil = 0;
            int billetesQuinientos = 0;
            float billetesCien = 0;

            //Comprobando cual banco ha sido seleccionado
            if (this.NombreBanco == "Banco ABC")
            {
                this.Limite = 10000;

                //Comprobando si el monto solicitado no excede el limite de retiro
                if (this.Monto > this.Limite)
                {
                    this.Mensaje = "El monto solicitado excede el límite de retiro por transacción.";
                }

                if (this.Monto > 1000 && this.BilletesCompletos())
                {
                   
                    this.MontoDispensado = this.Monto;

                    if (this.Monto >= 1000)
                    {
                        this.Monto = this.Monto / 1000;
                        billetesMil = (int)Math.Truncate(this.Monto);
                    }
                    else
                    {
                        billetesMil = 0;
                    }

                    if ((this.Monto - billetesMil) >= 0.5)
                    {
                        billetesQuinientos = 1;
                    }
                    else
                    {
                        billetesQuinientos = 0;
                    }

                    if (billetesQuinientos == 1)
                    {
                        billetesCien = (float)(Math.Round(this.Monto - billetesMil, 1) - 0.5) * 10;
                    }
                    else
                    {
                        billetesCien = (float)Math.Round(this.Monto - billetesMil, 1) * 10;
                    }

                    this.MontoDisponible = this.MontoDisponible - MontoDispensado;
                    this.BilletesMil = this.BilletesMil - billetesMil;
                    this.BilletesQuinientos = this.BilletesQuinientos - billetesQuinientos;
                    this.BilletesCien = this.BilletesCien - (int)billetesCien;

                    this.Mensaje = $"El monto dispensado es: { MontoDispensado }, " +
                        $"la cantidad de billetes de 1000 dispensados es: {billetesMil}, " +
                        $"la cantidad de billetes de 500 es: {billetesQuinientos}, " +
                        $"la cantidad de billetes de 100 dispensados es: {billetesCien}.";

                }
                else if ((this.Monto < 1000) && (this.BilletesCompletos()))
                {

                    if (this.Monto >= 500)
                    {
                        billetesQuinientos = 1;
                    }
                    else
                    {
                        billetesQuinientos = 0;
                    }

                    if (this.Monto < 500)
                    {
                        billetesCien = (float)Math.Round(this.Monto / 100, 1);
                    }
                    else
                    {
                        billetesCien = (float)Math.Round(this.Monto - 500, 1) / 100;
                    }

                    this.MontoDisponible = this.MontoDisponible - montoDispensado;
                    this.BilletesMil = this.BilletesMil - billetesMil;
                    this.BilletesQuinientos = this.BilletesQuinientos - billetesQuinientos;
                    this.BilletesCien = this.BilletesCien - (int)billetesCien;

                    this.Mensaje = $"El monto dispensado es: { montoDispensado }, " +
                        $"la cantidad de billetes de 1000 dispensados es: { billetesMil }, " +
                        $"la cantidad de billetes de 500 es: { billetesQuinientos }, " +
                        $"la cantidad de billetes de 100 dispensados es: { billetesCien }";
                }
            }
            else
            {
                this.Limite = 2000;

                //Comprobando si el monto solicitado no excede el limite de retiro
                if (this.Monto > this.Limite)
                {
                    this.Mensaje = "El monto el límite de retiro por transacción.";
                }
                else
                {
                    if ((this.Monto > 1000) && (this.BilletesCompletos()))
                    {
                        this.MontoDispensado = this.Monto;

                        if (this.Monto >= 1000)
                        {
                            this.Monto = this.Monto / 1000;
                            billetesMil = (int)Math.Truncate(this.Monto);
                        }
                        else
                        {
                            billetesMil = 0;
                        }

                        if ((this.Monto - billetesMil) >= 0.5)
                        {
                            billetesQuinientos = 1;
                        }
                        else
                        {
                            billetesQuinientos = 0;
                        }

                        if (billetesQuinientos == 1)
                        {
                            billetesCien = (float)(Math.Round(this.Monto - billetesMil, 1) - 0.5) * 10;
                        }
                        else
                        {
                            billetesCien = (float)Math.Round(this.Monto - billetesMil, 1) * 10;
                        }

                        this.MontoDisponible = this.MontoDisponible - MontoDispensado;
                        this.BilletesMil = this.BilletesMil - billetesMil;
                        this.BilletesQuinientos = this.BilletesQuinientos - billetesQuinientos;
                        this.BilletesCien = this.BilletesCien - (int)billetesCien;

                        this.Mensaje = $"El monto dispensado es: { MontoDispensado }, "+
                            $"la cantidad de billetes de 1000 dispensados es: { billetesMil }, " +
                            $"la cantidad de billetes de 500 es: { billetesQuinientos }, " +
                            $"la cantidad de billetes de 100 dispensados es: { billetesCien }.";

                    }
                    else if (this.Monto < 1000 && this.BilletesCompletos())
                    {
                        if (this.Monto >= 500)
                        {
                            billetesQuinientos = 1;
                        }
                        else
                        {
                            billetesQuinientos = 0;
                        }

                        if (this.Monto < 500)
                        {
                            billetesCien = (float)Math.Round(this.Monto / 100, 1);
                        }
                        else
                        {
                            billetesCien = (float)Math.Round(this.Monto - 500, 1) / 100;
                        }

                        this.MontoDisponible = this.MontoDisponible - montoDispensado;
                        this.BilletesMil = this.BilletesMil - billetesMil;
                        this.BilletesQuinientos = this.BilletesQuinientos - billetesQuinientos;
                        this.BilletesCien = this.BilletesCien - (int)billetesCien;

                        this.Mensaje = $"El monto dispensado es: { montoDispensado }, " +
                            $"la cantidad de billetes de 1000 dispensados es: { billetesMil }, "+
                            $"la cantidad de billetes de 500 es: { billetesQuinientos }, " +
                            $"la cantidad de billetes de 100 dispensados es: { billetesCien }.";
                    }
                }
            }
        }

        public bool BilletesCompletos()
        {
            int sumaDeBilletes = this.BilletesMil + this.BilletesQuinientos + this.BilletesCien;

            if (sumaDeBilletes == 127)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

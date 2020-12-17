using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_map.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGetFindRaion(string name)
        {
            string text= $"<p>Конфигурации для региона \"{name}\"<p>";
            Region rg = new Region(name);
            text += $"<p>({rg.GetName()} - {rg.average_temperature} - {rg.humidity} - {rg.intensity} - {rg.windiness})";
            return new JsonResult(text);
        }


        public IActionResult OnGetFindUser(string name)
        {
            string out_str="";
            Region rg = new Region(name);
            User user = new User(100000, 2500, rg);
            ElectricStation e_s = new ElectricStation(user.power, user.budget);
            Efficiency eff = new Efficiency(e_s, user.region);
            ElectricStation[] arr = eff.CalculateMostEfficientStation();
            for (int i = 0; i < arr.Length; i++)
            {              
                out_str += $"<table> <tr><th>   Конфигурация: {i + 1}</th></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Аккумулятор - {arr[i].accumulator.name}</p><p><img src = 'img/{arr[i].accumulator.name}.jpg' class ='img-fluid'></p></td></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Электрогенератор - {arr[i].esource.name}</p><p><img src = 'img/{arr[i].esource.name}.jpg' class ='img-fluid'></p></td></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Инвертор - {arr[i].inverter.name}</p><p><img src = 'img/{arr[i].inverter.name}.jpg' class ='img-fluid'></p></td></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Полная стоимость - {arr[i].full_cost}</p></td></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Мощность СЭС - {arr[i].full_power}</p></td></tr>"
                    + $"<tr class='stroke'><td><p style=' text-indent:3px;'>Эффективность - {arr[i].efficiency}</p></td></tr></table>";
            }
            return new JsonResult(out_str);
        }

    }
}

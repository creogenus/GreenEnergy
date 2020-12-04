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

        public string[] rrr = { "<h1>В Шацком районе преобладают пасмурные и облачные дни. Среднее количество солнечных часов - 5.75</h2> ", "В Ратно среднесуточное количество солнечных часов - 5.8" };

        public IActionResult OnGetFindUser(string name)
        {

                string out_str = $"<p>Конфигурации для региона \"{name}\"<p>";
                Region rg = new Region(name);
                User user = new User(100000,2500,rg);
                out_str += $"<p>({rg.GetName()} - {rg.average_temperature} - {rg.humidity} - {rg.intensity} - {rg.windiness})";
                ElectricStation e_s = new ElectricStation(user.power, user.budget);
                Efficiency eff = new Efficiency(e_s, user.region);
                ElectricStation [] arr = eff.CalculateMostEfficientStation();
                for (int i = 0; i < arr.Length; i++)
                {
                    out_str += $"<p> Config: {i + 1}<p>" +
                        $"<div class = 'container-fluid'><p>Accumulator - {arr[i].accumulator.name}<p><img src = '{arr[i].accumulator.name}.jpg' class ='img-fluid'></p></p>" +
                        $" <p>Electric Source - {arr[i].esource.name}<p><img src = '{arr[i].esource.name}.jpg' class ='img-fluid'></p></p>" +
                        $"<p>Inverter - {arr[i].inverter.name}<p><img src = '{arr[i].inverter.name}.jpg' class ='img-fluid'></p></p> " +
                        $"<p>Full Cost - {arr[i].full_cost}</p> " +
                        $"<p>Full Power - {arr[i].full_power}</p>" +
                        $"<p>Efficiency - {arr[i].efficiency}</p></div>";
                }
                return new JsonResult(out_str);
        }

    }
}

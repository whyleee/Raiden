using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Models.Scheme.DataAnnotations;

namespace GameStore.Models
{
    public enum Platform
    {
        PC,
        PS3,
        PS4,
        PSVita,
        Xbox360,
        XboxOne,
        Switch
    }

    public class PlatformOptions : ISelectOptionProvider
    {
        public IEnumerable<SelectOption> GetOptions()
        {
            return new[]
            {
                new SelectOption("PC", Platform.PC.ToString()),
                new SelectOption("PlayStation 3", Platform.PS3.ToString()),
                new SelectOption("PlayStation 4", Platform.PS4.ToString()),
                new SelectOption("PlayStation Vita", Platform.PSVita.ToString()),
                new SelectOption("Xbox 360", Platform.Xbox360.ToString()),
                new SelectOption("Xbox One", Platform.XboxOne.ToString()),
                new SelectOption("Nintendo Switch", Platform.Switch.ToString())
            };
        }
    }
}

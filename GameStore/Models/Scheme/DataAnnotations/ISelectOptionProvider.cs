using System.Collections.Generic;

namespace GameStore.Models.Scheme.DataAnnotations
{
    public interface ISelectOptionProvider
    {
        IEnumerable<SelectOption> GetOptions();
    }
}

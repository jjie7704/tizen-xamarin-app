using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinExample.Models;

namespace xamarinExample.Services
{
    public interface INavigationService
    {
        void Initialize();

        Task NavigateToMainListPageAsync();

        Task NavigateToBunchPageAsync(Bunch bunch);
    }
}

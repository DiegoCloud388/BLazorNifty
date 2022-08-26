using BlazorNifty.Data.Commands;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorNifty.Pages.Components.Forms
{
    public partial class General
    {
        private CommandCreateUser commandCreate = new CommandCreateUser();

        private async Task OnValidSubmit(EditContext context)
        {
            //return null;
        }
    }
}

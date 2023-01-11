using BlazorNifty.Data.Commands;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BlazorNifty.Pages.Components.Forms
{
    public partial class Validation
    {
        #region Fields for component parameters demo
        private bool inlineOrientation;
        private bool showSuccessTickIfValid = true;
        private bool showSuccessBorderIfValid = true;
        private int spacingAfterLabel;
        private bool reverseStack;
        private bool lightLabel = true;
        private int labelLg = 1;
        private int labelXl = 1;
        private int labelXxl = 1;
        private AlignItems labelAlign = AlignItems.Baseline;
        //private Justify stackJustify = Justify.FlexStart;
        #endregion

        private List<BreadcrumbItem> items = new ()
        {
            new BreadcrumbItem("Home", href: "#"),
            new BreadcrumbItem("Forms", href: "#"),
            new BreadcrumbItem("Validation", href: null, disabled: true)
        };

        private CommandRegisterCustomer commandRegisterCustomer = new();
        private EditContext editContext;

        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(commandRegisterCustomer);
        }

        private async Task OnValidSubmit(EditContext context)
        {
            commandRegisterCustomer = new CommandRegisterCustomer();
            editContext = new EditContext(commandRegisterCustomer);
        }

        private void GenderChanged(int? newValue, string fieldName)
        {
            commandRegisterCustomer.GenderId = newValue;

            editContext.NotifyFieldChanged(editContext.Field(fieldName));
        }

        private void CountryChanged(int? newValue, string fieldName)
        {
            commandRegisterCustomer.CountryId = newValue;

            editContext.NotifyFieldChanged(editContext.Field(fieldName));
        }

        private bool IsFieldValid(string fieldName, bool onlyIfModified = true)
        {
            var identifier = editContext.Field(fieldName);

            if (onlyIfModified)
            {
                var isModified = editContext.IsModified(identifier);

                if (!isModified)
                {
                    return false;
                }

            }

            var isValid = !editContext.GetValidationMessages(identifier).Any();

            return isValid;
        }
    }
}

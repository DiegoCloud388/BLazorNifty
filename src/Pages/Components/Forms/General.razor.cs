using BlazorNifty.Data.Commands;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BlazorNifty.Pages.Components.Forms
{
    public partial class General
    {
        private CommandCreateUser commandCreate = new ();
        private EditContext editContext;


        protected override async Task OnInitializedAsync()
        {
            editContext = new EditContext(commandCreate);
        }

        private async Task OnValidSubmit(EditContext context)
        {
            commandCreate = new CommandCreateUser();
            editContext = new EditContext(commandCreate);
        }

        private Adornment GetAdornmentIfFieldIsValid(string fieldName, bool onlyIfModified = true)
        {
            var identifier = editContext.Field(fieldName);

            var isModified = editContext.IsModified(identifier);

            if (onlyIfModified && (!isModified))
            {
                return Adornment.None;
            }

            var isValid = !editContext.GetValidationMessages(identifier).Any();

            return isValid ? Adornment.End : Adornment.None;
        }

        private bool IsFieldValid(string fieldName, bool onlyIfModified = false)
        {
            var identifier = editContext.Field(fieldName);

            var isValid = !editContext.GetValidationMessages(identifier).Any();

            if (onlyIfModified)
            {
                var isModified = editContext.IsModified(identifier);

                if (isModified && isValid)
                    return true;
            }

            return isValid;
        }

        private string SetBackgroundIfFieldIsInvalid(string fieldName, bool onlyIfModified = false, string color = "lightyellow")
        {
            var identifier = editContext.Field(fieldName);

            var isValid = !editContext.GetValidationMessages(identifier).Any();

            if (onlyIfModified)
            {
                var isModified = editContext.IsModified(identifier);

                if (isModified && isValid)
                    return "";
            }

            var result = isValid ? "" : $"background-color:{color};";

            return result;
        }

        private string RequiredFieldStyle(object value, string color = "lightyellow")
        {
            var stringValue = value?.ToString();

            return string.IsNullOrEmpty(stringValue) ? $"background-color:{color}; border-style: none;" : "";
        }

        private string SuccessHelperText(object value, string color = "green")
        {
            var stringValue = value?.ToString();

            return string.IsNullOrEmpty(stringValue) ? "" : "<strong>This text is important!</strong>";
        }

        //private bool IsFieldValid(string fieldName)
        //{
        //    var identifier = editContext.Field(fieldName);

        //    var isValid = !editContext.GetValidationMessages(identifier).Any();

        //    var isModified = editContext.IsModified(identifier);

        //    //if(isValid && isModified)
        //    //    return Adornment.End;

        //    return isValid;


        //}
    }
}

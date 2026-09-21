using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using UTB.Eshop.Domain.Validations;

namespace UTB.Eshop26.Web.Validations.Adapters
{
    public class FirstLetterUppercaseAttributeAdapter : AttributeAdapterBase<FirstLetterUppercaseAttribute>
    {
        public FirstLetterUppercaseAttributeAdapter(FirstLetterUppercaseAttribute attribute, IStringLocalizer? stringLocalizer)
            : base(attribute, stringLocalizer)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-firstletteruppercase", $"The {context.ModelMetadata.Name} field must start with an uppercase letter.");
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return base.GetErrorMessage(validationContext.ModelMetadata, validationContext.ModelMetadata.GetDisplayName());
        }
    }
}

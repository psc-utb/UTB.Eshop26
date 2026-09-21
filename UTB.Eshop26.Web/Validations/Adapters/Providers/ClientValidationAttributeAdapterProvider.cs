using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using UTB.Eshop.Domain.Validations;

namespace UTB.Eshop26.Web.Validations.Adapters.Providers
{
    public class ClientValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly ValidationAttributeAdapterProvider _baseProvider;

        public ClientValidationAttributeAdapterProvider(ValidationAttributeAdapterProvider baseProvider)
        {
            _baseProvider = baseProvider;
        }

        public IAttributeAdapter? GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
        {
            if (attribute is FirstLetterUppercaseAttribute firstLetterUppercaseAttribute)
            {
                return new FirstLetterUppercaseAttributeAdapter(firstLetterUppercaseAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}

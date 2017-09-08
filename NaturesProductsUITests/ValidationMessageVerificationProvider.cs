using Atata;

namespace NaturesProductsUITests
{
    public static class IValidationMessageVerificationProviderExtensions
    {
        public static TOwner BeRequired<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
            where TOwner : PageObject<TOwner>
        {
            return should.Equal("This field is required.");
        }

        public static TOwner BeRequiredWithoutComa<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
    where TOwner : PageObject<TOwner>
        {
            return should.Equal("This field is required");
        }

        public static TOwner HaveIncorrectFormat<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
            where TOwner : PageObject<TOwner>
        {
            return should.Equal("has incorrect format");
        }

        public static TOwner HaveMinLength<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should, int length)
    where TOwner : PageObject<TOwner>
        {
            return should.Equal($"Please enter at least {length} characters.");
        }

        public static TOwner HaveMaxLength<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should, int length)
where TOwner : PageObject<TOwner>
        {
            return should.Equal($"Please enter no more than {length} characters.");
        }

        public static TOwner MustFill<TOwner>(this IFieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> should)
    where TOwner : PageObject<TOwner>
        {
            return should.Equal("You must fill this field");
        }
    }
}

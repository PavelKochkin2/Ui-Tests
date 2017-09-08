using Atata;

namespace NaturesProductsUITests
{

    [ControlDefinition("span", ContainingClass = "validationMessage")]
    


    public class ValidationMessage<TOwner> : Text<TOwner>
         where TOwner : PageObject<TOwner>
    {
        public new FieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner> Should =>
            new FieldVerificationProvider<string, ValidationMessage<TOwner>, TOwner>(this);
    }
}

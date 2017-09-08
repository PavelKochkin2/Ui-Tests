using Atata;
using NaturesProductsUITests.Pages;

namespace NaturesProductsUITests
{
    public class ConfirmAttribute : TriggerAttribute
    {
        public ConfirmAttribute(string windowTitle = "Confirm", TriggerEvents on = TriggerEvents.AfterClick, TriggerPriority priority = TriggerPriority.Medium)
            : base(on, priority)
        {
            WindowTitle = windowTitle;
        }

        public string WindowTitle { get; private set; }

        protected override void Execute<TOwner>(TriggerContext<TOwner> context)
        {
            Go.To(new ConfirmationWindow(WindowTitle), temporarily: true).
                OK.Click();
        }
    }
}
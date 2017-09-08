// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmationWindow.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages
{
    using Atata;
    using Atata.Bootstrap;

    using _ = NaturesProductsUITests.Pages.ConfirmationWindow;

    /// <summary>
    /// The confirmation window.
    /// </summary>
    [WindowTitleElementDefinition(ContainingClass = "bootstrap-dialog-title")]
    public class ConfirmationWindow : BSModal<ConfirmationWindow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationWindow"/> class.
        /// </summary>
        /// <param name="windowTitle">
        /// The window title.
        /// </param>
        public ConfirmationWindow(string windowTitle = "Confirm") 
            : base(windowTitle)
        {
        }

        /// <summary>
        /// Gets the ok.
        /// </summary>
        public Button<_> OK { get; private set; }

        /// <summary>
        /// Gets the cancel.
        /// </summary>
        public Button<_> Cancel { get; private set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginPage.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages
{
    using Atata;
    using _ = LoginPage;

    /// <summary>
    /// The Page Object class represents Login page.
    /// </summary>
    [Url("default.aspx?subj=doors/login")]
    public class LoginPage : AppPage<LoginPage>
    {
        /// <summary>
        /// Gets the "User name" field.
        /// </summary>
        [FindByPlaceholder("User name")]
        public TextInput<_> UserName { get; private set; }

        /// <summary>
        /// Gets the "Password" field.
        /// </summary>
        [FindByPlaceholder]
        public PasswordInput<_> Password { get; private set; }

        /// <summary>
        /// Gets the "Log in" button.
        /// </summary>
        public ButtonDelegate<WelcomePage, _> LogIn { get; private set; }
    }
}
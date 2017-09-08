// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WelcomePage.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages
{
    using Atata;

    /// <summary>
    /// The Page Object class represents "Welcome" page.
    /// </summary>
    [Url("default.aspx?subj=admin/Welcome/Welcome")]
    [VerifyTitle]
    public class WelcomePage : AppPage<WelcomePage>
    {
    }
}
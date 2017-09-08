using Atata;
using Atata.Bootstrap;
using NaturesProductsUITests.Pages;

namespace NaturesProductsUITests
{
    public abstract class AppPage<TOwner> : Page<TOwner>
        where TOwner : AppPage<TOwner>
    {
        [FindByContent(TermMatch.Contains, "Administrator")]
        public AccountDropdown Administrator { get; private set; }

        [FindByContent(TermMatch.Contains, "Kolya")]
        public AccountDropdown Kolya { get; private set; }

        public class AccountDropdown : BSDropdown<TOwner>
        {
            [FindByContent(TermMatch.Contains, "Logout")]
            public LinkDelegate<LoginPage, TOwner> Logout { get; private set; }

        }
    }
}


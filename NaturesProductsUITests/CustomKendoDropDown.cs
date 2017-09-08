using Atata;
using Atata.KendoUI;
using OpenQA.Selenium;

namespace NaturesProductsUITests
{
    public class TreeViewKendoDropDownList<T, TOwner> : KendoDropDownList<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override IWebElement GetDropDownOption(string value, SearchOptions searchOptions = null)
        {
            return Scope.Get(
                By.XPath($"following-sibling::div[@role='tree']/ul//li[normalize-space(.)='{value}']").
                DropDownOption(value).
                With(searchOptions));
        }
    }
}
using System;
using System.Linq;
using Atata;
using NaturesProductsUITests.Pages.Company;
using NUnit.Framework;

namespace NaturesProductsUITests.Tests
{
    public class ZCompanyTest : AutoTest
    {
        [Test]
        public void Company_Create()
        {
            string name;
            var page = Go.To<CompanyListAndEditor>();
            //counting the number of items in company list
            var count = page.UnorderedList.Click().UnorderedList.Items.Count();
            //adding a new company
            page.AddCompany.Click()

                .Name.SetRandom(out name).Add().OK()
                //checking that new item in company list has appeared
                .Content.Should.Contain(name).UnorderedList.Items.Count.Should.Equal(count + 1);

        }

        [Test]
        public void Company_Edit()
        {
            string name;

            var page = Go.To<CompanyListAndEditor>().UnorderedList.Click();
            var count = page.UnorderedList.Click().UnorderedList.Items.Count();
            var rnd = new Random().Next(1, count);

            //picking a random company
            page.UnorderedList.Items[rnd].Click().

                Name.SetRandom(out name).
                
                Save().
                
                Name.Should.Equal(name);
        }

    }
}
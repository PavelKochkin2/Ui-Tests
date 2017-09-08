// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignTest.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Tests
{
    using System;
    using Atata;
    using NUnit.Framework;
    using Pages.Campaign;

    /// <summary>
    /// Tests for Campaigns.
    /// </summary>
    public class CampaignTest : AutoTest
    {
        // TODO: add CallStart and CallEnd drop-downs

        /// <summary>
        /// In this test we check that user can .
        /// </summary>
        [Test]
       
        public void Campaign_Edit()
        {
            Data.CampaignTypeData camptype2 = Data.CampaignTypeData.Reliant;
            Data.CompanyData company = Data.CompanyData.ExistingCompany;
            Data.Five9DomainTypeData domainType = Data.Five9DomainTypeData.Secondary;
            Data.CampaignData camp1 = Data.CampaignData.share;
            Data.InfomercialTypeData informType2 = Data.InfomercialTypeData.ShortForm;
            DateTime startDate = new DateTime(1980, 4, 4);
            DateTime endDate = new DateTime(1993, 7, 13);
            DateTime projectedEndDate = new DateTime(1995, 12, 14);
            string name = "edit";
            string five9List;
            int? seats;
            string addprop = "Additional Properties";

            var row = Go.To<CampaignList>()

                // finding "edit" campaign and clicking edit
                .Campaigns.Rows[x => x.Name == name].Edit()

                // check that "Additional properties" link exists
                .Content.Should.Contain(addprop)
                .Name.SetRandom(out name)
                .SeatsAllocated
                .SetRandom(out seats)
                .CampaignToShareWith.Set(camp1)
                .CampaignType.Set(camptype2)
                .Client.Set(company)
                .StartDate.Set(startDate)
                .EndDate.Set(endDate)
                .ProjectedEndDate.Set(projectedEndDate)
                .External.Set(company)
                .InfomercialType.Set(informType2)
                .Five9List.SetRandom(out five9List)
                .Five9DomainType.Set(domainType)

                // unchecking "Inactive" and "Alternate language" checkboxes 
                .Inactive.Uncheck().AlternateLanguage.Uncheck()

                // saving the data and going to Campaign List
                .Save()

                // finding campaign with ("Name" == name)  and clicking edit
                .Campaigns.Rows[x => x.Name == name].Edit()

                // checking that all changes we've made have been saved correctly 
                .Name.Should.Equal(name)
                .SeatsAllocated.Should.Equal(seats)
                .ShareWithCampaign.Should.BeChecked()
                .CampaignToShareWith.Should.Equal(camp1)
                .CampaignType.Should.Equal(camptype2)
                .StartDate.Should.Equal(startDate)
                .EndDate.Should.Equal(endDate)
                .ProjectedEndDate.Should.Equal(projectedEndDate)
                .Inactive.Should.BeUnchecked()
                .AlternateLanguage.Should.BeUnchecked()
                .Client.Should.Equal(company)
                .External.Should.Equal(company)
                .InfomercialType.Should.Equal(informType2)
                .Five9List.Should.Equal(five9List)
                .Five9DomainType.Should.Equal(domainType);
        }

        /// <summary>
        /// We check that user can delete a campaign.
        /// </summary>
        [Test]
        public void Campaign_Delete()
        {
            string name = "delete";

            var row = Go.To<CampaignList>()

               // finding Campaign with "Name" == name and clicking delete button
               .Campaigns.Rows[x => x.Name == name].Delete()

               // confirming deleting the campaign
               .OK()

               // checking that Campaign with "Name" == name doesn't exist
               .Campaigns.Rows[x => x.Name == name].Should.Not.Exist();
        }

        /// <summary>
        /// In the test we check that we can create a new campaign.
        /// </summary>
        [Test]

        public void Campaign_Create()
        {
            Data.CompanyData company = Data.CompanyData.ExistingCompany;
            Data.CampaignData camp1 = Data.CampaignData.edit;
            Data.Five9DomainTypeData domainType = Data.Five9DomainTypeData.Secondary;
            Data.CampaignTypeData camptype2 = Data.CampaignTypeData.Reliant;
            Data.CompanyData client2 = Data.CompanyData.DeleteCompany;
            Data.InfomercialTypeData informType1 = Data.InfomercialTypeData.LongForm;
            DateTime startDate = new DateTime(1980, 4, 4);
            DateTime endDate = new DateTime(1993, 7, 13);
            DateTime projectedEndDate = new DateTime(1995, 12, 14);
            string name, five9List;
            int? seats;
            string addprop = "Additional properties are available for saved objects";

            var row = Go.To<CampaignEditor>()

                // check that "Additional properties" link exists
                .Content.Should.Contain(addprop)
                .Name.SetRandom(out name)
                .SeatsAllocated.SetRandom(out seats)
                .ShareWithCampaign.Check()
                .CampaignToShareWith.Set(camp1)
                .CampaignType.Set(camptype2)
                .Client.Set(client2)
                .StartDate.Set(startDate)
                .EndDate.Set(endDate)
                .ProjectedEndDate.Set(projectedEndDate)
                .External.Set(company)
                .InfomercialType.Set(informType1)
                .Five9List.SetRandom(out five9List)

                // checking "Inactive" and "Alternate language" checkboxes 
                .Inactive.Check().AlternateLanguage.Check()
                .Five9DomainType.Set(domainType)

                // saving the data and going to Campaign List
                .Save()

                // finding Campaign with "Name" == name and clicking edit
                .Campaigns.Rows[x => x.Name == name].Edit()

                // checking that all changes we've made have been saved correctly 
                .Name.Should.Equal(name)
                .SeatsAllocated.Should.Equal(seats)
                .ShareWithCampaign.Should.BeChecked()
                .CampaignToShareWith.Should.Equal(camp1)
                .CampaignType.Should.Equal(camptype2)
                .StartDate.Should.Equal(startDate)
                .EndDate.Should.Equal(endDate)
                .ProjectedEndDate.Should.Equal(projectedEndDate)

                // checking that "Inactive" checkbox is checked
                .Inactive.Should.BeChecked()

                // chechking that "Alternate language" is checked
                .AlternateLanguage.Should.BeChecked()
                .Client.Should.Equal(client2)
                .External.Should.Equal(company)
                .InfomercialType.Should.Equal(informType1)
                .Five9List.Should.Equal(five9List)
                .Five9DomainType.Should.Equal(domainType);
        }

        /// <summary>
        /// Checking that validators appear near required fields.
        /// </summary>
        [Test]
        [Ignore("Wait until I fix the validation class. It was changed to following sibling but was accenstor")]
        public void Campaign_Validation_Required()
        {
            var row = Go.To<CampaignEditor>()
                .Save.Click()
                .ValidationMessages[x => x.Name].Should.BeRequired()
                .ValidationMessages[x => x.CampaignType].Should.BeRequired()
                .ValidationMessages[x => x.Client].Should.BeRequired();
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignTypeTest.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Tests
{
    using Atata;
    using NUnit.Framework;
    using Pages.CampaignType;

    /// <summary>
    /// Tests for Campaign Type entity.
    /// </summary>
    public class CampaignTypeTest : AutoTest
    {
        /// <summary>
        /// We check that user can create a campaign type.
        /// </summary>
        [Test]

        public void CampaignType_Create()
        {
            string name, desc;
            Data.ClientGroupData cg = Data.ClientGroupData.Admin;

            var row = Go.To<CampaignTypeEditor>()

                .Name.SetRandom(out name)
                .Description.SetRandom(out desc)
                .ClientGroup.Set(cg)

                // saving the changes
                .Save()

                // finding the Campaign Type with "Name" == name
                .CampaignTypes.Rows[x => x.Name == name && x.Description == desc && x.ClientGroup == cg];

            // checking that all changes we've made have been saved correctly             
            row.Name.Should.Equal(name);
            row.Description.Should.Equal(desc);
            row.ClientGroup.Should.Equal(cg);
        }

        /// <summary>
        /// We check that user can edit a Campaign Type.
        /// </summary>
        [Test]
        public void CampaignType_Edit()
        {
            string name = "edit", desc;
            Data.ClientGroupData cg = Data.ClientGroupData.Admin;
            Data.ClientGroupData cg2 = Data.ClientGroupData.Guest;
            var row = Go.To<CampaignTypeList>()

            // finding Campaign Type with "Name" == name and "Client Group" == cg and clicking edit
            .CampaignTypes.Rows[x => x.Name == name && x.ClientGroup == cg].Edit()

                .Name.SetRandom(out name)
                .Description.SetRandom(out desc)
                .ClientGroup.Set(cg2)
                .Save()

                // finding Campaign Type with "Name" == name and "Client Group" == cg2 and clicking edit
                .CampaignTypes.Rows[x => x.Name == name && x.Description == desc && x.ClientGroup == cg2].Edit()

                // checking that all changes we've made have been saved correctly                 
                .Name.Should.Equal(name)
                .Description.Should.Equal(desc)
                .ClientGroup.Should.Equal(cg2);
        }

        /// <summary>
        /// The campaign type delete test.
        /// </summary>
        [Test]
        public void CampaignType_Delete()
        {
            string name = "delete";
            Data.ClientGroupData cg = Data.ClientGroupData.Admin;

            var row = Go.To<CampaignTypeList>()

            // finding Campaign Type with "Name" == name and "Client Group" == cg and clicking delete button
            .CampaignTypes.Rows[x => x.Name == name && x.ClientGroup == cg].Delete()

            // confirming deleting the Campaign Type
            .OK()

            // checking that Campaign Type with "Name" == name and "Client Group" == cg doesn't exist
            .CampaignTypes.Rows[x => x.Name == name && x.ClientGroup == cg].Should.Not.Exist();
        }

        /// <summary>
        /// We check that validators for required appears.
        /// </summary>
        [Test]
        [Ignore("Validation class was changed")]
        public void CampaignType_Validation_Required()
        {
            var row = Go.To<CampaignTypeEditor>()               
                .Save.Click()

                // checking that validators appear near required fields
                .ValidationMessage[x => x.Name].Should.BeRequiredWithoutComa()
                .ValidationMessage[x => x.ClientGroup].Should.BeRequired();
        }
    }
}
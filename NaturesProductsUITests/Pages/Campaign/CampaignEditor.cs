// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignEditor.cs" company="AuthorityCRM">
//   Authority Software
// </copyright>
// <summary>
//   The campaign editor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.Campaign
{
    using Atata;
    using _ = CampaignEditor;

    /// <summary>
    /// The Page Object class represents Campaign Editor page.
    /// </summary>
    [Url("default.aspx?subj=admin/campaigns/CampaignEditor")]
    [VerifyContent("Owners")]

    public class CampaignEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Name" field.
        /// </summary>
        [FindById("name")]
        [WaitForJQueryAjax]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Seats Allocated" field.
        /// </summary>
        [FindById("seatsAllocated")]
        public NumberInput<_> SeatsAllocated { get; private set; }

        /// <summary>
        /// Gets the "Campaign Type" drop- down.
        /// </summary>
        [FindById("campaignTypeId")]
        public Select<Data.CampaignTypeData?, _> CampaignType { get; private set; }

        /// <summary>
        /// Gets the "Share with another Campaign" checkbox.
        /// </summary>
        [FindById("campaignToShareSeatFlag")]
        public CheckBox<_> ShareWithCampaign { get; private set; }

        /// <summary>
        /// Gets the "Campaign to share seats with" drop- down.
        /// </summary>
        [FindById("campaignToShareSeatsWithList")]
        public Select<Data.CampaignData, _> CampaignToShareWith { get; private set; }

        /// <summary>
        /// Gets the "Start date" date picker.
        /// </summary>
        [FindById("startDate")]
        public DateInput<_> StartDate { get; private set; }

        /// <summary>
        /// Gets the "End date" date picker.
        /// </summary>
        [FindById("endDate")]
        public DateInput<_> EndDate { get; private set; }

        /// <summary>
        /// Gets the "Projected end date" date picker.
        /// </summary>
        [FindById("projectedEndDate")]
        public DateInput<_> ProjectedEndDate { get; private set; }

        /// <summary>
        /// Gets the "Inactive" checkbox.
        /// </summary>
        [FindById("inactive")]
        public CheckBox<_> Inactive { get; private set; }

        /// <summary>
        /// Gets the "Alternate language" checkbox.
        /// </summary>
        [FindById("chBoxAltLanguage")]
        public CheckBox<_> AlternateLanguage { get; private set; }

        /// <summary>
        /// Gets the external.
        /// </summary>
        [FindById("agency")]
        public Select<Data.CompanyData, _> External { get; private set; }

        /// <summary>
        /// Gets the "External" drop- down.
        /// </summary>
        [FindById("infomercialType")]
        public Select<Data.InfomercialTypeData, _> InfomercialType { get; private set; }

        /// <summary>
        /// Gets the "Five9 list" field.
        /// </summary>
        [FindById("five9List")]
        public TextInput<_> Five9List { get; private set; }

        /// <summary>
        /// Gets the "Five9 Domain Type" drop- down.
        /// </summary>
        [FindById("five9DomainType")]
        public Select<Data.Five9DomainTypeData, _> Five9DomainType { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        [WaitForJQueryAjax]
        public ButtonDelegate<CampaignList, _> Save { get; private set; }

        /// <summary>
        /// Gets the "Client" drop- down.
        /// </summary>
        [FindById("client")]
        public TreeViewKendoDropDownList<Data.CompanyData, _> Client { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
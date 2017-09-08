// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignList.cs" company="Authority Software">
//   Authority Software
// </copyright>
// <summary>
//   Defines the CampaignList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.Campaign
{
    using Atata;

    using _ = CampaignList;

    /// <summary>
    /// The Page Object class represents Campaign List page.
    /// </summary>
    [Url("default.aspx?subj=admin/campaigns/CampaignList")]
    public class CampaignList : AppPage<_>
    {
        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// Gets the Campaign List table
        /// </summary>
        [FindById("dgList")]
        public Table<CampaignTableRow, _> Campaigns { get; private set; }

        /// <summary>
        /// The class describes a row from Campaign List table .
        /// </summary>
        public class CampaignTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Type" for a row.
            /// </summary>
            public Text<_> Type { get; private set; }

            /// <summary>
            /// Gets the "Name" for a row.
            /// </summary>
            [WaitForJQueryAjax]
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<CampaignEditor, _> Edit { get; private set; }
        }
    }
}
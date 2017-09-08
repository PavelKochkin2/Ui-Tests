// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignTypeList.cs" company="Authority Software">
//   Authority Software
// </copyright>
// <summary>
//   Defines the CampaignList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.CampaignType
{
    using Atata;
    using _ = CampaignTypeList;

    /// <summary>
    /// The Page Object class represents "Campaign Type" list page .
    /// </summary>
    [Url("default.aspx?subj=admin/types/TypeList&categoryName=Campaign%20Types")]
    public class CampaignTypeList : AppPage<_>
    {
        /// <summary>
        /// Gets the Campaign types table.
        /// </summary>
        [FindById("dgList")]
        public Table<CampaignTypeTableRow, _> CampaignTypes { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from Campaign Type List table .
        /// </summary>
        public class CampaignTypeTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Name" value for a row.
            /// </summary>
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Client Group" value for a row.
            /// </summary>
            public Content<Data.ClientGroupData?, _> ClientGroup { get; private set; }

            /// <summary>
            /// Gets the "Description" value for a row.
            /// </summary>
            public Text<_> Description { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<CampaignTypeEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientGroupList.cs" company="Authority Software">
//   Authority Software
// </copyright>
// <summary>
//   Defines the CampaignList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.ClientGroup
{
    using Atata;
    using _ = ClientGroupList;

    /// <summary>
    /// The Page Object class represents "Client Group" list page .
    /// </summary>
    [Url("default.aspx?subj=admin/clients/ClientGroupList")]
    public class ClientGroupList : AppPage<_>
    {
        /// <summary>
        /// Gets the Client Groups table.
        /// </summary>
        [FindById("dgList")]
        public Table<ClientGroupTableRow, _> ClientGroups { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        [WaitForJQueryAjax]
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from Client Group list.
        /// </summary>
        public class ClientGroupTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Code" value for a row.
            /// </summary>
            public Text<_> Code { get; private set; }

            /// <summary>
            /// Gets the "Name" value for a row.
            /// </summary>
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<ClientGroupEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
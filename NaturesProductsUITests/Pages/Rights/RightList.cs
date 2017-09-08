// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RightList.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.Rights
{
    using Atata;
    using _ = RightList;

    /// <summary>
    /// The Page Object class represents "Rights" list page .
    /// </summary>
    [Url("default.aspx?subj=admin/Rights/RightsList&Company=Admin")]
    public class RightList : AppPage<_>
    {
        /// <summary>
        /// Gets the Rights table.
        /// </summary>
        [FindById("dgList")]
        public Table<RightTableRow, _> Rights { get; private set; }

        /// <summary>
        /// Gets the "Show N entries" drop-down.
        /// </summary>
        [FindById(TermMatch.EndsWith, "pageSizeID")]
        public Select<_> ShowEntries { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }
        
        /// <summary>
        /// The class describes a row from "Rights" table.
        /// </summary>
        public class RightTableRow : TableRow<_>
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
            /// Gets the "Description" value for a row.
            /// </summary>
            public Text<_> Description { get; private set; }

            /// <summary>
            /// Gets the edit button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<RightEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the delete button for a row.
            /// </summary>
            [FindById(TermMatch.EndsWith, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
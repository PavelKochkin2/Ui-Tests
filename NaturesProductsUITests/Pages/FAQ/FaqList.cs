// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaqList.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.FAQ
{
    using Atata;

    using _ = FaqList;

    /// <summary>
    /// The Page Object class represents "FAQ" list page.
    /// </summary>
    [Url("default.aspx?subj=admin/knowledge/KnowledgeList")]
    public class FaqList : AppPage<_>
    {
        /// <summary>
        /// Gets FAQ table.
        /// </summary>
        [FindById("dgList")]
        public Table<FaqTableRow, _> Faq { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from "FAQ" table.
        /// </summary>
        public class FaqTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Name" value for a row.
            /// </summary>
            [WaitForJQueryAjax]
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<FaqEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
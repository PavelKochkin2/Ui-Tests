// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailList.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.Email
{
    using Atata;
    using _ = EmailList;

    /// <summary>
    /// The Page Object class represents "Email" list page.
    /// </summary>
    [Url("default.aspx?subj=admin/emails/EmailList")]
    public class EmailList : AppPage<_>
    {
        /// <summary>
        /// Gets the "Email" table.
        /// </summary>
        [FindById("dgList")]
        public Table<EmailTableRow, _> Email { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from "Email" table.
        /// </summary>
        public class EmailTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Name" value for a row.
            /// </summary>
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Email Subject" value for a row.
            /// </summary>                                 
            [FindByCss("dt-head-center sorting")]            
            public Text<_> Subject { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<EmailEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
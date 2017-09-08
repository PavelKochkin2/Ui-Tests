// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserList.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.User
{
    using Atata;
    using _ = UserList;

    /// <summary>
    /// The Page Object class represents "User" list page.
    /// </summary>
    [Url("default.aspx?subj=admin/users/List")]
    public class UserList : AppPage<_>
    {
        /// <summary>
        /// Gets the "User" table.
        /// </summary>
        [FindById("dgList")]
        public Table<UserTableRow, _> User { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        [WaitForJQueryAjax]        
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from "User" table.
        /// </summary>
        public class UserTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Login" value for a row.
            /// </summary>
            public Text<_> Login { get; private set; }

            /// <summary>
            /// Gets the "First Name" value for a row.
            /// </summary>
            public Text<_> FirstName { get; private set; }

            /// <summary>
            /// Gets the "Last Name" value for a row.
            /// </summary>
            public Text<_> LastName { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<UserEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
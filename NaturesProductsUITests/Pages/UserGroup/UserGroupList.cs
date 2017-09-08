// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserGroupList.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.UserGroup
{
    using Atata;
    using _ = UserGroupList;

    /// <summary>
    /// The Page Object class represents "User Group" list page 
    /// </summary>
    [Url("default.aspx?subj=admin/users/UserGroupList")]
    public class UserGroupList : AppPage<_>
    {
        /// <summary>
        /// Gets the "User groups" table.
        /// </summary>
        [FindById("dgList")]
        public Table<UserGroupTableRow, _> UserGroups { get; private set; }
        
        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The class describes a row from "User Group" table.
        /// </summary>
        public class UserGroupTableRow : TableRow<_>
        {
            /// <summary>
            /// Gets the "Name" value for a row.
            /// </summary>
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Description" value for a row.
            /// </summary>
            public Text<_> Description { get; private set; }

            /// <summary>
            /// Gets the "Edit" button for a row.
            /// </summary>
            [FindById(TermMatch.Contains, "_editLink")]
            public LinkDelegate<UserGroupEditor, _> Edit { get; private set; }

            /// <summary>
            /// Gets the "Delete" button for a row.
            /// </summary>
            [FindById("_deleteLink")]
            public LinkDelegate<_> Delete { get; private set; }
        }
    }
}
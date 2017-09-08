// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserGroupEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.UserGroup
{
    using Atata;
    using _ = UserGroupEditor;

    /// <summary>
    /// The Page Object class represents "User Group" editor page.
    /// </summary>
    [Url("default.aspx?subj=admin/users/UserGroupEditor")]
    [VerifyContent("User Group")]
    public class UserGroupEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Name" field.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_name")]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Description" field.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_description")]
        public TextArea<_> Description { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        public ButtonDelegate<UserGroupList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
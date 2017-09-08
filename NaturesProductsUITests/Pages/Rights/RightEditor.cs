// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RightEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.Rights
{
    using Atata;
    using _ = RightEditor;

    /// <summary>
    /// The Page Object class represents "Right" editor page 
    /// </summary>
    [Url("default.aspx?subj=admin/Rights/RightEditor&mode=edit")]
    public class RightEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Code" field.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_Code")]
        public TextInput<_> Code { get; private set; }

        /// <summary>
        /// Gets the "Name" field.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_name")]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Description" text area.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_Description")]
        public TextArea<_> Description { get; private set; }

        /// <summary>
        /// Gets the "Client Group" drop-down.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_ClientGroups")]
        public Select<Data.ClientGroupData, _> ClientGroup { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        public ButtonDelegate<RightList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
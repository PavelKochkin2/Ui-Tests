// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaqEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.FAQ
{
    using Atata;
    using _ = FaqEditor;

    /// <summary>
    /// The Page Object class represents "FAQ" editor page.
    /// </summary>
    [Url("default.aspx?subj=admin/knowledge/KnowledgeEditor")]
    public class FaqEditor : AppPage<_>
    {
        /// <summary>
        /// Gets "Name" field.
        /// </summary>
        [FindById]
        [WaitForJQueryAjax]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Item text" text area.
        /// </summary>
        [FindById("itemText")]
        public TextArea<_> ItemText { get; private set; }

        /// <summary>
        /// Gets the "Response text" text area.
        /// </summary>
        [FindById("responseText")]
        public TextArea<_> ResponseText { get; private set; }

        /// <summary>
        /// Gets the "Companies" select list.
        /// </summary>
        [FindById("companies")]
        public Select<Data.CompanyData, _> Companies { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        [WaitForJQueryAjax]
        public ButtonDelegate<FaqList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.Email
{
    using Atata;
    using _ = EmailEditor;

    /// <summary>
    /// The Page Object class represents "Email" editor page 
    /// </summary>
    [Url("default.aspx?subj=admin/emails/EmailEditor")]
    public class EmailEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Name" field.
        /// </summary>
        [FindById("emailName")]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Subject" field.
        /// </summary>
        [FindById("emailSubject")]
        public TextInput<_> Subject { get; private set; }

        /// <summary>
        /// Gets the "From" field.
        /// </summary>
        [FindById("defaultFrom")]
        public TextInput<_> From { get; private set; }

        /// <summary>
        /// Gets the "To" field.
        /// </summary>
        [FindById("defaultTo")]
        public TextInput<_> To { get; private set; }

        /// <summary>
        /// Gets the "Cc" field.
        /// </summary>
        [FindById("defaultCc")]
        public TextInput<_> Cc { get; private set; }

        /// <summary>
        /// Gets the "Body" TinyMCE window.
        /// </summary>
        [FindById("tinymce")]
        public TextArea<_> Body { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        [WaitForJQueryAjax]
        public ButtonDelegate<EmailList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
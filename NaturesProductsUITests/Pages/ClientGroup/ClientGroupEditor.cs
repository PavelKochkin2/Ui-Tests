// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientGroupEditor.cs" company="Authority Software">
//   Authority Software
// </copyright>
// <summary>
//   Defines the CampaignList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.ClientGroup
{
    using Atata;
    using _ = ClientGroupEditor;

    /// <summary>
    /// The Page Object class represents "Client Group" editor page .
    /// </summary>
    [Url("default.aspx?subj=admin/clients/ClientGroupEditor")]
    public class ClientGroupEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Account suspended" checkbox.
        /// </summary>
        [FindById("suspended")]
        public CheckBox<_> AccountSuspended { get; private set; }

        /// <summary>
        /// Gets the "Code" field.
        /// </summary>
        [FindById("code")]
        [RandomizeStringSettings(numberOfCharacters: 10)]                            
        public TextInput<_> Code { get; private set; }

        /// <summary>
        /// Gets the "Name" field.
        /// </summary>
        [FindById("name")]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Default campaign" drop-down.
        /// </summary>
        [FindById("defaultCampaign")]
        public Select<Data.CampaignData, _> DefaultCampaign { get; private set; }

        /// <summary>
        /// Gets the "Custom page address" field.
        /// </summary>
        [FindById("pageAddress")]
        public TextInput<_> CustomPageAddress { get; private set; }

        /// <summary>
        /// Gets the "Individual recordings folder" checkbox.
        /// </summary>
        [FindById("individualRecordingsFolder")]
        public CheckBox<_> IndividualRecordingsFolder { get; private set; }

        /// <summary>
        /// Gets the "Five9 login" field.
        /// </summary>
        [FindById("five9Login")]
        public TextInput<_> Five9Login { get; private set; }

        /// <summary>
        /// Gets the "Five9 password" field.
        /// </summary>
        [FindById("five9Password")]
        public TextInput<_> Five9Password { get; private set; }

        /// <summary>
        /// Gets the "Five9 domain" field.
        /// </summary>
        [FindById("five9Domain")]
        public TextInput<_> Five9Domain { get; private set; }

        /// <summary>
        /// Gets the "Five9 API Url" field.
        /// </summary>
        [FindById("five9ApiUrl")]
        public TextInput<_> Five9ApiUrl { get; private set; }

        /// <summary>
        /// Gets the "Secondary Five9 Login" field.
        /// </summary>
        [FindById("secondaryFive9Login")]
        public TextInput<_> SecFive9Login { get; private set; }

        /// <summary>
        /// Gets the "Secondary Five9 Password" field.
        /// </summary>
        [FindById("secondaryFive9Password")]
        public TextInput<_> SecFive9Password { get; private set; }

        /// <summary>
        /// Gets the "Secondary Five9 Domain" field.
        /// </summary>
        [FindById("secondaryFive9Domen")]
        public TextInput<_> SecFive9Domain { get; private set; }

        /// <summary>
        /// Gets the "Synchronize with Five9" drop-down.
        /// </summary>
        [FindById("synchronize")]
        public Select<Data.SynchronizeWithFive9Data, _> SynchronizeWithFive9 { get; private set; }

        /// <summary>
        /// Gets the "SMTP server address" field.
        /// </summary>
        [FindById("emailServerAddress")]
        public TextInput<_> SmtpServerAddress { get; private set; }

        /// <summary>
        /// Gets the "SMTP server port" number input.
        /// </summary>
        [FindById("emailServerPort")]
        public NumberInput<_> SmtpServerPort { get; private set; }

        /// <summary>
        /// Gets the "SMTP server requires SSL" checkbox.
        /// </summary>
        [FindById("emailServerUseSsl")]
        public CheckBox<_> SmtpRequiresSsl { get; private set; }

        /// <summary>
        /// Gets the "Mailbox" field.
        /// </summary>
        [FindById("emailServerLogin")]
        public TextInput<_> Mailbox { get; private set; }

        /// <summary>
        /// Gets the "Mailbox password" field.
        /// </summary>
        [FindById("emailServerPassword")]
        public TextInput<_> MailboxPassword { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        [WaitForJQueryAjax]
        [FindById("SubmitBtn")]
        public ButtonDelegate<ClientGroupList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
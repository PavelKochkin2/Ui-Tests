// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace NaturesProductsUITests.Pages.User 
{
    using Atata;
    using _ = UserEditor;

    /// <summary>
    /// The Page Object class represents "User" editor page.
    /// </summary>
    [Url("default.aspx?subj=admin/users/UserEditor")]
    public class UserEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the "Login" field.
        /// </summary>
        [FindById("Login")]
        public TextInput<_> Login { get; private set; }

        /// <summary>
        /// Gets the "Password" field.
        /// </summary>
        [FindById("Password")]
        public PasswordInput<_> Password { get; private set; }

        /// <summary>
        /// Gets the "Re-Enter Password" field.
        /// </summary>
        [FindById("PasswordConfirm")]
        public PasswordInput<_> PasswordConfirm { get; private set; }

        /// <summary>
        /// Gets the "First Name" field.
        /// </summary>
        [FindById("FirstName")]
        public TextInput<_> FirstName { get; private set; }

        /// <summary>
        /// Gets the "Last Name" field.
        /// </summary>
        [FindById("LastName")]
        public TextInput<_> LastName { get; private set; }

        /// <summary>
        /// Gets the "E-mail" field.
        /// </summary>
        [FindById("Email")]
        [RandomizeStringSettings("{0}@mail.com")]
        [RandomizeNumberSettings]
        public TextInput<_> Email { get; private set; }

        /// <summary>
        /// Gets the "Client Group" drop-down.
        /// </summary>
        [FindById("ClientGroups")]
        public Select<Data.ClientGroupData, _> ClientGroup { get; private set; }

        /// <summary>
        /// Gets the "Company" drop-down.
        /// </summary>
        [FindById("Companies")]
        public Select<Data.CompanyData, _> Companies { get; private set; }

        /// <summary>
        /// Gets the "Time Zone" drop-down.
        /// </summary>
        public Select<Data.TimeZoneData, _> TimeZone { get; private set; }

        /// <summary>
        /// Gets the "Campaign" drop-down.
        /// </summary>
        [FindById("Campaigns")]
        public Select<Data.CampaignData, _> Campaigns { get; private set; }

        /// <summary>
        /// Gets the "Country" drop-down.
        /// </summary>
        [FindById("Countries")]
        public Select<Data.CountryData, _> Countries { get; private set; }

        /// <summary>
        /// Gets the "Zip" field.
        /// </summary>
        [RandomizeNumberSettings(11111, 99999)]        
        [FindById("Zip")]
        public NumberInput<_> Zip { get; private set; }

        /// <summary>
        /// Gets the "State" drop-down.
        /// </summary>
        [FindById("States")]
        public Select<Data.StateData, _> States { get; private set; }

        /// <summary>
        /// Gets the "County" field.
        /// </summary>
        [FindById("County")]
        public TextInput<_> County { get; private set; }

        /// <summary>
        /// Gets the "City" field.
        /// </summary>
        [FindById("City")]
        public TextInput<_> City { get; private set; }

        /// <summary>
        /// Gets the "Address 1" field.
        /// </summary>
        [FindById("Address")]
        public TextInput<_> Address { get; private set; }

        /// <summary>
        /// Gets the "Address 2" field.
        /// </summary>
        [FindById("Address2")]
        public TextInput<_> Address2 { get; private set; }

        /// <summary>
        /// Gets the "Phone" field.
        /// </summary>
        [FindById("Phone")]        
        public TextInput<_> Phone { get; private set; }

        /// <summary>
        /// Gets the "Filter" drop-down.
        /// </summary>
        [FindById("Filter")]
        public Select<Data.FilterData, _> Filter { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        [WaitForJQueryAjax]
        public ButtonDelegate<UserList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessages { get; private set; }
    }
}
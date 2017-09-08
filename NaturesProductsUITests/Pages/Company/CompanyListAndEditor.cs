// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyListAndEditor.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   Defines the CompanyListAndEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.Company
{
    using Atata;
    using _ = CompanyListAndEditor;

    /// <summary>
    /// The Page Object class represents Company page(contains both list and editor).
    /// </summary>
    [Url("default.aspx?subj=admin/company/CompanyTree")]
    public class CompanyListAndEditor : AppPage<_>
    {
        /// <summary>
        /// Gets the Company row item in companies list.
        /// </summary>
        [FindByClass(TermMatch.Contains, "company-tree-root-elements")]
        public UnorderedList<ListItem<_>, _> UnorderedList { get; private set; }

        /// <summary>
        /// Gets the company list.
        /// </summary>
        public UnorderedList<CompanyItem, _> CompanyList { get; private set; }

        /// <summary>
        /// Gets the button which expands the Companies list.
        /// </summary>
        public Expand<_> Expand { get; private set; }

        /// <summary>
        /// Gets the add company.
        /// </summary>
        public AddCompany<_> AddCompany { get; private set; }

        /// <summary>
        /// Gets the "Name" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains)]
        public TextInput<_> Name { get; private set; }

        /// <summary>
        /// Gets the "Zip" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains)]
        [RandomizeStringSettings(numberOfCharacters: 5)]
        public TextInput<_> Zip { get; private set; }

        /// <summary>
        /// Gets the "County" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains)]
        public TextInput<_> County { get; private set; }

        /// <summary>
        /// Gets the "City" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains)]
        public TextInput<_> City { get; private set; }

        /// <summary>
        /// Gets the "Address 1" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains, TermCase.Pascal)]
        public TextInput<_> Address1 { get; private set; }

        /// <summary>
        /// Gets the "Address 2" field in Campaign editor.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains, TermCase.Pascal)]
        public TextInput<_> Address2 { get; private set; }

        /// <summary>
        /// Gets the "Country" drop-down.
        /// </summary>
        [FindByAttribute("data-bind", TermMatch.Contains)]
        public Select<Data.CountryData, _> Country { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        public ButtonDelegate<_> Save { get; private set; }

        /// <summary>
        /// Gets the add button.
        /// </summary>
        public ButtonDelegate<_> Add { get; private set; }

        /// <summary>
        /// Gets the "OK" button in confirm deleting popup.
        /// </summary>
        public ButtonDelegate<_> OK { get; private set; }

        /// <summary>
        /// The company item.
        /// </summary>
        public class CompanyItem : ListItem<_>
        {
            /// <summary>
            /// Gets the "Name" value.
            /// </summary>
            public Text<_> Name { get; private set; }

            /// <summary>
            /// Gets the "Delete" button.
            /// </summary>
            public Delete<_> Delete1 { get; private set; }
        }
    }
}

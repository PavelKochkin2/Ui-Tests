// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignTypeEditor.cs" company="Authority Software">
//   Authority Software
// </copyright>
// <summary>
//   Defines the CampaignList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.CampaignType
{
    using Atata;
    using _ = CampaignTypeEditor;

    /// <summary>
    /// The Page Object class represents "Campaign Types" Editor page.
    /// </summary>
    [Url("default.aspx?subj=admin/Types/TypeEditor&mode=edit&categoryId=25")]
    [VerifyContent("Skill types Campaign Types")]

    public class CampaignTypeEditor : AppPage<_>
    {
        /// <summary> 
        /// Gets the "Name" field.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_name")]
        public TextInput<_> Name { get; private set; }

        /// <summary> 
        /// Gets the "Description" text entry.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_description")]
        public TextArea<_> Description { get; private set; }

        /// <summary>
        /// Gets the "Client Group" drop- down.
        /// </summary>
        [FindById(TermMatch.EndsWith, "_clientGroupList")]
        public Select<Data.ClientGroupData?, _> ClientGroup { get; private set; }

        /// <summary>
        /// Gets the "Save" button.
        /// </summary>
        public ButtonDelegate<CampaignTypeList, _> Save { get; private set; }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        public ValidationMessageList<_> ValidationMessage { get; private set; }
    }        
}
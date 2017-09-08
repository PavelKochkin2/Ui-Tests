// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignData.cs" company="Authority Software">
//  Authority Software 
// </copyright>
// <summary>
//   Defines the CampaignData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Data
{
    using Atata;

    /// <summary>
    /// The class contains enum test Campaigns.
    /// </summary>
    [TermSettings(TermCase.LowerMerged)]
    public enum CampaignData
    {
        /// <summary>
        /// Represents the campaign with "edit" name.
        /// </summary>
        edit,

        /// <summary>
        /// Represents the campaign with "delete" name.
        /// </summary>
        delete,

        /// <summary>
        /// Represents the campaign with "share" name.
        /// </summary>
        share
    }
}
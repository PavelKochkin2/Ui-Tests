// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryData.cs" company="Authority Software">
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
    /// The class contains enum Countries.
    /// </summary>
    public enum CountryData
    {
        /// <summary>
        /// The "Spain" value for "Country" drop- down.
        /// </summary>
        Spain,

        /// <summary>
        /// The "United States of America" value for "Country" drop- down.
        /// </summary>
        [Term("United States of America")]
        UnitedStatesofAmerica
    }
}
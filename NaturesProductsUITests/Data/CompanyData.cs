// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyData.cs" company="Authority Software">
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
    /// The class contains enum test Companies.
    /// </summary>
    [TermSettings(TermCase.Pascal)]    
    public enum CompanyData
    {
        /// <summary>
        /// The company with "ExistingCompany" name.
        /// </summary>
        ExistingCompany,

        /// <summary>
        /// The company with "DeleteCompany" name.
        /// </summary>
        DeleteCompany
    }
}
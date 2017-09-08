// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyUlControl.cs" company="Authority CRM">
//   Authority CRM
// </copyright>
// <summary>
//   The expand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NaturesProductsUITests.Pages.Company
{
    using Atata;

    /// <inheritdoc />
    /// <summary>
    /// The list item.
    /// </summary>
    /// <typeparam name="TOwner"> The first generic type parameter
    /// </typeparam>
    [ControlDefinition("li", ComponentTypeName = "list item")]
    public class ListItem<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// The unordered list.
    /// </summary>
    /// <typeparam name="TItem"> The first generic type parameter
    /// </typeparam>
    /// <typeparam name="TOwner"> The first generic type parameter
    /// </typeparam>
    public class UnorderedList<TItem, TOwner> : ItemsControl<TItem, TOwner>
        where TItem : Control<TOwner>, new() where TOwner : PageObject<TOwner>
    {
    }
}
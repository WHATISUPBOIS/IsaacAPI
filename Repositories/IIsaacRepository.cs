/// <summary>
/// Defines all methods required for an IsaacAPI repository.
/// </summary>
public interface IIsaacRepository
{
    // -----Base Character-----

    /// <summary>
    /// Return a list of all base characters.
    /// </summary>
    /// <returns></returns>
    List<BaseCharacter> GetAllBaseCharacters();

    /// <summary>
    /// Return the base character under the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A base character, if one is found.</returns>
    BaseCharacter? GetBaseCharacterById(int id);

    /// <summary>
    /// Create a base character.
    /// </summary>
    /// <param name="baseCharacter">The base character to create.</param>
    /// <returns>The base character that is created.</returns>
    BaseCharacter CreateBaseCharacter(BaseCharacter baseCharacter);

    // -----Character-----

    /// <summary>
    /// Return the character under the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A character, if one is found.</returns>
    Character? GetCharacterById(int id);

    /// <summary>
    /// Create a character.
    /// </summary>
    /// <param name="character">The character to create.</param>
    /// <returns>The character that was created.</returns>
    Character CreateCharacter(Character character);

    /// <summary>
    /// Add an existing item to a character's list of items.
    /// </summary>
    /// <param name="charId">ID of the character to be modified.</param>
    /// <param name="itemId">ID of the item to be added.</param>
    /// <returns>The modified character.</returns>
    Character AddItemToCharacter(int charId, int itemId);

    // -----Item-----

    /// <summary>
    /// Return the item under the specified ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>An item, if one is found.</returns>
    Item? GetItemByID(int id);

    /// <summary>
    /// Return a list of all items.
    /// </summary>
    /// <returns></returns>
    List<Item> GetAllItems();

    /// <summary>
    /// Create an item.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <returns>The item that was created.</returns>
    Item CreateItem(Item item);



}
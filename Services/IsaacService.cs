/// <summary>
/// The service layer.
/// </summary>
public class IsaacService
{
    private readonly IIsaacRepository isaacRepository;
    public IsaacService(IIsaacRepository repository)
    {
        isaacRepository = repository;
    }

    // -----Base Character-----
    public List<BaseCharacter> GetAllBaseCharacters()
    {
        return isaacRepository.GetAllBaseCharacters();
    }

    public BaseCharacter? GetBaseCharacterById(int id)
    {
        BaseCharacter? baseCharacter = isaacRepository.GetBaseCharacterById(id);
        if(baseCharacter == null)
        {
            throw new EntityNotFoundException("Could not find base character with id {id}.");
        }
        else
        {
            return baseCharacter;
        }
    }

    public BaseCharacter CreateBaseCharacter(BaseCharacterCreateRequest request)
    {
        // Map request to the base character we are creating.
        BaseCharacter baseCharacter = new BaseCharacter
        {
            Name = request.Name,
            Speed = request.Speed,
            TearsUp = request.TearsUp,
            BaseDamage = request.BaseDamage,
            DamageMult = request.DamageMult,
            Range = request.Range,
            ShotSpeed = request.ShotSpeed,
            Luck = request.Luck
        };
        // Tell the repository to add our base character to the database.
        return isaacRepository.CreateBaseCharacter(baseCharacter);
    }

    public void DeleteBaseCharacterById(int id)
    {
        BaseCharacter? baseCharacter = isaacRepository.GetBaseCharacterById(id);
        if(baseCharacter == null)
        {
            throw new EntityNotFoundException($"Could not find base character with id {id}.");
        }
        else
        {
            isaacRepository.DeleteBaseCharacter(baseCharacter);
        }
    }

    // -----Character-----

    public Character? GetCharacterById(int id)
    {
        Character? character = isaacRepository.GetCharacterById(id);
        if(character == null)
        {
            throw new EntityNotFoundException($"Could not find character with id {id}.");
        }
        else
        {
            return character;
        }
    }

    public Character CreateCharacter(CharacterCreateRequest request)
    {
        // Map request to character we are creating.
        Character character = new Character
        {
            Name = request.Name,
            BaseCharacterId = request.BaseCharacterId
        };
        // Tell the repository to add our character to the database.
        return isaacRepository.CreateCharacter(character);
    }

    public Character AddItemToCharacter(int charId, int itemId)
    {
        Character? updatedCharacter = isaacRepository.GetCharacterById(charId);
        if(updatedCharacter == null)
        {
            throw new EntityNotFoundException($"Character with ID {charId} not found.");
        }
        else
        {
            Item? itemToAdd = isaacRepository.GetItemById(itemId);
            if(itemToAdd == null)
            {
                throw new EntityNotFoundException($"Item with ID {itemId} not found.");
            }
            else
            {
                return isaacRepository.AddItemToCharacter(updatedCharacter, itemToAdd);
            }
        }    
    }

    public void DeleteCharacterById(int id)
    {
        Character? character = isaacRepository.GetCharacterById(id);
        if(character == null)
        {
            throw new EntityNotFoundException($"Cannot find character with id {id}.");
        }
        else
        {
            isaacRepository.DeleteCharacter(character);
        }
    }

    // -----Item-----

    public Item? GetItemById(int id)
    {
        Item? item = isaacRepository.GetItemById(id);
        if(item == null)
        {
            throw new EntityNotFoundException($"Cannot find item with id {id}.");
        }
        else
        {
            return isaacRepository.GetItemById(id);
        }
    }

    public List<Item> GetAllItems()
    {
        return isaacRepository.GetAllItems();
    }

    public Item CreateItem(ItemCreateRequest request)
    {
        // Map request to item we are creating.
        Item item = new Item
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            SpeedUp = request.SpeedUp,
            DamageUp = request.DamageUp,
            DamageMult = request.DamageMult,
            TearsUp = request.TearsUp,
            FireRateUp = request.FireRateUp,
            RangeUp = request.RangeUp,
            ShotSpeedUp = request.ShotSpeedUp,
            LuckUp = request.LuckUp
        };
        // Tell the repository to add our item to the database.
        return isaacRepository.CreateItem(item);
    }

    public void DeleteItemById(int id)
    {
        Item? item = isaacRepository.GetItemById(id);
        if(item == null)
        {
            throw new EntityNotFoundException($"Cannot find item with id {id}.");
        }
        else
        {
            isaacRepository.DeleteItem(item);
        }
    }
}
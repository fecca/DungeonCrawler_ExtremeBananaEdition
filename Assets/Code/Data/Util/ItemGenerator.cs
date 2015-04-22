public class ItemGenerator
{
    public static Item GenerateItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.Axe:
                return new Axe();
            case ItemType.Hammer:
                return new Hammer();
            case ItemType.Sword:
                return new Sword();
            default:
                return null;
        }
    }
}
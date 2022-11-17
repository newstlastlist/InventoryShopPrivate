

public class InventorySection : AbstractItemsSection
{
    public override void AddItemRepresenterToSection(Item item, ItemRepresenterInUI representer)
    {
        if(item.ItemType == sectionType)
        {
            SetUpAndAddRepresenter(item, representer);
        }
    }
    protected override void SetUpAndAddRepresenter(Item item, ItemRepresenterInUI representer)
    {
        base.SetUpAndAddRepresenter(item, representer);
        sectionItem.SetActionOnClick(() => EquipItem(item));
    }

    private void EquipItem(Item item)
    {
        player.GetComponent<PlayerItemsEquiper>().TryToEquip(item);
    }
}

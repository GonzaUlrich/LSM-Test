using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInteraction : MonoBehaviour
{
    private bool itemSold= false;
    public void SellItem()
    {
        InventoryManager.Instance.SellItem(transform.parent.parent.gameObject);
    }

    public void EquipOrUnequipItem()
    {
        InventoryManager.Instance.EquipOrUnequipItem(transform.parent.parent.gameObject);
    }

    public void AddItem(ScriptableItems newItem)
    {
        if (itemSold) { return; }
        InventoryManager.Instance.itemSold += ItemSold;
        InventoryManager.Instance.BuyItem(newItem);
        InventoryManager.Instance.itemSold -= ItemSold;
    }

    private void ItemSold()
    {
        itemSold = true;
        Button button = GetComponent<Button>();
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = "Sold Out";
    }
}

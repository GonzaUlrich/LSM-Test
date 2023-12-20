
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class ScriptableItems : ScriptableObject
{
    [SerializeField] private Sprite itemImage;
    [SerializeField] private string itemName;
    [SerializeField] private int sellPrice;
    [SerializeField] private int buyPrice;
    

    public Sprite ItemImage => itemImage;
    public string ItemName => itemName;
    public int SellPrice => sellPrice;
    public int BuyPrice => buyPrice;

}

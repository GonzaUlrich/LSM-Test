using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClothes", menuName = "Item/Coin", order = 0)]
public class ScriptableCoins : ScriptableItems
{
    [Range(0, 10)] public float Size;
    public Coins CoinType;
}

public enum Coins
{
    Gold,
    Silver,
    Red
}

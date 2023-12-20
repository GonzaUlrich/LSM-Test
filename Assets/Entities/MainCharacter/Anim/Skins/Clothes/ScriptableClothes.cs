using UnityEngine;

[CreateAssetMenu(fileName = "NewClothes", menuName = "Item/Clothes", order = 1)]
public class ScriptableClothes : ScriptableItems
{
    
    public RuntimeAnimatorController animator;
    public bool isEquipped=false;

    private void OnEnable()
    {
        isEquipped = false;
    }
}

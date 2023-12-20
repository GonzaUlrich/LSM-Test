
using System;
using TMPro;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            InventoryManager.Instance.AddItem(other.gameObject.GetComponent<CoinScript>().Coin);
            Destroy(other.gameObject);
        }
    }
}

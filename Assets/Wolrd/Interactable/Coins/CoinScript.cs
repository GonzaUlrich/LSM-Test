using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public ScriptableCoins Coin;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Blend", (int)Coin.CoinType);
        transform.localScale = Vector3.one * Coin.Size;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinScript coinscript = GetComponent<CoinScript>();
            InventoryManager.Instance.AddItem(coinscript.Coin);
            Destroy(gameObject);
        }
    }


    

}

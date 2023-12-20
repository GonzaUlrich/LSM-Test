using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendorLogic : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _coins;
    [SerializeField] private GameObject _vendorPanel;

    private bool onlyOnce = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowText();
        _vendorPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _vendorPanel.SetActive(false);
    }

    public void ShowText()
    {
        if (!onlyOnce) { return; }
        
        onlyOnce = false;
        _text.SetActive(true);
        _coins.SetActive(true);
        StartCoroutine(WaitSeconds(10));
    }

    IEnumerator WaitSeconds(int time)
    {
        yield return new WaitForSeconds(time);
        _text.SetActive(false);
    }
}

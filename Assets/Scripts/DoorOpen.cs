using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject _doorClose;
    [SerializeField] private GameObject _doorOpen;
    [SerializeField] private GameObject _roof;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") { return; }

        _doorOpen.SetActive(true);
        _doorClose.SetActive(false);
        _roof.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") { return; }

        _doorOpen.SetActive(false);
        _doorClose.SetActive(true);
    }
}

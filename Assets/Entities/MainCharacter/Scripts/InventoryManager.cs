using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static InventoryManager;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;

    public Action itemSold;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("InventoryManager");
                    instance = obj.AddComponent<InventoryManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _textMeshPro;
    [SerializeField] private Skins _body;
    private List<InventoryItems> _inventoryItems = new List<InventoryItems>();

    public class InventoryItems
    {
        public GameObject ItemIcon;
        public GameObject SellIcon;
        public ScriptableItems Item;
        public string NameOfInventorySlot;
        public InventoryItems(GameObject itemIcon, GameObject sellIcon)
        {
            ItemIcon = itemIcon;
            SellIcon = sellIcon;
            Item = null;
        }
    }
    private void Awake()
    {


        for (int i = 0; i < _panel.transform.childCount; i++)
        {

            Transform inventorySlot = _panel.transform.GetChild(i);
            Transform panelSon = inventorySlot.GetChild(0);
            InventoryItems invIt = new InventoryItems(panelSon.GetChild(0).gameObject, panelSon.GetChild(1).gameObject);
            invIt.NameOfInventorySlot = inventorySlot.gameObject.name;
            _inventoryItems.Add(invIt);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _panel.SetActive(!_panel.activeInHierarchy);
        }
    }

    public void AddItem(ScriptableItems newItem)
    {
        for (int i = 0; i < _inventoryItems.Count; i++)
        {

            if (_inventoryItems[i].Item == null)
            {
                _inventoryItems[i].Item = newItem;
                ShowInInventory(i);
                return;
            }
        }
    }

    public void BuyItem(ScriptableItems newItem)
    {
        int coinAmount = Int32.Parse(_textMeshPro.text);
        int playerCoins = newItem.BuyPrice;

        coinAmount -= playerCoins;
        if (coinAmount < 0) { return; }
        SavePlayerMoney(coinAmount);
        itemSold?.Invoke();
        AddItem(newItem);
    }

    public void SellItem(GameObject itemName)
    {
        InventoryItems actualItem = _inventoryItems.Find(item => item.NameOfInventorySlot == itemName.name);

        if (actualItem == null) { return; }
        actualItem.SellIcon.SetActive(false);
        actualItem.ItemIcon.SetActive(false);
        actualItem.ItemIcon.GetComponent<Image>().sprite = null;

        int coinAmount = Int32.Parse(_textMeshPro.text);
        int playerCoins = actualItem.Item.SellPrice;

        playerCoins += coinAmount;
        SavePlayerMoney(playerCoins);

        ScriptableClothes scriptableClothes = actualItem.Item as ScriptableClothes;
        if (scriptableClothes != null)
        {
            if (scriptableClothes.isEquipped)
            {
                _body.UnEquipClothes();
            }
        }

        actualItem.Item =  null;
        return;

    }

    public void EquipOrUnequipItem(GameObject itemName)
    {
        InventoryItems actualItem = _inventoryItems.Find(item => item.NameOfInventorySlot == itemName.name);

        if (actualItem == null) { return; }

        ScriptableClothes scriptableClothes = actualItem.Item as ScriptableClothes;
        if (scriptableClothes == null) { return; }
        ScriptableClothes otherClothes = _body._scriptableClothes;
        if(scriptableClothes == otherClothes)
        {
            _body.UnEquipClothes();
        }
        else
        {
            _body._scriptableClothes = scriptableClothes;
            _body.ChangeClothes();
            scriptableClothes.isEquipped = true;
            if(otherClothes == null) { return; }
            otherClothes.isEquipped = false;
        }

        


    }

    private void ShowInInventory(int i)
    {
        _inventoryItems[i].SellIcon.SetActive(true);
        _inventoryItems[i].ItemIcon.SetActive(true);
        _inventoryItems[i].ItemIcon.GetComponent<Image>().sprite = _inventoryItems[i].Item.ItemImage;

    }
    private void SavePlayerMoney(int addCoins)
    {
        _textMeshPro.text = addCoins.ToString();
    }
}

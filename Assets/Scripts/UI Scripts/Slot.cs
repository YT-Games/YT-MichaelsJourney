using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour
{
    public List<GameObject> items;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    
    public TextMeshProUGUI amountTMP;

    public Transform slotIconGO;
    public Sprite icon;

    private void Start()
    {
        slotIconGO = transform.GetChild(0);

        items = new List<GameObject>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
        if (items.Count-1 >= 2)
        {
            amountTMP.text = (items.Count-1).ToString();
            amountTMP.gameObject.SetActive(true);
        }
    }

    public void UseItem()
    {
        items[0].GetComponent<Item>().ItemUsage();
    }
}

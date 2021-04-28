using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;
    private bool inventoryEnabled;

    private int slotsCount;
    //private Transform[] slot;
    private List<Slot> slot = new List<Slot>();

    private GameObject itemPickedUp;
    private bool itemAdded;


    public void Start()
    {
        slotsCount = slotHolder.transform.childCount;
        //slot = new Transform[slots];
        DetectInventorySlots();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        { inventory.SetActive(false);
          Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Item>())
        {
            Debug.Log("Test");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemAdded = false;
        }

    }
        

    public void AddItem(GameObject item)
    {
        Debug.Log("item addded 0");
        for ( int i = 0; i < slotsCount; i++)
        {
            Debug.Log("item addded 1");
            Debug.Log("itemAdded: " + itemAdded);
            Debug.Log("slot[i].empty: " + slot[i].empty);
            if (slot[i].empty && itemAdded == false)
            {
                slot[i].item = itemPickedUp;
                slot[i].itemIcon = itemPickedUp.GetComponent<Item>().icon;
                itemAdded = true;
                Debug.Log("item addded 2");
            }
        }
    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            //slot[i] = slotHolder.transform.GetChild(i).GetComponent<Slot>();
            slot.Add(slotHolder.transform.GetChild(i).GetComponent<Slot>());
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject slotHolder;
    private bool inventoryEnabled;

    private int slots;
    private Transform[] slot;

    private GameObject itemPickedUp;
    private bool itemAdded;


    public void Start()
    {
        slots = slotHolder.transform.childCount;
        slot = new Transform[slots];
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
        for( int i = 0; i < slots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty && itemAdded == false)
            {
                slot[i].GetComponent<Slot>().item = itemPickedUp;
                slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().icon;
                itemAdded = true;
            }
        }
    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
        }
    }

}
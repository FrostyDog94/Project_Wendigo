using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public StoryManager storyManager;

    private void Start()
    {
        storyManager = GameObject.Find("Story Manager").GetComponent<StoryManager>();
    }

    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);

        if (referenceItem.destroyOnPickup)
        {
            Destroy(gameObject);
        }

        storyManager.CheckInventory();
    }
}

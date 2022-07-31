using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        InventorySystem.current.Add(referenceItem);

        if (referenceItem.destroyOnPickup)
        {
            Destroy(gameObject);
        }
    }
}

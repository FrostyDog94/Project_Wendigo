using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private Image m_icon;
    [SerializeField]
    private TMP_Text m_label;
    [SerializeField]
    private GameObject m_stackObj;
    [SerializeField]
    private TMP_Text m_stackLabel;

    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        //m_label.text = item.data.displayName;
        if (item.stackSize <= 1)
        {
            //m_stackObj.SetActive(false);
            return;
        }

        //m_stackLabel.text = item.stackSize.ToString();
    }

}

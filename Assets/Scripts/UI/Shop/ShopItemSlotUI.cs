using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlotUI : MonoBehaviour
{
    public Button m_Button;
    [SerializeField]
    TextMeshProUGUI m_ItemName;
    [SerializeField]
    TextMeshProUGUI m_Description;
    [SerializeField]
    TextMeshProUGUI m_Price;
    [SerializeField]
    TextMeshProUGUI m_ItemCount;
    [SerializeField]
    TextMeshProUGUI m_Effect;
    [SerializeField]
    Image m_Icon;



    public void SetData(ShopItemSO data)
    {
        m_ItemName.text = data.Name;
        m_Description.text = data.Description;
        m_Price.text = data.Price.ToString();
        m_ItemCount.text = data.Count.ToString();
    }
    public void SetBuyButtonEnable(bool enable)
    {
        m_Button.gameObject.SetActive(enable);
    }
    public void SetSlotLocked()
    {
        m_Button.gameObject.SetActive(false);
    }
}

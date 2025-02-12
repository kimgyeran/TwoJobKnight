using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public List<ShopItemSO> Items;
    [SerializeField]
    private GameObject m_ShopPanel;
    [SerializeField]
    private GameObject m_ShopItemPrefab;
    [SerializeField]
    private GameObject m_ShopItemContainer;
    private List<ShopItemSlotUI> m_ItemSlots;

    private void Awake()
    {
        m_ItemSlots = new List<ShopItemSlotUI>();
    }

    void ShopInit()
    {

    }
    void GenerateAllSlot()
    {
        foreach (var item in Items)
        {
            var obj = Instantiate(m_ShopItemPrefab, m_ShopItemContainer.transform);
            var slot = obj.GetComponent<ShopItemSlotUI>();
            slot.SetData(item);
            slot.m_Button.onClick.AddListener(()=> {  });
            m_ItemSlots.Add(slot);
        }
    }
    void Buy()
    {

    }
}

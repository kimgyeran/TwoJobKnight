using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "ScriptableObject/ShopItem")]
public class ShopItemSO : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public long Price;
    public string Icon;
    public long Count;
    public UnityEvent OnItemUse;
    public delegate bool UnlockCondition();
    public UnlockCondition[] UnlockConditoins;

    public virtual void Use()
    {
        OnItemUse?.Invoke();
    }

}

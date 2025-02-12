using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewMonsterData", menuName = "ScriptableObject/Monster")]
public class MonsterSO : ScriptableObject
{
    public int ID;
    public string Name;
    public int Level;
    public long MaxHP;
    public long Gold;
    public int MaxHPIncreaseRate;
    public int GoldIncreaseRate;

    public void LevelUp()
    {
        MaxHP += MaxHP * (long)(MaxHPIncreaseRate / 100m);
        Gold += Gold * (long)(GoldIncreaseRate / 100m);
        Level++;
    }

    public void Init()
    {
        Level = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewMonsterData",menuName ="ScriptableObject/Monster")]
public class MonsterData : ScriptableObject
{
    public int ID;
    public string Name;
    public int Level;
    public float MaxHP;
    public long Gold;
}

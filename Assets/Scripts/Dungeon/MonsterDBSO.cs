using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonsterDB", menuName = "ScriptableObject/MonsterDB")]
public class MonsterDBSO : ScriptableObject
{
    [SerializeField]
    MonsterSO[] m_MonsterDB;
    public int Count
    {
        get { return m_MonsterDB.Length; }
    }
    public MonsterSO GetItem(int id)
    {
        return m_MonsterDB[id];
    }
    public MonsterSO this[int id]
    {
        get
        {
            // 배열 인덱스가 유효한지 체크
            if (id >= 0 && id < m_MonsterDB.Length)
            {
                return m_MonsterDB[id];
            }
            else
            {
                Debug.LogWarning("Index out of range!");
                return null;
            }
        }
    }
}

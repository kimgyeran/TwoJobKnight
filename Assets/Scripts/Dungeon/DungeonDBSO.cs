using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewDungeonDB", menuName = "ScriptableObject/DungeonDB")]
public class DungeonDBSO : ScriptableObject
{
    [SerializeField]
    DungeonSO[] m_DungeonDB;
    public int Count
    {
        get { return m_DungeonDB.Length; }
    }
    public DungeonSO GetItem(int id)
    {
        return m_DungeonDB[id];
    }
    public DungeonSO this[int id]
    {
        get
        {
            // 배열 인덱스가 유효한지 체크
            if (id >= 0 && id < m_DungeonDB.Length)
            {
                return m_DungeonDB[id];
            }
            else
            {
                Debug.LogWarning("Index out of range!");
                return null;
            }
        }
    }
}

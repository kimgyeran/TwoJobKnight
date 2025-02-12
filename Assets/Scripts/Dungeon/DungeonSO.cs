using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDungeonSO", menuName = "ScriptableObject/Dungeon")]

public class DungeonSO : ScriptableObject
{
    public int ID;
    public string Name;
    public string Description;
    public MonsterSO[] Monsters;
    public float[] SpawnProbabilities;

    float[] m_SpawnProbabilitiesSum;
    private void OnEnable()
    {
        m_SpawnProbabilitiesSum = new float[Monsters.Length];
        float sum = 0f;
        for (int i = 0; i < Monsters.Length; i++)
        {
            sum += SpawnProbabilities[i];
            m_SpawnProbabilitiesSum[i] = sum;
        }
    }
    public MonsterSO GetRandomMonster()
    {
        float random = Random.value;
        for (int i = 0; i < SpawnProbabilities.Length; i++)
        {
            if (SpawnProbabilities[i] > random)
                return Monsters[i];
        }
        return Monsters[0];
    }
}

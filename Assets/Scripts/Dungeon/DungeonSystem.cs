using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class DungeonSystem : MonoBehaviour
{
    [Header("View")]
    public Button ClickZone;
    public TextMeshProUGUI MonsterNameText;
    public TextMeshProUGUI MonsterLevelText;
    public GameObject DisableMask;
    [Header("Data")]
    public DungeonSO Dungeon;
    public Monster Monster;
    public Hero Hero;
    public ObjectPool<GameObject> MonsterPool;
    [SerializeField]
    private GameObject m_MonsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.DungeonSystem = this;
        DisableMask.SetActive(true);
        ClickZone.enabled = false;
        Dungeon = null;
        Monster = null;
        MonsterPool = new ObjectPool<GameObject>(MonsterSpawn, OnMonsterGetFromPool);
        ClickZone.onClick.AddListener(OnClickHandler);
        Monster.SpawnEvent.AddListener((m) =>
        {
            MonsterNameText.text = m.Data.Name.ToString();
            MonsterLevelText.text = m.Data.Level.ToString();
        });
        Monster.DeadEvent.AddListener(OnMonsterDead);
        Monster.DisableEvent.AddListener(OnMonsterDisabled);
    }

    void OnClickHandler()
    {
        Hero.Attack();
        Monster.Hit(Hero.AttackDamage);
    }
    void OnMonsterDead(Monster monster)
    {
        GameManager.Instance.Money += monster.Data.Gold;
        MonsterGet();

    }
    void OnMonsterDisabled(Monster monster)
    {
        MonsterPool.Release(monster.gameObject);
    }
    GameObject MonsterSpawn()
    {
        return Instantiate(m_MonsterPrefab);
    }
    void OnMonsterGetFromPool(GameObject monster_obj)
    {
        monster_obj.SetActive(true);
    }

    IEnumerator AutoAttack()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1f);
            Hero.Attack();
            Monster.Hit(Hero.AttackDamage);
        }
    }
    void MonsterGet()
    {
        Monster = MonsterPool.Get().GetComponent<Monster>();
        Monster.Init(Dungeon.GetRandomMonster());
        MonsterLevelText.text = "Lv."+Monster.Data.Level.ToString();
        MonsterNameText.text = Monster.Data.Name;
    }
    public void DungeonChange(DungeonSO dungeonSO)
    {
        if (dungeonSO == null)
            return;
        if(Dungeon == null)
        {
            Dungeon = dungeonSO;
            DungeonEnable();
        }
    }
    void DungeonEnable()
    {
        if (Dungeon == null)
            return;
        DisableMask.SetActive(false);
        MonsterGet();
        MonsterLevelText.enabled = true;
        MonsterNameText.enabled = true;
        ClickZone.enabled = true;
        StartCoroutine(AutoAttack());
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public static UnityEvent<Monster> SpawnEvent = new();
    public static UnityEvent<Monster> DeadEvent = new();
    public static UnityEvent<Monster> DisableEvent = new();
    public MonsterSO Data;
    public long HP;
    public Animator Animator;
    public StateEnum State;
    public bool IsInitialized;
    public Slider HPBar;

    Rigidbody2D m_Rigidbody2D;

    private void Awake()
    {
        IsInitialized = false;
    }

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = HP;
    }

    public void Init(MonsterSO data)
    {
        if (data == Data && IsInitialized)
        {
            Respawn();
            Debug.Log("RESPAWNED");
            return;
        }
        Data = data;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(1f, 0.3125f, 0f);
        GetComponent<SpriteRenderer>().color = Color.white;
        float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * 32;
        HPBar.gameObject.SetActive(true);
        HPBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height / 2 + 2);
        HPBar.maxValue = Data.MaxHP;
        HP = Data.MaxHP;
        StringBuilder sb = new("Animation/");
        sb.Append(data.Name);
        Animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(sb.ToString());
        State = StateEnum.IDLE;
        Animator.SetTrigger("Idle");
        IsInitialized = true;
    }
    public void Respawn()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        HPBar.gameObject.SetActive(true);
        transform.position = new Vector3(1f, 0.3125f, 0f);
        HPBar.maxValue = Data.MaxHP;
        HP = Data.MaxHP;
        State = StateEnum.IDLE;
        Animator.SetTrigger("Idle");
    }

    public void Hit(long damage)
    {
        if (State == StateEnum.DEAD)
            return;
        HP -= damage;
        if (HP > 0)
        {
            if (State != StateEnum.HIT)
                Animator.SetTrigger("Hit");
            State = StateEnum.HIT;
            return;
        }
        Dead();
    }

    public void Dead()
    {
        HPBar.gameObject.SetActive(false);
        var dir = Random.rotation.eulerAngles;
        m_Rigidbody2D.AddForce(dir);
        Animator.SetTrigger("Dead");
        State = StateEnum.DEAD;

        DeadEvent.Invoke(this);
    }
    public void OnAnimationFrameEnd()
    {
        if (State == StateEnum.DEAD)
        {
            gameObject.SetActive(false);
            DisableEvent.Invoke(this);
            return;
        }
        State = StateEnum.IDLE;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Border") && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            DisableEvent.Invoke(this);
            return;
        }
    }
}

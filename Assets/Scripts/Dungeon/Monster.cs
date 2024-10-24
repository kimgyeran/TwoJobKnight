using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public MonsterData Data;
    public float HP;
    public Animator Animator;
    public StateEnum State;

    public Slider HPBar;

    public UnityEvent DeadEvent;
    // Start is called before the first frame update
    void Start()
    {
        float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y * 32;
        HPBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height / 2 + 2);
        HPBar.maxValue = Data.MaxHP;
        HP = Data.MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = HP;
    }

    void Init(MonsterData data)
    {
        Data = data;
        float height = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        HPBar.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
    }

    public void OnHit()
    {
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
        State = StateEnum.DEAD;
        Animator.SetTrigger("Dead");
        
    }
    public void OnAnimationFrameEnd()
    {
        if(State == StateEnum.DEAD)
        {
            DeadEvent.Invoke();
            this.gameObject.SetActive(false);
            return;
        }
        State = StateEnum.IDLE;
    }
}

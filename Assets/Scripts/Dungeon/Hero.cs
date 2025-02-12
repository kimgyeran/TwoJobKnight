using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Animator))]
public class Hero : MonoBehaviour
{
    long m_AttackDamage = 10;
    public UnityEvent<long> AttackEvent;
    public long AttackDamage { get { return m_AttackDamage; } set { m_AttackDamage = value; StatusChange.Invoke(); } }

    public UnityEvent StatusChange;

    Animator m_HeroAnimator;
    private void Awake()
    {
        StatusChange = new();
    }

    private void Start()
    {
        m_HeroAnimator = GetComponent<Animator>();
    }
    public void Init()
    {

    }

    public void Attack()
    {
        m_HeroAnimator.SetTrigger("Attack");
    }

}

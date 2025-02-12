using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AlbaSystem : MonoBehaviour
{
    [Header("View")]
    public Button ClickZone;
    public Animator AlbaAnimator;
    public TextMeshProUGUI MoneyPerClickText;
    public TextMeshProUGUI MoneyPerSecText;

    [Header("Data"), SerializeField]
    private long moneyPerClick = 10;
    private long moneyPerSec = 50;
    public long MoneyPerClick
    {
        get { return moneyPerClick; }
        set { moneyPerClick = value; MoneyPerClickText.text = value.ToString(); }
    }
    public long MoneyPerSec
    {
        get { return moneyPerSec; }
        set { moneyPerSec = value; MoneyPerSecText.text = value.ToString(); }
    }
    
    private void Start()
    {
        GameManager.Instance.AlbaSystem = this;
        ClickZone.onClick.AddListener(OnClickHandler);
        StartCoroutine(AutoAlba());
    }
    public void OnClickHandler()
    {
        AlbaAnimator.SetTrigger("Work");
        GameManager.Instance.Money += MoneyPerClick;
    }
    #region Alba Animation

    #endregion
    IEnumerator AutoAlba()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1f);
            AlbaAnimator.SetTrigger("Work");

            GameManager.Instance.Money += MoneyPerSec;
        }

    }
    void SetAnimSpeed()
    {
        
    }
}

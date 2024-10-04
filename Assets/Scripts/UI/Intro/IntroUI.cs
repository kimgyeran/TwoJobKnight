using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour, IPointerClickHandler
{
    public GameObject Bgd;
    public GameObject Charecter;
    public GameObject Title;
    public GameObject Text;

    AsyncOperation ao;
    // Start is called before the first frame update
    void Start()
    {
        Charecter.GetComponent<RectTransform>().DOAnchorPosX(0f, 1f).SetEase(Ease.InExpo).SetAutoKill();



        Title.GetComponent<RectTransform>().DOAnchorPosY(-50f, 2f).SetEase(Ease.OutBounce).onComplete = () =>
        {
            StartCoroutine(blink());
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (ao != null)
        {
            Debug.Log(ao.progress);
            if (ao.progress >= 0.9f)
            {
                DOTween.KillAll(); StopCoroutine(blink());
                ao.allowSceneActivation = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ao != null)
            return;
        Debug.Log("Enter");
        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;
    }



    IEnumerator blink()
    {
        while (true)
        {
            Text.SetActive(!Text.activeSelf);
            yield return new WaitForSeconds(Text.activeSelf ? 1f : 0.5f);
        }
    }
}

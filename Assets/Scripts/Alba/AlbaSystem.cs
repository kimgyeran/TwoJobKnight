using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlbaSystem : MonoBehaviour
{
    long mps;
    long mpt;
    public long MPS { get { return mps; } set { mps = value; PropertyChangedEvent?.Invoke("MPS", value); } }
    public long MPT { get { return mpt; } set { mpt = value; PropertyChangedEvent?.Invoke("MPT", value); } }
    public UnityEvent<string, object> PropertyChangedEvent;
    // Start is called before the first frame update
    void Start()
    {
        initStatus();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDisable()
    {
        StopCoroutine(Timer());
    }
    public void IncreaseMoneyAtMPS()
    {
        GameManager.Instance.Money += mps;
    }

    public void IncreaseMoneyAtMPT()
    {
        GameManager.Instance.Money += mpt;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            IncreaseMoneyAtMPS();
            yield return new WaitForSeconds(1f);
        }
    }

    void initStatus()
    {
        MPS = 10;
        MPT = 10;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbaPresenter : MonoBehaviour
{
    public AlbaSystem AlbaSystem;
    public AlbaView AlbaView;
    // Start is called before the first frame update
    void Start()
    {
        if(AlbaSystem == null)
        AlbaSystem = GetComponent<AlbaSystem>();
        if(AlbaView == null)
        AlbaView = GetComponent<AlbaView>();

        AlbaSystem.PropertyChangedEvent.AddListener(AlbaView.UpdateUI);
        AlbaView.ViewActionEvent.AddListener(AlbaSystem.IncreaseMoneyAtMPT);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AlbaView : MonoBehaviour
{
    public GameObject AlbaBgd;
    public TextMeshProUGUI AlbaMPS;
    public TextMeshProUGUI AlbaMPT;
    public AlbaAnimationInterface AlbaAnimationInterface;
    public Animator AlbaAnimator;

    readonly string MPS_INDICATOR = "Money Per Sec : ";
    readonly string MPT_INDICATOR = "Money Per Touch : ";


    const float SPEED_HOLDING_TIME = 2f;
    float speed_holding_timer = 0;
    int click_count = 0;
    float speed = 1;
    float time = 0;
    bool is_playing = false;
    public UnityEvent ViewActionEvent;
    private void Awake()
    {
        ViewActionEvent = new UnityEvent();
    }
    // Start is called before the first frame update
    void Start()
    {
        AlbaBgd.GetComponent<ClickableObject>().OnClick.AddListener(OnClickListener);
        AlbaAnimationInterface.AnimationFrameEnd.AddListener(AnimationEndFrameEventHandler);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed_holding_timer <= 0)
        {
            click_count = 0;
            time = 0;
        }
        speed_holding_timer -= Time.deltaTime;
        time += Time.deltaTime;
        speed = 1 + click_count / time;

    }

    public void UpdateUI(string property, object value)
    {
        switch (property)
        {
            case "MPS":
                AlbaMPS.text = value as string;
                break;
            case "MPT":
                AlbaMPT.text = value as string;
                break;
        }
    }

    public void OnClickListener()
    {
        click_count++;
        speed_holding_timer = SPEED_HOLDING_TIME;
        ViewActionEvent.Invoke();
        if (is_playing)
            return;
        AlbaAnimator.SetFloat("Speed", speed);
        AlbaAnimator.SetTrigger("Make");
        is_playing = true;
    }
    public void AnimationEndFrameEventHandler()
    {
        is_playing = false;
    }

}

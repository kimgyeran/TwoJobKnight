using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlbaAnimationInterface : MonoBehaviour
{
    public UnityEvent AnimationFrameEnd;
    public void OnAnimationFrameEnd()
    {
        AnimationFrameEnd?.Invoke();
    }
}

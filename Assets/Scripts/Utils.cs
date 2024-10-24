using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils
{
    public static T FindComponentWithNullCheck<T>(this T go, string name) where T : Component
    {
        if(go == null)
        {
            return GameObject.Find(name).GetComponent<T>();
        }
        else
        {
            return go;
        }
    }
}

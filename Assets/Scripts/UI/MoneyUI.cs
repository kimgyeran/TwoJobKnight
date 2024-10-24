using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI money;
    // Start is called before the first frame update
    void Start()
    {
        money = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = GameManager.Instance.Money.ToString();
    }
}

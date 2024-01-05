using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverUI : MonoBehaviour
{
    public static HoverUI ins;

    public GameObject itemInfo;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI priceText;

}

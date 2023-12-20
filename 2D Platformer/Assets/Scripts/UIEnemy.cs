using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    [SerializeField] Image hpImage;

    public void UpdateHp(float hp)
    {
        if (hpImage)
        {
            hpImage.fillAmount = hp;
        }
    }
}

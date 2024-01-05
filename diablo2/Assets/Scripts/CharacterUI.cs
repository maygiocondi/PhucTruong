using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] Transform transparent;
    [SerializeField] GameObject characterUI;
    static public CharacterUI ins;

    public Image image;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI armorText;


    public CharacterSlot[] characterSlot;

    public int dame;
    public int amor;

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
        UpdateModifire();
    }

    private void Start()
    {
        PlayerStat.ins.onHpChangedCallback += UpdateUI;

        dame = PlayerStat.ins.damage.GetValue();
        amor = PlayerStat.ins.armor.GetValue();

        characterSlot = transparent.GetComponentsInChildren<CharacterSlot>();
        EquipmentManager.ins.onEquiptChanged += UpdateModifire;
    }


    public void UpdateUI()
    {
        if (image != null)
        {
            image.fillAmount = ((float)PlayerStat.ins.currentHealth/PlayerStat.ins.maxHelth.GetValue());
        }

        if(Input.GetButtonDown("CharacterUI"))
        {
            characterUI.SetActive(!characterUI.activeSelf);
        }
    }

    public void UpdateModifire()
    {
        for(int i = 0; i < characterSlot.Length; i++)
        {
            if (EquipmentManager.ins.currentEquipment[i] != null)
            {
                characterSlot[i].icon.sprite = EquipmentManager.ins.currentEquipment[i].icon;
                characterSlot[i].icon.enabled = true;
            }
            else
            {
                characterSlot[i].icon.enabled = false;
            }
        }

        damageText.text = dame.ToString();
        armorText.text = amor.ToString();

    }
}

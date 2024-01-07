using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public static NPC ins;

    [SerializeField] GameObject windowShopUI;
    public bool isSale;

    private void Awake()
    {
        windowShopUI.SetActive(false);
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

    private void Start()
    {
        radius = 2.5f;
    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
                isSale = true;
            }
            else
            {
                isSale = false;
            }
        }
    }

    public override void Interact()
    {
        Debug.Log("TT");
        base.Interact();
        windowShopUI.SetActive(true);
    }

    public void CloseWindowShop()
    {
        windowShopUI.SetActive(false);
    }
}

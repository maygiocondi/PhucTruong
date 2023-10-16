using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // em ko co
    static public UIManager ins;

    public Button pauseBtn;
    public Button resumeBtn;

    public Image fuelFilled;
    public Text textSpeeds;

    public Text textHp;

    private void Awake()
    {
        UIManager.ins = this;
    }

    private void Start()
    {
        pauseBtn.gameObject.SetActive(true);
        resumeBtn.gameObject.SetActive(false);
    }

    public void UpdateFilled(float rate)
    {
        if (fuelFilled)
        {
            fuelFilled.fillAmount = rate;
        }
    }

    public void UpdateSpeed(string content) 
    {
        textSpeeds.text = content;
    }  
    
    public void UpdateHp(string content) 
    {
        textHp.text = content;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseBtn.gameObject.SetActive(false);
        resumeBtn.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseBtn.gameObject.SetActive(true);
        resumeBtn.gameObject.SetActive(false);
    }
}

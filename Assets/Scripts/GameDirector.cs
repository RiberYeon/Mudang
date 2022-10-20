using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    public GameObject timeGuage;
    float maxTime = 120.0f;
    float timeLeft;

    void Start()
    {
        this.timeGuage = GameObject.Find("Time");
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft>0)
        {
            timeLeft -= Time.deltaTime;
            this.timeGuage.GetComponent<Image>().fillAmount = timeLeft / maxTime;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}

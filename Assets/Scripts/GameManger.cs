using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    
    public void Action(GameObject scanObj)
    {
        
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            int ran = Random.Range(0, 100);
            isAction = true;
            scanObject = scanObj;
            if(ran % 3 == 0)
            {
                talkText.text = "가천관으로 가주세요";
            }
            else if (ran % 3 == 1)
            {
                talkText.text = "Ai관으로 가주세요";
            }
            else if (ran % 3 == 2)
            {
                talkText.text = "법학관으로 가주세요";
            }
        }
        talkPanel.SetActive(isAction);
    }
}

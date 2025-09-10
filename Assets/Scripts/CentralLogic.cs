using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentralLogic : MonoBehaviour
{
    public string save_position = "Spawn Start";
    public int AdCount = 0;
    public int highscore = 0;
    public int buttonset = 0;
    public int scorevariable = 0;
    public int scoresaveforsavepoint = 0;
    public bool haveReward = false;
    public int completedContinue = 0;
    public GameObject count_text;

    public void pointCountUpdate()
    {
        count_text.GetComponent<Text>().text = scorevariable.ToString();
    }

    public void youHaveReward()
    {
        haveReward = true;
    }
}
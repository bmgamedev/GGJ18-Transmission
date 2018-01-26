using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount = 21;
    //private int dayCount = 1; //Not needed unless the map is big enough to require two days

    void Update()
    {
        UpdateTimerUI();
    }


    void newDay()
    {
        //if the game is large enough:
        /*
         *dayCount ++;
         *if (dayCount > 2) {
         *  SceneManager.LoadScene("Lose");
         * }
         * else
         * {
         *    //repeat the day once more
         * }
         */

        //else, just do it in one day:
        SceneManager.LoadScene("Lose");
    }


    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        timerText.text = hourCount.ToString("D2") + ":" + minuteCount.ToString("D2");
        if (secondsCount >= 1)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
        else if (hourCount >= 24)
        {
            hourCount = 0;
        }
        else if (hourCount >= 7 && hourCount < 21)
        {
            newDay();
        }
    }
}

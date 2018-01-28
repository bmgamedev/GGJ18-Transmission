using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNavScript : MonoBehaviour {

    public string newLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            TimerScript countdown = GetComponent<TimerScript>();
            if (countdown != null)
            {
                countdown.hourCount = 5;
            }
        }

        SceneManager.LoadScene(newLevel);
    }
}

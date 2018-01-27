using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private string LevelName;

    //[SerializeField]
    //Canvas messageCanvas;

    //public string ReqAnswer;
    //public GameObject barrier;
    //public GameObject player;

    void Start()
    {
        //messageCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.name == "Player")
        //{
        //    TurnOnMessage();
        //    CheckBarrier();
        //}
    }

    private void TurnOnMessage()
    {
        //messageCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.name == "Player")
        //{
        //    TurnOffMessage();
        //}
    }

    private void TurnOffMessage()
    {
        //messageCanvas.enabled = false;
    }

    private void CheckBarrier()
    {
        /*if ([USERINPUT] == ReqAnswer.ToString())
        {
            Destroy(barrier); //permanently remove barrier

            ////only remove barrier when holding the right note
            //Collider2D col = barrier.GetComponent<Collider2D>();
            //col.isTrigger = true;

        }*/

    }

    void LoadNewLevel(string LevelName)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("door " + gameObject.name);

            LevelName = gameObject.name;
            LoadNewLevel(LevelName);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [SerializeField]
    Canvas messageCanvas;
    public string DoorAccessReq;
    public AudioClip doorAudio;

    private string LevelName;
    private GameObject player;
    private bool isLocked;
    private PlayerScript playerAccess;
    private AudioSource source;

    void Start()
    {
        messageCanvas.enabled = true;
        isLocked = true;
        player = GameObject.FindGameObjectWithTag("Player");
        playerAccess = player.gameObject.GetComponent<PlayerScript>();

        source = GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");

        if (other.tag == "Player")
        {
            CheckBarrier();     
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }

    private void CheckBarrier()
    {
        if (DoorAccessReq == "doorOne")
        {
            if(playerAccess.doorOne == true)
            {
                source.PlayOneShot(doorAudio);
                TurnOffMessage();
                isLocked = false;
            }
        }
        else if (DoorAccessReq == "doorTwo")
        {
            if (playerAccess.doorTwo == true)
            {
                source.PlayOneShot(doorAudio);
                TurnOffMessage();
                isLocked = false;
            }
        }
        else if (DoorAccessReq == "doorThree")
        {
            if (playerAccess.doorThree == true)
            {
                TurnOffMessage();
                isLocked = false;
            }
        }
        //else if (DoorAccessReq == "doorFour")
        //{
        //    if (playerAccess.doorFour == true)
        //    {
        //        TurnOffMessage();
        //        isLocked = false;
        //    }
        //}
        //else if (DoorAccessReq == "doorFive")
        //{
        //    if (playerAccess.doorFive == true)
        //    {
        //        TurnOffMessage();
        //        isLocked = false;
        //    }
        //}

    }

    void LoadNewLevel(string LevelName)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isLocked)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
            }
        }
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LevelName = gameObject.name;
            LoadNewLevel(LevelName);
        }
    }


}

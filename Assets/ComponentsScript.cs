using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsScript : MonoBehaviour {

    public GameObject Player;
    public GameObject MainCamera;

    private GameObject curPlayer;
    private GameObject curTimer;

    void Start () {

        curPlayer = GameObject.Find("Player");
        curTimer = GameObject.Find("Main Camera");

        if (curPlayer == null)
        {
            Debug.Log("player not present");
            Instantiate(Player);
        }
        else { Debug.Log("player present"); }

        if(curTimer == null)
        {
            Debug.Log("timer not present");
            Instantiate(MainCamera);
        }
        else { Debug.Log("timer present"); }
    }
	
}

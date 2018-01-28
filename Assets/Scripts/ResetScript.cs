using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour {

    private GameObject curPlayer;
    private GameObject curTimer;

    void Awake () {

        curPlayer = GameObject.Find("Player");
        curTimer = GameObject.Find("Main Camera");

        if (curPlayer != null)
        {
            Destroy(curPlayer);
        }

        if (curTimer != null)
        {
            Destroy(curTimer);
        }

    }
	
}

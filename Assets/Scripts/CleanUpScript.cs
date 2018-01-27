using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpScript : MonoBehaviour {

    private GameObject player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if(player.activeSelf == true)
            {
                player.SetActive(false);
            }
            else
            {
                player.SetActive(true);
            }
            
        }
    }

}

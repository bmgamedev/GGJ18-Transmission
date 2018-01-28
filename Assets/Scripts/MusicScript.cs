using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {

    //public AudioClip intro;
    //public AudioClip main;

    static MusicScript instance = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //StartCoroutine(playMusic());
    }

    //IEnumerator playMusic()
    //{
    //    GetComponent<AudioSource>().clip = intro;
    //    GetComponent<AudioSource>().Play();
    //    yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
    //    GetComponent<AudioSource>().clip = main;
    //    GetComponent<AudioSource>().Play();
    //}
}

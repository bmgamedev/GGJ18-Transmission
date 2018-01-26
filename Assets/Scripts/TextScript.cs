using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {

    [SerializeField]
    string speech;

    private string str;

    void Start()
    {
        StartCoroutine(AnimateText(speech));
    }

    IEnumerator AnimateText(string strComplete)
    {
        int i = 0;
        str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            yield return new WaitForSeconds(0.5F);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 400, 1260, 225), str);
    }

    /*public AnimatedText() { }

    public void animateText(string strComplete)
    {
        int i = 0;
        string str = "";
        while (i < strComplete.Length)
        {
            str += strComplete[i++];
            new WaitForSeconds(0.5f);
        }
    }*/
}


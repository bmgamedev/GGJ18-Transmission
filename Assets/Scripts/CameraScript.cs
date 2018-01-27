using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float DampTime = 0.25f;
    public Transform target;

    static CameraScript instance = null;

    private Vector3 velocity = Vector3.zero;

	void Awake ()
    {
		if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
	}
	
	void Update ()
    {
		if (target.position.x != 0)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            //Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.3f, 0.2f, point.z));
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.3f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, DampTime);
        }
    }
}

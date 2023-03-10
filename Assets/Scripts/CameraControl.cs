using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject ball;
    Vector3 offset;
   public float lerprate;
   public bool gameover;

	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!gameover)
        {
            Follow();
        }
		
	}
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;
        pos =  Vector3.Lerp(pos, targetpos, lerprate * Time.deltaTime);
        transform.position = pos;

    }
}

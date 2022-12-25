using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour {
    [SerializeField]
    private float speed;
    bool started;
    bool gameover;
    public GameObject particle;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start () {

        started = false;
        gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameMangaer.instance.StartGame();
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
       if (!Physics.Raycast(transform.position, Vector3.down, 1f)){
            gameover = true;
            GameMangaer.instance.Gameover();
            rb.velocity =new  Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraControl>().gameover = true;
        }

                if (Input.GetMouseButtonDown(0)&& !gameover)
            {
                SwitchDirection();
            }
        
	}
    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if ( rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            Destroy(col.gameObject);

            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(part, 1f);
        }
    }
}

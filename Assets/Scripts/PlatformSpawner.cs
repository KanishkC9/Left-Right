using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject Platform;
    Vector3 lastpos;
    float size;
    public bool gameOver;
    public GameObject diamonds;
	// Use this for initialization
	void Start () {
        lastpos = Platform.transform.position;
        size = Platform.transform.localScale.x;
        for(int i =0; i<20; i++)
        {
            SpawnPlatform();
        }
      
	}
    void SpawnPlatform()
    {
      int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            spawnX();
        }
        else if ( rand > 3)
        {
            spawnz();
        }
       
    }
        public void startspawningplatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.5f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {

        if (gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }
    void spawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(Platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand<1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z), diamonds.transform.rotation);
        }
       
    }
    void spawnz()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds,new Vector3(pos.x,pos.y + 1,pos.z), diamonds.transform.rotation);
        }
    }
  
}

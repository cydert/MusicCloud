using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutEnemy : MonoBehaviour {
    public GameObject plane;
    public GameObject enemy;

    private bool play = false;
    private float spaceTiming = 4;
    private float length = 1000;    //敵の出現距離
    private float nowTiming = 0;
	// Use this for initialization
	void Start () {
        //putEnemy();
	}
	
	// Update is called once per frame
	void Update () {
        if (play)
        {
            nowTiming += Time.deltaTime; //タイムを加算
            if (nowTiming >= spaceTiming)
            {
                nowTiming = 0;
                  //指定時間になったので出現
            }
        }
	}

    void putEnemy()
    {
        Vector3 planeTr = plane.transform.position;
        Vector3 enemyPos = new Vector3(planeTr.x, planeTr.y, planeTr.z + length);
        Quaternion rote = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        Instantiate(enemy, enemyPos, rote);
        // plane.transform.position.z + length;
    }

    void Play()
    {
        play = true;

    }

    void Stop()
    {
        play = false;
    }
}

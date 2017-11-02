using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutEnemy : MonoBehaviour {
    public GameObject plane;
    public GameObject enemy;

    private bool play = false;
    private int maxEnemy = 5;
    private float spaceTiming = 5;  //敵が出現するまでの時間
    private float length = 1000;    //敵の出現距離
    private float nowTiming = 0;
    private float randomTime = 10;

    private GameObject[] enemyAr;
	// Use this for initialization
	void Start () {
        enemyAr = new GameObject[maxEnemy];
        play = true;
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
                putEnemy();

            }
        }
	}

    void putEnemy()
    {
        int enemyNum = 0;
        for(; enemyNum<enemyAr.Length; enemyNum++)
        {
            if (enemyAr[enemyNum] == null) break;
        }
        if (enemyNum == maxEnemy) return;   //既に最大出現数に

        Vector3 planeTr = plane.transform.position;
        Vector3 enemyPos = new Vector3(planeTr.x, planeTr.y, planeTr.z + length);
        Quaternion rote = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        enemyAr[enemyNum] = Instantiate(enemy, enemyPos, rote);
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

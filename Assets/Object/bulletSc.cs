using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSc : MonoBehaviour {
    private float interval = 2;   //指定時間
    private float time = 0;   //何秒立ったか
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime; //タイムを加算
        if (time >= interval)
        {
            Destroy(gameObject);  //指定時間になったので削除
        }
    }
}

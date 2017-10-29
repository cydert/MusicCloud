using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    bool isStart = false;   //動作中か
    bool isEnd = true;      //終了してるか
    float setSec;           //指定時間
    private float nowTime;

    public Timer() { }

    public Timer(float sec)
    {
        Start(sec);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        nowTime += Time.deltaTime; //タイムを加算
        if (nowTime >= setSec)
        {
            nowTime = 0;
            //指定時間
            final();    //後処理
        }
    }

    public bool Start(float sec)
    {
        if (isStart) return false;
        setSec = sec;
        init(); //初期化
        return true;
    }

    //指定時間になったか
    public bool IsEnd()
    {
        return isEnd;
    }

    //指定時間になったか
    public bool IsStart()
    {
        return isStart;
    }

    private void init()
    {
        nowTime = 0;
        isEnd = false;
        isStart = true;
    }

    private void final()
    {
        nowTime = 0;
        isEnd = true;
        isStart = false;
    }
}

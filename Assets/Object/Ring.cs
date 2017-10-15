using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Aeroplane;

public class Ring : MonoBehaviour {
    public GameObject airCraft;
    AeroplaneController planeInfo;
    Rigidbody rigid;
    bool init = false;

    float goalTime;

    // Use this for initialization
    void Start () {
        Init(8); //Debug用
        planeInfo = airCraft.GetComponent<AeroplaneController>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float length = this.transform.position.z - airCraft.transform.position.z; //2点のz距離
        float toTime = goalTime - Music.MusicalTime;    //指定時間までの時間
        
        if (length < 0)
            Destroy(this.gameObject);
        float ringSpeed = length / toTime - planeInfo.ForwardSpeed; //リングのスピードを計算
        if (toTime < 10)
            ringSpeed = 0;
        Debug.Log("L:"+length +" T:" + toTime+" FS:"+planeInfo.ForwardSpeed + " RS:"+ ringSpeed);

        rigid.velocity = new Vector3(0, 0, -ringSpeed);  //速度設定
    }

    //目的のBarを指定すると時間に変更, 動作開始１
    void Init(int goalBar)
    {
        init = true;
        goalTime = goalBar * Music.UnitPerBar;

        
    }
}

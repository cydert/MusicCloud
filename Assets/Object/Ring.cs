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

    public bool debugPrint;

    // Use this for initialization
    void Start () {
        airCraft = GameObject.Find("AircraftJet");
        planeInfo = airCraft.GetComponent<AeroplaneController>();
        rigid = GetComponent<Rigidbody>();

        //Init(8, 3, 0); //Debug用
        //Music.Play("Melt");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (init)
        {
            float length = this.transform.position.z - airCraft.transform.position.z; //2点のz距離
            float toTime = (goalTime - Music.MusicalTime)/10;    //指定時間までの時間
            length /= 1;
            if (length < 0)
                Destroy(this.gameObject);

            float ringSpeed = length / toTime;// - planeInfo.ForwardSpeed; //リングのスピードを計算
            if (toTime < 0 || ringSpeed < 0) ringSpeed = 0;

            if (debugPrint)
                Debug.Log("L:" + length + " T:" + toTime + " FS:" + planeInfo.ForwardSpeed + " RS:" + ringSpeed+ "PUT;"+ (-ringSpeed + planeInfo.ForwardSpeed) * Time.deltaTime);

            transform.position += new Vector3(0, 0, (-ringSpeed+planeInfo.ForwardSpeed)*Time.deltaTime);
            //rigid.velocity = new Vector3(0, 0, -ringSpeed);  //速度設定
             //rigid.AddForce(new Vector3(0, 0, ringSpeed), ForceMode.Force);
        }
        
    }

    // num: 0 ~ 30
    public void Init(int goalBar, int numX, int numY)
    {
        if (numX < 0) numX = 0;
        else if (numX > 30) numX = 30;
        if (numY < 0) numY = 0;
        else if (numY > 30) numY = 30;
        numX *= 10;
        numX -= 150;
        numY *= 10;
        numY -= 12;
        Init(goalBar, (float)numX, (float)numY);
    }
    //目的のBarを指定すると時間に変更, 動作開始
    void Init(int goalBar, float x, float y)
    {
        init = true;
        goalTime = goalBar * Music.UnitPerBar;
        transform.position = new Vector3(x, y, transform.position.z);
        //x: -150 .. 150
        //y: -12 .. 238
    }
}

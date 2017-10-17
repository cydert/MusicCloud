using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRing : MonoBehaviour {

    string[] rhythmText;  //タイミング, 座標
    public GameObject ring; //インスタンス化
    public GameObject ringPosition;
    private int cnt = 0;    //現在出力したリング数
    private int nextTiming = -1;
    int barSpace = 8; //何bar前からリングを出す

	// Use this for initialization
	void Start () {
        //Debug
        startMusic(MUSIC.Melt);

	}
	
	// Update is called once per frame
	void Update () {
        if(nextTiming != -1 && rhythmText != null)
        {
            if(nextTiming - Music.MusicalTimeBar <= barSpace)
            {
                Debug.Log("put:"+Music.MusicalTimeBar);
                put();
            }
        }


    }

    private void put()
    {
        string[] infoAr = rhythmText[cnt].Split(',');   //分割
        GameObject newRing = Instantiate(ring, ringPosition.transform.position, Quaternion.identity);   //インスタンス化
        Ring ringCom = newRing.GetComponent<Ring>();
        ringCom.Init(int.Parse(infoAr[0]), int.Parse(infoAr[1]), int.Parse(infoAr[2])); //座標セット
        cnt++;
        if (rhythmText.Length > cnt)    //次のリング
        {
            Debug.Log("nx");
            nextTiming = int.Parse(rhythmText[cnt].Split(',')[0]);
        }
        else
            nextTiming = -1;
    }

    enum MUSIC
    {
        Melt, FlightSound
    }

    //指定した音楽でスタート
    void startMusic(MUSIC musicKind)
    {
        switch (musicKind)
        {
            case MUSIC.Melt:
                Music.Play("Melt");
                rhythmText = new string[] { "5,0,0", "20,1,0", "50,5,1" };
                nextTiming = int.Parse(rhythmText[cnt].Split(',')[0]);
                //TODO readFile
                break;
            case MUSIC.FlightSound:
                Music.Play("FlightSound");
                rhythmText = new string[] { "5,0,0", "20,1,0", "50,1,1" };
                nextTiming = int.Parse(rhythmText[cnt].Split(',')[0]);
                break;
        }

    }
}

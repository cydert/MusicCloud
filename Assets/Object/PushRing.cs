using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRing : MonoBehaviour
{

    string[] rhythmText;  //タイミング, 座標
    public GameObject ring; //インスタンス化
    public GameObject ringPosition;
    private PushRingPosition pushRingScript;
    private int cnt = 0;    //現在出力したリング数
    private int nextTiming = -1;
    int barSpace = 3; //何bar前からリングを出す

    // Use this for initialization
    void Start()
    {
        //Debug
        pushRingScript = ringPosition.GetComponent<PushRingPosition>();

        startMusic(MusicInfo.musicName, MusicInfo.level);
        switch (MusicInfo.level)
        {
            case 1:
                planeInfoGui.hp = 30;
                break;
            case 2:
                planeInfoGui.hp = 20;
                break;
            case 3:
                planeInfoGui.hp = 10;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //指定したタイミングになったらリング出力
        if (nextTiming != -1 && rhythmText != null)
        {
            if (nextTiming - Music.MusicalTimeBar <= barSpace)
            {
                put();
            }
        }


    }

    private void put()
    {
        string[] infoAr = rhythmText[cnt].Split(',');   //分割(次のタイミング,座標)
        Quaternion rote = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
        GameObject newRing = Instantiate(ring, ringPosition.transform.position, rote);   //インスタンス化
        Ring ringCom = newRing.GetComponent<Ring>();    //Ringのスクリプト
        ringCom.Init(int.Parse(infoAr[0]), int.Parse(infoAr[1]), int.Parse(infoAr[2])); //座標セット(移動開始)
        cnt++;
        if (rhythmText.Length > cnt)    //次のリング
        {
            nextTiming = int.Parse(rhythmText[cnt].Split(',')[0]);
        }
        else
            nextTiming = -1;
    }

    public enum MUSIC
    {
        Melt, FlightSound
    }

    //指定した音楽でスタート
    public void startMusic(MUSIC musicKind, int numLebel)
    {
        Music.Play(musicKind.ToString());
        rhythmText = ReadFile.readFile("MusicTempo/" + musicKind.ToString() + numLebel + ".txt");    //タイミング取得
        nextTiming = int.Parse(rhythmText[cnt].Split(',')[0]);  //初回タイミング

        pushRingScript.ResetPosition(); //出現場所のリセット
        switch (musicKind)
        {
            case MUSIC.Melt:
                barSpace = 3;
                break;
            case MUSIC.FlightSound:
                barSpace = 2;
                pushRingScript.SetLength(1500);
                break;
        }

    }
}

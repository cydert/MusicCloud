using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!Directory.Exists("MusicTempo"))
            Directory.CreateDirectory("MusicTempo");
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //指定したファイル内容を行ごとに分けて返す
    //コメントも無視
    public static string[] readFile(string fileName)
    {
        if (!Directory.Exists("MusicTempo"))
            Directory.CreateDirectory("MusicTempo");

        ArrayList dataAr = new ArrayList();
        // ファイルからテキストを読み出し。
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null) // 1行ずつ読み出し。
            {
                if (!(line.Equals("") || line.Equals("//")))
                    dataAr.Add(line);   //1行追加
            }
        }
        return (string[])dataAr.ToArray(typeof(string));
    }
}

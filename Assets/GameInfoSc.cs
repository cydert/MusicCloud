using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoSc : MonoBehaviour {
    public static int score=0;

    private const int ADD_RING_SCORE = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void AddRingScore()
    {
        score += ADD_RING_SCORE;
    }

    public static void Reset()
    {
        score = 0;
    }
}

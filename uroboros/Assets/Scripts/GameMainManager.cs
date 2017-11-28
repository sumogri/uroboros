using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public enum GameState
{
    playing,
    clear,
}

public class GameMainManager : SingletonMonoBehaviour<GameMainManager>,IReset {
    [SerializeField] private List<GameObject> resetableObjs;
    private Stopwatch stopwatch;
    private GameState nowState = GameState.playing;

	// Use this for initialization
	void Start () {
        stopwatch = new Stopwatch();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.playing:
                foreach (var obj in resetableObjs)
                    obj.GetComponent<IReset>()?.Reset();
                    
                break;
            case GameState.clear:
                break;
        }
        nowState = state;
    }

    public void Reset()
    {
        stopwatch.Reset();
    }
}

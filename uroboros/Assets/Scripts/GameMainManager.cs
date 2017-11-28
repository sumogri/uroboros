using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    playing,
    clear,
}

public class GameMainManager : SingletonMonoBehaviour<GameMainManager>,IReset {
    [SerializeField] private List<GameObject> resetableObjs;
    [SerializeField] private ResultController result;
    public Stopwatch Stopwatch { get; } = new Stopwatch();
    private GameState nowState = GameState.playing;
    public GameState NowState => nowState;
    private float maxDamage = 0;
    public float MaxDamage => maxDamage;

	// Use this for initialization
	void Start () {
        Stopwatch.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState(GameState state)
    {
        if (state == nowState) return;

        switch (state)
        {
            case GameState.playing:
                foreach (var obj in resetableObjs)
                    obj.GetComponent<IReset>()?.DoReset();
               DoReset();

                break;
            case GameState.clear:
                Stopwatch.Stop();
                result.Init();
                break;
        }
        nowState = state;
    }

    public void DoReset()
    {
        Stopwatch.Restart();
        maxDamage = 0;
    }

    /// <summary>
    /// リザルトに渡すデータを更新
    /// 攻撃を食らった敵が更新かける(あんまよくない)
    /// </summary>
    public void DamageUpdate(float damage)
    {
        maxDamage = Math.Max(damage,maxDamage);
    }
}

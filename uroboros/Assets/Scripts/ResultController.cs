using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {
    private Text resultText;

	// Use this for initialization
	void Awake () {
        resultText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        gameObject.SetActive(true);

        var min = GameMainManager.I.Stopwatch.Elapsed.Minutes;
        var sec = GameMainManager.I.Stopwatch.Elapsed.Seconds;
        var maxd = GameMainManager.I.MaxDamage;

        resultText.text = $"<b>ゲームクリア！</b>\nタイム {min:00}:{sec:00}\n最大ダメージ {maxd}";
    }

    public void OnButtonDown()
    {
        GameMainManager.I.ChangeState(GameState.playing);
        gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 錬金術ロジック
/// </summary>
public class AlchemyManager : SingletonMonoBehaviour<AlchemyManager> {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 錬成素材から、錬成結果を返すスクリプト
    /// </summary>
    /// <param name="elements">素材</param>
    /// <returns>錬成結果</returns>
    public List<String> Alchemy(List<String> elements)
    {
        List<String> alchemys = new List<String>();

        //簡単のため、すべて剣を返す
        for(int i = 0; i < elements.Count; i++)
        {
            alchemys.Add("sword");
        }
        
        return alchemys;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 錬金術ロジック
/// </summary>
public class AlchemyManager : SingletonMonoBehaviour<AlchemyManager> {
    private Dictionary<string, GameObject> weaponDic;
    public Dictionary<string, GameObject> WeaponDictionary => weaponDic;
    
    //錬成式 素材群,錬成結果の組
    private string[][][] alchemyEquation = { 
        new string[][]{ new[] { "fire", "wind" },new[]{ "bomb" } },
        new string[][]{ new[] { "water", "sand" },new[] { "hammer" } },
        new string[][]{ new[] { "sand", "fire" },new[] { "sword" } },
        new string[][]{ new[] { "water", "wind" },new[] { "katana" } },

        new string[][]{ new[] { "bomb", "wind" },new[] { "megaBomb" } },
        new string[][]{ new[] { "sword", "fire" },new[] { "fireSword" } },
        new string[][]{ new[] { "katana", "water" },new[] { "waterKatana" } },
        new string[][]{ new[] { "hammer", "sand" },new[] { "bigHammer" } },
    };

	// Use this for initialization
	void Start () {
        var weapons = Resources.LoadAll<GameObject>("Weapons");
        weaponDic = new Dictionary<string, GameObject>();
        foreach (var w in weapons)
            weaponDic.Add(w.name,w);
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

        foreach (var el in alchemyEquation)
        {
            var ex = el[0].Except(elements);
            if (ex.Count() == 0)
                alchemys.Add(el[1][0]);
        }
        
        return alchemys;
    }
}

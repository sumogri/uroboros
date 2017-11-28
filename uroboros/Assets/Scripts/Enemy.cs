using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour,IDropHandler,IHPBehaviour,IReset{
    [SerializeField] private float maxHp;
    private float hp;
    public float HP => hp;

    void Awake () {
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        Attackable atk = eventData.pointerDrag?.GetComponent<Attackable>();
        if ( atk == null) return;
        
        //ダメージくらう
        hp = Math.Max(0, hp - atk.Attack);
        GameMainManager.I.DamageUpdate(atk.Attack);
        if (hp == 0) GameMainManager.I.ChangeState(GameState.clear);

        if (eventData.pointerDrag != null)
        {
            Destroy(eventData.pointerDrag, 0.1f);
        }
    }

    public float getHp()
    {
        return HP;
    }
    public float getMaxHp()
    {
        return maxHp;
    }

    public void DoReset()
    {
        hp = maxHp;
    }
}

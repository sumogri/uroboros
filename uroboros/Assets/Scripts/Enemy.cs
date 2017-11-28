using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour,IDropHandler,IHPBehaviour{
    [SerializeField] private float maxHp;
    
    public float HP { get; set; }

    void Awake () {
        HP = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        Attackable atk = eventData.pointerDrag?.GetComponent<Attackable>();
        if ( atk == null) return;

        HP -= atk.Attack;
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
}

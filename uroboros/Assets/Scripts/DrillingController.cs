using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrillingController : MonoBehaviour,IDropHandler,IReset {
    private List<String> elementList;
    private Transform elementsRoot;
    private DrillingEffects effect;

    // Use this for initialization
    void Start () {
        elementList = new List<String>();
        elementsRoot = transform.parent.Find("Elements");
        effect = gameObject.GetComponentInChildren<DrillingEffects>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            elementList.Add(eventData.pointerDrag.name);
            effect.StartEffect(eventData.pointerDrag.name);
            Destroy(eventData.pointerDrag, 0.1f);

            var alchemyItems = AlchemyManager.I.Alchemy(elementList);
            if (alchemyItems.Count == 0) return;

            elementList.Clear();
            effect.DoReset();
            foreach (var i in alchemyItems)
                Instantiate(AlchemyManager.I.WeaponDictionary[i],elementsRoot).name = i;
        }
    }

    public void ButtonOnClick()
    {

    }

    public void DoReset()
    {
        elementList.Clear();
    }
}

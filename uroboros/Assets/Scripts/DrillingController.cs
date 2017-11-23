using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrillingController : MonoBehaviour,IDropHandler {
    private List<String> elementList;

    // Use this for initialization
    void Start () {
        elementList = new List<String>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop" + eventData.pointerDrag);

        if (eventData.pointerDrag != null)
        {
            elementList.Add(eventData.pointerDrag.name);
            Destroy(eventData.pointerDrag,0.1f);
        }
    }

    public void ButtonOnClick()
    {
        var alchemyItems = AlchemyManager.I.Alchemy(elementList);
        elementList.Clear();
        Debug.Log(alchemyItems);
    }
}

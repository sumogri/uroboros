﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <summary>
/// 素材パネルのコントローラー
/// </summary>
public class ElementlController : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    [SerializeField] private float attack = 1;
    private Vector3 mouseDiff;
    private CanvasGroup myGroup;

    // Use this for initialization
    void Start()
    {
        myGroup = transform.parent.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + mouseDiff;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        myGroup.blocksRaycasts = true;
        Debug.Log("hoge");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseDiff = transform.position - Input.mousePosition;
        transform.SetAsLastSibling();
        Instantiate(gameObject, transform.parent);
        myGroup.blocksRaycasts = false;
    }
}
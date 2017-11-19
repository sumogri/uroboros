using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// 素材パネルのコントローラー
/// </summary>
public class PanelController : MonoBehaviour
{
    private Vector3 mouseDiff;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDown()
    {
        mouseDiff = transform.position - Input.mousePosition;
        transform.SetAsLastSibling();
    }

    public void OnDrag()
    {
        transform.position = Input.mousePosition + mouseDiff;
        
    }

    public void OnDrop()
    {
    }
}

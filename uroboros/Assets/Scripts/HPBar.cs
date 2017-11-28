using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {
    [SerializeField] private GameObject hpBehaviourObj;
    private IHPBehaviour hpBehaviour;
    private Slider mySlider;
    private Text myText;

	// Use this for initialization
	void Start () {
        hpBehaviour = hpBehaviourObj.GetComponent<IHPBehaviour>();
        mySlider = GetComponent<Slider>();
        myText = GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        mySlider.value = hpBehaviour.getHp() / hpBehaviour.getMaxHp();
        myText.text = ((int)hpBehaviour.getHp()).ToString();
	}
}

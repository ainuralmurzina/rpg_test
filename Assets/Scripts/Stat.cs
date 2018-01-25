using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour {

	private int currentValue;
	public int CurrentValue {
		get { return currentValue; }
		set { 
			currentValue = Mathf.Clamp (value, 0, 100);
			SetValue ();
		}
	}

	private const int _MinValue = 0;
	private const int _MaxValue = 100;

	private Slider stat;
	private Text statValue;

	void Start(){
		stat = GetComponent<Slider> ();
		statValue = GetComponentInChildren<Text> ();
		Initialize ();
	}

	public void Initialize(){
		currentValue = _MaxValue;
		stat.value = currentValue;
	}

	void SetValue(){
		stat.value = currentValue;
		statValue.text = currentValue.ToString() + "%";
	}
}

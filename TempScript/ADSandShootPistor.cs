#pragma warning disable
using UnityEngine;
using System.Collections.Generic;

public class ADSandShootPistor : MonoBehaviour {

	public void Start() {}

	public void Update() {
		ADS();
	}

	public void ADS() {
		if(Input.GetMouseButtonDown(1)) {
			Debug.Log("Button Down");
		}
		if(Input.GetMouseButtonUp(1)) {
			Debug.Log("Button Up");
		}
	}
}

using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class AdScript : MonoBehaviour {

	public Material adMaterial;
	public Material hiddenAdMaterial;
	//public ImageTargetTrackableEventHandler glasses;
	public bool glassesOnState;
	SerialPort stream = new SerialPort("/dev/cu.usbmodem1421", 9600);
	public string sensorData;
	bool oldGlassesOnState;

	// Use this for initialization
	void Start () {
		sensorData = "0";
		stream.Open ();
		stream.ReadTimeout = 1;
		glassesOnState = false;
	}
	
	// Update is called once per frame
	void Update () {


		oldGlassesOnState = glassesOnState;

		if (stream.IsOpen) {
			try {
				sensorData = stream.ReadExisting();
			} catch (System.Exception) {
				
			}
		}

		glassesOnState = areGlassesOn (sensorData);

		bool shouldSeeHiddenAdMaterial = Input.GetKey (KeyCode.F) || glassesOnState;

		if (shouldSeeHiddenAdMaterial) {
			this.GetComponent<Renderer>().material = hiddenAdMaterial;
		}
		else {
			this.GetComponent<Renderer>().material = adMaterial;
		}


	}

	bool areGlassesOn(string sensorValueFromGlasses){
		if (sensorValueFromGlasses.Contains ("1")) {
			return true;
		} else if (sensorValueFromGlasses.Contains ("0")) {
			return false;
		} else {
			//return whatever the boolean of the old glasses state is
			return oldGlassesOnState;
		}
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour {
    public Text Location;
    public qrCam cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        try
        {
            Location.text = "Your Location: "+cam.qr;
        }
        catch (System.Exception e)
        { 
        
        
        }
	}
}

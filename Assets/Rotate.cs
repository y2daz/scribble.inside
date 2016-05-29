using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public int speed=10;
    public bool go;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
        if(go==true)
        { Rotation(true); }
	}

    public void Rotation(bool right)
    {
        if (right == true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
        }
        else if (right == false)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -speed, Space.World);
        }
    }
}

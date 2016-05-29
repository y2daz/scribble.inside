using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingLogo : MonoBehaviour {
    public Image cooldown;
	public bool coolingDown;
	public float waitTime = 30.0f;
    public bool done = false;
	// Update is called once per frame
	void Update () 
	{
        
		if (coolingDown == true)
		{
			//Reduce fill amount over 30 seconds
			cooldown.fillAmount -= 1.0f/waitTime * Time.deltaTime;

		}
        if (coolingDown == false)
        {
            //Reduce fill amount over 30 seconds
           
            cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;

            
        }

        if( cooldown.fillAmount==1)
        {
            cooldown.fillOrigin = 1;
            coolingDown = true;
        }

        if (cooldown.fillAmount<= 0)
        {
            done =  true;
            Debug.Log("Done");
            this.enabled = false;
        }
	}
}


using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PopulateOptions : MonoBehaviour {

    bool populated = false;
    List<string> data = new List<string>();
    public List<GameObject> locations = new List<GameObject>();

    string[] shops;

    Dropdown dd;
    int i = 0;

    public Navigation Nav;
	// Use this for initialization
	void Start () {
        dd = GetComponent<Dropdown>();


        shops = new string[3] { "Shoe Shop", "The Other Shoe Shop", "ClothesRUs"};
        Populate();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Populate()
    {
        //if (!populated)
        //{
               
        //    for (int i = 0; i < locs.Length; i++)
        //    {
        //        Debug.Log(i);
        //        if (locs[i].type == "Tag")
        //        {

        //            data.Add(locs[i].name);
        //        }
        //    }
        //    dd.AddOptions(data);
        //    populated = true;
        //}

        //List<string> lst = new List<string>();
        
        //for (int i = 0; i < shops.Length; i++)
        //{
        //    lst.Add(shops[ i]);
        //    Debug.Log(shops[ i]);
        //}

    }

    public void changeItem(int value)
    {
        if (value == 1)
        {
            locations[0].SetActive(true);
            locations[1].SetActive(false);
            locations[2].SetActive(false);
        }
        else if (value == 2)
        {
            locations[0].SetActive(false);
            locations[1].SetActive(true);
            locations[2].SetActive(false);

        }
        else if (value == 3)
        {
            locations[0].SetActive(false);
            locations[1].SetActive(false);
            locations[2].SetActive(true);

        }
    }

}

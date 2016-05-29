using UnityEngine;
using System.Collections;
using JSON;
using UnityEngine.UI;

[System.Serializable]
public class Location
{
    [JSONItem("locationid", typeof(string))]
    public string locationid = "";
    [JSONItem("modelid", typeof(int))]
    public int modelid = 0;
    [JSONItem("precedinglocation", typeof(string))]
    public string preceding = "";
    [JSONItem("name", typeof(string))]
    public string name = "";
    [JSONItem("type", typeof(string))]
    public string type = "";
    [JSONItem("description", typeof(string))]
    public string description = "";
    [JSONItem("tags", typeof(string))]
    public string tags = "";
    [JSONItem("positionx", typeof(double))]
    public double positionx = 0;
    [JSONItem("positiony", typeof(double))]
    public double positiony = 0;
    [JSONItem("positionz", typeof(double))]
    public double positionz = 0;
    [JSONItem("rotationx", typeof(double))]
    public double rotationx = 0;
    [JSONItem("rotationy", typeof(double))]
    public double rotationy = 0;
    [JSONItem("rotationz", typeof(double))]
    public double rotationz = 0;
    [JSONItem("scalex", typeof(double))]
    public double scalex = 0;
    [JSONItem("scaley", typeof(double))]
    public double scaley = 0;
    [JSONItem("scalez", typeof(double))]
    public double scalez = 0;
}


public class WebHandler : MonoBehaviour {

    private string url;
    private string code;
    public Location[] locs;
    public PopulateOptions popOpt;


	// Use this for initialization
	void Start () {
        url = "localhost:8080/";
        popOpt = GameObject.Find("Dropdown").GetComponent<PopulateOptions>();
	}

    void Awake(){
        url = "172.22.111.129:8080/";
        getLocation("iskdju4585wid71s");
    }

    public void getLocation(string QRcode)
    {
        code = QRcode;
        StartCoroutine(getLocationFromWeb());
        //WWW www = new WWW(url + "models/" + code + ".obj"); //Model
    }

    IEnumerator getLocationFromWeb()
    {
        string totalUrl = url + "?tag=" + code + "&app=y";
        Debug.Log(totalUrl);
        WWW www = new WWW(totalUrl); //Data
        yield return www;
        Debug.Log(www.text);

        locs = (Location[])JSONSerialize.Deserialize(typeof(Location), www.text);
        Debug.Log(locs.ToString() );        
        //popOpt.Populate(locs);
    }


	// Update is called once per frame
	void Update () {
	
	}
}

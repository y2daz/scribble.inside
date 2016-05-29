using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        QualitySettings.SetQualityLevel(3, true);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevel == 0)
            {
                Application.Quit();

            }
            else
            {
                Application.LoadLevel(Application.loadedLevel - 1);
            }

        }

    }

    void OnGUI()
    {
        //string[] names = QualitySettings.names;
        //GUILayout.BeginVertical();
        //int i = 0;
        //while (i < names.Length)
        //{
        //    if (GUILayout.Button(names[i]))
        //        QualitySettings.SetQualityLevel(i, true);

        //    i++;
        //}
        //GUILayout.EndVertical();
    }
}

using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

    public Vector3 start;
    private NavMeshPath path;
    private LineRenderer line;
    private Transform target;
    private NavMeshAgent Agent;
    public GameObject Marker;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        Agent = GetComponent<NavMeshAgent>();
       // target = GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void navigate(string location)
    {
        Vector3 s1 = new Vector3(-38.3f, 13.4f, -17.1f);
        Vector3 s2 = new Vector3(8.9f, 13.4f, -32.3f);
        Vector3 s3 = new Vector3(-19.1f, 13.4f, -52.9f);

        if (location == "s1")
        {
           

                Marker.SetActive(true);
                Marker.transform.position = s1;
        }
        if (location =="s2")
        {
            //NavMesh.CalculatePath(start, s2, NavMesh.AllAreas, path);
            //target.position = s2;
            //StartCoroutine(getPath());

            Marker.SetActive(true);
            Marker.transform.position = s2;
        }
        if (location == "s3")
        {
            //NavMesh.CalculatePath(start, s3, NavMesh.AllAreas, path);
            //target.position = s3;
            //StartCoroutine(getPath());

            Marker.SetActive(true);
            Marker.transform.position = s3;
        }

    
    }

    IEnumerator getPath()
    {
        line.SetPosition(0, transform.position);
        Agent.SetDestination(target.position);
        yield return new WaitForEndOfFrame();
        DrawPath(Agent.path);
       Agent.Stop();

    }

    void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
        {
            return;
        }

        line.SetVertexCount(path.corners.Length);
        for (int i = 1; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);

        }
    }

}

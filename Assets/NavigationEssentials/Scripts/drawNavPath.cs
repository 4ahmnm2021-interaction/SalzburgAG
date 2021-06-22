using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class drawNavPath : MonoBehaviour
{
    public Transform player;
    public Transform[] destination;

    public Text distanceText;

    public int destionIndex = 0;
    public NavMeshPath path;
    private LineRenderer floorLine;

    [SerializeField]
    private LineRenderer verticalLine;
    private Vector3 smoothCorner;
  
    [Header("LineParameters")]
    [SerializeField]
    public bool smoothLine = true;
    public float smoothDistance = 2;

    [SerializeField]
    Color color1 = Color.green;
    [SerializeField]
    Color color2 = Color.red;
    public float lineWidth = 1;

    public GameObject checkpoint;

    public float waypointDistance = 1; 
    int numberofCorners;
    bool corrutineIsRunning; 

    //public WayPointer wayPointer;
    public static drawNavPath instance;
    public List<GameObject> checkpoints = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        path = new NavMeshPath();

        //wayPointer = gameObject.transform.GetComponent<WayPointer>(); 

        //checkpoint = Resources.Load<GameObject>("CheckpointObject");
       

        floorLine = transform.GetComponent<LineRenderer>();
        floorLine.SetWidth(lineWidth, lineWidth);
        verticalLine.positionCount = 2;
        verticalLine.endWidth = lineWidth;
        SetGradient();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
        NavMesh.CalculatePath(destination[destionIndex].position, pos, NavMesh.AllAreas, path);
      

        DrawVerticalLine();
        DrawFloorLine();

        DisplayDistance();

        SetCheckpoints();
    }
    void DrawFloorLine()
    {
        if (smoothLine)
        {
            floorLine.positionCount = path.corners.Length;
            var corners = path.corners;
            corners[0] = smoothCorner;
            floorLine.SetPositions(path.corners);
            floorLine.enabled = true;
        }
        else
        {
            floorLine.positionCount = path.corners.Length;
            floorLine.SetPositions(path.corners);
            floorLine.enabled = true;
        }

    }
    void DrawVerticalLine()
    {
        if (smoothLine)
        {
            var corners = new Vector3[2];
            corners[1] = calculateSlope(path.corners[1], path.corners[0], smoothDistance);
            corners[0] = destination[destionIndex].position;
            verticalLine.SetPositions(corners);
        }
        else
        {
            var corners = new Vector3[2];
            corners[1] = path.corners[0];
            corners[0] = destination[destionIndex].position;
            verticalLine.SetPositions(corners);
        }
    }

    Vector3 calculateSlope(Vector3 corner1, Vector3 corner2, float distance)
    {

        float distanceX = corner2.x - corner1.x;
        float distanceY = corner2.z - corner1.z;

        float hypotenuse = Mathf.Sqrt(distanceX * distanceX + distanceY * distanceY); //thats just pythagoras don't worry 
        float relation = hypotenuse / distance;

        float X = corner2.x - (distanceX / relation);
        float Z = corner2.z - (distanceY / relation);

        Vector3 newCorner = new Vector3(X, corner2.y, Z);
        smoothCorner = newCorner;
        return (newCorner);
    }

    void SetGradient()
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color2, 0.0f), new GradientColorKey(color1, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(color2.a, 1.0f), new GradientAlphaKey(color1.a, 1.0f) }
            );
        verticalLine.colorGradient = gradient;
    }
    public void NextTarget()
    {
        if (destionIndex < destination.Length)
            destionIndex++;
        else
            destionIndex = 0;
    }
    void DisplayDistance()
    {
        distanceText.text = (GetPathLength(path).ToString("F1") + "m");
    }


    public static float GetPathLength(NavMeshPath path)
    {
        float lng = 0f;

        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            for (int i = 1; i < path.corners.Length; ++i)
            {
                lng += Vector3.Distance(path.corners[i - 1], path.corners[i]);
            }
        }

        return lng;
    }

    void SetCheckpoints()
    {
        if (path.corners.Length == numberofCorners)
        {
            return;
        }
            
        else
        {   
            foreach (GameObject checkpoint in checkpoints)
                Destroy(checkpoint);
            int i = 0;
            foreach (Vector3 corner in path.corners)
            {
                if (i == path.corners.Length-1)
                {
                    GameObject currentCheckpoint = Instantiate(checkpoint);
                    currentCheckpoint.GetComponent<PositionWaypoint>().id = i;
                    checkpoints.Add(currentCheckpoint);
                    
                }
                else
                {
                    if (waypointDistance < Vector3.Distance(corner, path.corners[i + 1]))
                    {
                        GameObject currentCheckpoint = Instantiate(checkpoint);
                        currentCheckpoint.GetComponent<PositionWaypoint>().id = i;
                        checkpoints.Add(currentCheckpoint);

                    }
                }
                        
             
                i++;
            }
            numberofCorners = path.corners.Length;
        }
    }

   /* IEnumerator PositionWaypoint()
    {
        while (true)
        {
            corrutineIsRunning = true;  
            int i = 0; 
            foreach (GameObject checkpoint in checkpoints)
            {

                checkpoint.transform.position = path.corners[i];
                i++;
                yield return null;
                corrutineIsRunning = false; 

            }
          
        }
    }*/
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesManagerController : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints = new Transform[12];

    public Transform[] Waypoints { get { return waypoints; } set { waypoints = value; } }

    static PlacesManagerController _instance;
    public static PlacesManagerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(PlacesManagerController)) as PlacesManagerController;
            }
            return _instance;
        }
        set { _instance = value; }
    }
    // Start is called before the first frame update
   void Awake()
    {
        Instance = this;      
    }
}

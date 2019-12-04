using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacesManagerController : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints = new Transform[12];

    public Transform[] Waypoints { get { return waypoints; } set { waypoints = value; } }

    public Text building1Text;


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
    
    void Start()
    {
        int num =  10;
        building1Text.text = "HOLIS MEEP "+num;
    }
   void Awake()
    {
        Instance = this;      
    }
}

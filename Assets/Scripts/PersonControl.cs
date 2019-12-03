using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonControl : MonoBehaviour
{
 
    static double[,] transitionMatrix = new double[,] { 
            {0, 0.06, 0, 0, 0, 0, 0, 0, 0, 0.28, 0, 0.66}, // 0 = Biblioteca
            {.14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, .86},   // 1 = Wellness center
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, // 2 = Flor de Córdoba
            {0, 0, 0.12, 0, 0.1, 0.13, 0, 0, 0, 0, 0, 0.65}, // 3 = Wok
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, // 4 = Yum Yum
            {0, 0, 0, 0.1, 0.08, 0, 0.04, 0, 0, 0, 0, 0.78}, // 5 = Güich 
            {0, 0, 0, 0.07, 0, 0.09, 0, 0.36, 0, 0, 0, 0.48}, // 6 = Santander
            {0, 0, 0, 0, 0, 0, 0.3, 0, 0.7, 0, 0, 0}, // 7 = Edificio 3
            {0, 0, 0, 0, 0, 0, 0, 0.44, 0, 0.31, 0.25, 0}, // 8 = Edificio 2
            {0.21, 0, 0, 0, 0, 0, 0, 0, 0.39, 0.4, 0, 0}, // 9 = Edificio 1
            {0, 0, 0, 0, 0, 0, 0.14, 0, 0.44, 0, 0, 0.42}, // 10 = Starbucks
            {0.14, 0.09, 0.08, 0.07, 0.15, 0.19, 0.06, 0, 0, 0, 0.22, 0}, // 11 = Ciberplaza
        };

    Transform[] waypoints = new Transform[12];

    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    int waypointIndex = 0;
    private bool shouldMove = true;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = Random.Range(1, 12);
        waypoints = PlacesManagerController.Instance.Waypoints;

        transform.position = waypoints [waypointIndex].transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.shouldMove) {
            Move();
        }
        
    }

    int NextNode()
    {
        double random = Random.Range(0.0f, 1.0f);
        double cumulativeProb = 0;
        for (int i = 0; i < waypoints.Length; i++){
            cumulativeProb += transitionMatrix[waypointIndex, i];
            if(cumulativeProb >= random){
                return i;
            }
        }
        return 0;
    }

     void Move()
    {

        transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == waypoints [waypointIndex].transform.position){
            StartCoroutine(WaitAtPoint(Random.Range(1, 7)));
            waypointIndex = NextNode();
        }
        
    }

    IEnumerator WaitAtPoint(int seconds) {
        this.shouldMove = false;
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
        }

        this.shouldMove = true;
    }
}

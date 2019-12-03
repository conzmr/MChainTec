using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleScript : MonoBehaviour
{
     [SerializeField]
    public GameObject prefab;

     [SerializeField]
    public int numberOfPeople;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<numberOfPeople; i++)
            Instantiate(prefab, transform.position, transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

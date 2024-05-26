using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearWall : MonoBehaviour
{

    public float apearTime;  
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        apearTime -= Time.deltaTime;
        if (apearTime <= 0)
        {
            wall.SetActive(true);
            Destroy(this);
        }

    }
}

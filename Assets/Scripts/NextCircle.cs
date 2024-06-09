using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCircle : MonoBehaviour
{

    public GameObject circle;
    public gameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

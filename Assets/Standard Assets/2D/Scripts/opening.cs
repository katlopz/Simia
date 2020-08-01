using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{
    public GameObject openingScroll;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(0, 0);
        Instantiate(openingScroll, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

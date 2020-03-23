using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorController : MonoBehaviour
{
    public float offsetx;
    public float offsety;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x + offsetx, transform.position.y + offsety, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAltitude : MonoBehaviour
{
    [SerializeField] float altitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,50);
        if(hit.collider!=null)
        {
            altitude = Mathf.Abs(hit.point.y - transform.position.y);
        }
    }
    public float GetAltitude()
    {
        return altitude;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingHook : MonoBehaviour
{
    public LineRenderer line;
    
    
    
    DistanceJoint2D joint;
    Vector3 target;

    RaycastHit2D rayCast;

    public float distance = 10f;
    public LayerMask mask;


    public float stopping = 0.05f;
    
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        if(joint.distance > 1f)
        {
            joint.distance -= stopping;
        }
        else
        {
            joint.enabled = false;
            line.enabled = false;
        }



        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            rayCast = Physics2D.Raycast(transform.position, target - transform.position, distance, mask);

            if(rayCast.collider != null)
            {
                joint.enabled = true;
                joint.connectedBody = rayCast.collider.gameObject.GetComponent<Rigidbody2D>();


                joint.distance = Vector2.Distance(transform.position, rayCast.point);

                
                joint.enabled = true;
                joint.connectedBody = rayCast.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = rayCast.point - new Vector2(rayCast.collider.transform.position.x, rayCast.collider.transform.position.y);

                joint.distance = Vector2.Distance(transform.position, rayCast.point);


                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, rayCast.point);
                
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            line.SetPosition(0, transform.position);
        }



        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
}

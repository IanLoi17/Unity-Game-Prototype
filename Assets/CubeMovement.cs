using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public GameObject Actor;
    public float speed = 5;
    private Vector3 position;
    public Material material;
    private int loopCount = 1;
    public bool onGround = true;
    public float distFromGround = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = isGrounded();
        position = Actor.transform.position;
        Actor.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (onGround == true)
        {
            GameObject Actor2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Actor2.transform.position = position;
            Actor2.GetComponent<MeshRenderer>().material = material;
            Actor2.GetComponent<BoxCollider>().isTrigger = true;

            if (Input.GetMouseButtonDown(0))
            {
                if (loopCount % 2 != 0)
                {
                    Actor.transform.eulerAngles = new Vector3(0, 90, 0);
                    loopCount++;
                }

                else
                {
                    Actor.transform.eulerAngles = new Vector3(0, 0, 0);
                    loopCount++;
                }
            }
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(Actor.transform.position, Vector3.down, distFromGround);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    new MeshRenderer renderer;
    new Rigidbody rigidbody;
    [SerializeField] float waitingTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.useGravity = false;



    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitingTime)
        {
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }

    }
}

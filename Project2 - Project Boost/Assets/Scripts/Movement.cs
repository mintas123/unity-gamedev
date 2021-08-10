using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    new Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float thrust = 100f;
    [SerializeField] float agility = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("stall");
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                ApplyRotation(agility);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                ApplyRotation(-agility);
            }
        }

    }

    private void ApplyRotation(float thrust)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * thrust * Time.deltaTime);
        rigidbody.freezeRotation = false;

    }
}

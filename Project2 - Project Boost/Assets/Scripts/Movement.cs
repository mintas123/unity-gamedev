using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    [SerializeField] float thrust = 100f;
    [SerializeField] float agility = 100f;
    [SerializeField] ParticleSystem boostParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;

    [SerializeField] AudioClip mainEngine;

    new Rigidbody rigidbody;
    AudioSource audioSource;
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
                audioSource.PlayOneShot(mainEngine);
                boostParticles.Play();

            }
        }
        else
        {
            boostParticles.Stop();
            audioSource.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            leftThrustParticles.Play();
            rightThrustParticles.Play();
            Debug.Log("stall");
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rightThrustParticles.Stop();
                leftThrustParticles.Play();
                ApplyRotation(agility);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                leftThrustParticles.Stop();
                rightThrustParticles.Play();
                ApplyRotation(-agility);
            }
            else
            {
                rightThrustParticles.Stop();
                leftThrustParticles.Stop();
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

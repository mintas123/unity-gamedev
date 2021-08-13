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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            StartRotating(leftThrustParticles, agility);

        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            StartRotating(rightThrustParticles, -agility);
        }
        else
        {
            StopParticles(new List<ParticleSystem> { rightThrustParticles, leftThrustParticles });
        }
    }

    private void StartThrusting()
    {
        rigidbody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!boostParticles.isPlaying)
        {
            boostParticles.Play();
        }
    }
    private void StopThrusting()
    {
        StopParticles(new List<ParticleSystem> { boostParticles });
        audioSource.Stop();
    }


    private void StartRotating(ParticleSystem sideParticles, float thrust)
    {
        ApplyRotation(thrust);
        if (!sideParticles.isPlaying)
        {
            sideParticles.Play();
        }
    }

    private void ApplyRotation(float thrust)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * thrust * Time.deltaTime);
        rigidbody.freezeRotation = false;

    }

    private void StopParticles(List<ParticleSystem> particleSystems)
    {
        particleSystems.ForEach((particleSystem) => particleSystem.Stop());
    }
}

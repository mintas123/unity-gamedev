using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;


        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;


        var movementScript = GetComponent<Movement>();
        movementScript.enabled = false;

        //reset rotation
        var rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.MoveRotation(Quaternion.AngleAxis(5f, Vector3.up));

        //turn off sounds && start success
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        successParticles.Play();


        Invoke("NextLevel", delay);


    }

    private void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        Invoke("ReloadLevel", delay);
        SceneManager.LoadScene(nextSceneIndex);

    }
    private void StartCrashSequence()
    {
        isTransitioning = true;


        //disable movement
        var movementScript = GetComponent<Movement>();
        movementScript.enabled = false;
        Invoke("ReloadLevel", delay);

        //turn off sounds && start crash
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();



    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

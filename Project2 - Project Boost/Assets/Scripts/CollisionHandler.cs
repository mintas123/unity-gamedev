using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("bff");
                break;
            case "Finish":
                Debug.Log("You are done!");
                break;
            default:
                Debug.Log("beng");
                ReloadLevel();
                break;


        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

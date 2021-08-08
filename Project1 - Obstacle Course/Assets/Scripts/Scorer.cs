using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    int score = 0;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "plane" && other.gameObject.tag != "Hit")
        {
            score++;
            Debug.Log("damn you suck... Hit number " + score);
        }


    }
}

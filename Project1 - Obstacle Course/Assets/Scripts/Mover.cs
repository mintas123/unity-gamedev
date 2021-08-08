using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;



    // Start is called before the first frame update
    void Start()
    {
        DoStuff();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void DoStuff()
    {
        Debug.Log("start");

    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);

    }
}

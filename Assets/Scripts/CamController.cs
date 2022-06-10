using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera cam;
    Transform player;
    public float followingSpeed;
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, followingSpeed * Time.deltaTime), Mathf.Lerp(transform.position.y, player.transform.position.y, followingSpeed * Time.deltaTime),transform.position.z);
    }
}

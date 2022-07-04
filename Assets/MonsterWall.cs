using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWall : MonoBehaviour
{
    float deadTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deadTime += Time.deltaTime;

        if (deadTime >= 30)
            Destroy(gameObject);
    }
}

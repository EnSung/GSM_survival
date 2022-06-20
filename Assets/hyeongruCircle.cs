using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyeongruCircle : MonoBehaviour
{
    public Hyeongru hy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(hy.applyRadius * 4, hy.applyRadius * 4, 1);
    }
}

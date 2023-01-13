using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineEffect : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            anim.SetInteger("state", 1);
        }
        else
        {
            anim.SetInteger("state", 0);
        }
    }
}

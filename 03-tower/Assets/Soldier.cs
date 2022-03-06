using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private bool isShooting = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("SwitchPose", 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwitchPose() {
        isShooting = !isShooting;
        anim.SetBool("IsShooting", isShooting);
    }
}

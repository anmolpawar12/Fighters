using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour
{
    private Animator wizardAnimator;
    private CapsuleCollider coll;
    public Slider power1;
    public Slider power2;
    private float power1time = 0f;
    private float power2time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        wizardAnimator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();
        power1.value = 0;
        power2.value = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        power1time += Time.deltaTime;
        power2time += Time.deltaTime;
        power1.value = (power1time * 1) / 3;
        power2.value = (power2time * 1) / 5;
       
    }

    public void PUCHE1()
    {
        wizardAnimator.Play("Punche");


    }
    public void PUCHE2()
    {
        wizardAnimator.Play("Punches");
    }
    public void Power1()
    {
        if (power1.value==3)
        {
            wizardAnimator.Play("power1");
            power1time = 0f;
        }

    }
    public void Power2()
    {
        if (power2.value == 5)
        {
            wizardAnimator.Play("power2");
            power2time = 0f;
        }
    }
   

}

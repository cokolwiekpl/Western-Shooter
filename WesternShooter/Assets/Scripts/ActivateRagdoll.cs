using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    
    public float puntForce;
    private GameObject characterRig;
    private Animator characterAnimator;
    private Rigidbody[] ragdollRigidbodies; 

    void Start()
    {
        GetRagdollParts();
        RagdollOff();
    }

    void Update()
    {
        if (transform.gameObject.tag == "Dead")
        {
            RagdollOn();
        }
        /*Debug
        if (Input.GetKeyDown("space"))
        {
            RagdollOn();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RagdollOff();
        }
        */
    }

    /// <summary>
    /// It disables the animator and enables the physics on the ragdoll parts
    /// </summary>
    public void RagdollOn()
    {
        characterAnimator.enabled = false;
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    //przejście z ragdolla na mekanim - w tym trybie zaczyna każa (żywa) postać
    /// <summary>
    /// We're disabling the ragdoll by making all the rigidbodies kinematic and disabling gravity
    /// </summary>
    public void RagdollOff()
    {
        
        foreach(Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        /* Enabling the character's animator. */
        characterAnimator.enabled = true;
    }

    /// <summary>
    /// > This function gets all the rigidbodies in the character's ragdoll and stores them in an array
    /// </summary>
    void GetRagdollParts()
    {
        ragdollRigidbodies = characterRig.GetComponentsInChildren<Rigidbody>();
    }

    /// <summary>
    /// We get the child of the game object that this script is attached to, and then we get the animator component of the
    /// game object that this script is attached to
    /// </summary>
    private void Awake()
    {
        characterRig = this.gameObject.transform.GetChild(0).gameObject;
        characterAnimator = GetComponent<Animator>();
    }
}

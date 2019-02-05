using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinAnimation : MonoBehaviour
{

    public Animator animator;
    public FeedbackManager feedbackManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMuoviBocca()
    {
        animator.SetBool("muoviBocca", true);
        animator.SetBool("loop", true);
    }
    public void StopMovimentoBocca()
    {
        animator.SetBool("muoviBocca", false);
        animator.SetBool("loop", false);
    }

    public void ApriBocca()
    {
        animator.SetBool("apriBocca", true);
        animator.SetBool("chiudiBocca", false);
    }
    public void ChiudiBocca()
    {
        Debug.Log("Chiudo la bocca");
        animator.SetBool("chiudiBocca", true);
        animator.SetBool("apriBocca", false);
    }

}

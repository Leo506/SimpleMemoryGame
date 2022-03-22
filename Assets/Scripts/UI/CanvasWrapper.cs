using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Canvas))]
public class CanvasWrapper : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AppearCanvas()
    {
        animator.SetTrigger("Appear");
    }

    public void HideCanvas()
    {
        animator.SetTrigger("Hide");
    }
}

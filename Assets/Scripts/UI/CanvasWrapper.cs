using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWrapper : MonoBehaviour
{
    Canvas thisCanvas;
    Animator animator;

    private void Awake()
    {
        thisCanvas = GetComponent<Canvas>();
        animator = GetComponent<Animator>();
    }

    public void AppearCanvas()
    {
        thisCanvas.enabled = true;
        animator.SetTrigger("Appear");
    }

    public void HideCanvas()
    {
        animator.SetTrigger("Hide");
    }
}

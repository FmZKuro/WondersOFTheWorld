using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    private float xAxis;
    private float yAxis;
    public Rigidbody2D rb2d;
    private Animator animator;
    private string currentState;

    void Start()
    {
        Cursor.visible = false;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void ChangeAnimationState(string newState)
    {
        //parar a animação de se interromper caso seja igual
        if (currentState == newState) return;

        //tocar a animação
        animator.Play(newState);

        //Trocar currentState com o NewState
        currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

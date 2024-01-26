using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocidade = 7f;
    public float forcaPulo = 10f;
    public bool noChao;
    public bool isJump;
    public bool isRun;


    void Start()
    {
        // Obtenha o componente Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Verifica se o componente Rigidbody2D foi encontrado
        if (rb != null)
        {
            // Move o jogador no início do jogo
            Move();

            // Pula no início do jogo (se desejado)
            Pular();
        }
    }

    void Update()
    {
        // Move o jogador continuamente
        Move();

        // Verifica a entrada para pular
        if (Input.GetKeyDown(KeyCode.W) && noChao)
        {
            // Pula apenas se estiver no chão
            Pular();
        }
    }

    void Move()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(moverHorizontal, 0f, moverVertical);
        movimento = movimento.normalized * velocidade * Time.deltaTime;
        transform.Translate(movimento);
    }

    void Pular()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noChao = false;
        }
    }

     void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = true;
            isJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = false;
            isJump = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{

    private Vitoria vitoriaScript;

    private void Start()
    {
        vitoriaScript = FindObjectOfType<Vitoria>();
    }

    private void DerrotarInimigo()
    {
        // L�gica para derrotar o inimigo

        // Chamar o m�todo InimigoDerrotado do script Vitoria
        if (vitoriaScript != null)
        {
            vitoriaScript.InimigoDerrotado();
        }
    }
}

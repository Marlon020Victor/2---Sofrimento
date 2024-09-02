using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EfeitoDigitador : MonoBehaviour
{
    private TextMeshProUGUI ComponentText;
    private AudioSource _audioSource;
    private string MensageOriginal;
    public bool Imprimindo;
    public float TempoEntreLetras = 0.08f;
    
    private void Awake()
    {
        TryGetComponent(out ComponentText);
        TryGetComponent(out _audioSource);
        MensageOriginal = ComponentText.text ;
        ComponentText.text = "";

    }

    private void OnEnable()
    {
        InprimirMensagem(MensageOriginal);
    }

    private void OnDisable()
    {
        ComponentText.text = MensageOriginal;
        StopAllCoroutines();
    }

    public void InprimirMensagem(string msg)
    {
        if (gameObject.activeInHierarchy)
        {
            if (Imprimindo) return;
            Imprimindo = true;
            StartCoroutine(LetrasPorLetras(msg));
        }
    }

    IEnumerator LetrasPorLetras(string msg)
    {
        string Mensagem = "";
        foreach (var Letra in msg)
        {
            Mensagem += Letra;
            ComponentText.text = Mensagem;
            _audioSource.Play();
            yield return new WaitForSeconds(TempoEntreLetras);
        }
        Imprimindo = false;
        StopAllCoroutines();
    }
}

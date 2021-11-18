using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Button botao;
    [SerializeField] private Toggle menu;

    void Start()
    {
        botao = GetComponent<Button>();
        botao.onClick.AddListener(Sair);
    }

    public void Sair()
    {
        SceneManager.LoadScene("Start");
        menu.isOn = false;
    }

    /*public void Musica()
    {
        SceneManager.LoadScene("Start");
    }*/
}

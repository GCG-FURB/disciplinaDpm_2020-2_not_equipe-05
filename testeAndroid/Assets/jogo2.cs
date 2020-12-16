using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class jogo2 : MonoBehaviour
{
    public GameObject painel; 
    public GameObject[] botoes;
    private int aux = 1 ;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject bt in botoes)
        {
            bt.GetComponent<Button>().onClick.AddListener(delegate{clicou(bt);});
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void clicou(GameObject bt){
        Debug.Log(bt.GetComponentInChildren<Text>().text);
        int valor = Int16.Parse(bt.GetComponentInChildren<Text>().text);

        if(valor == aux){
            aux++;
            if(aux == 11){
               aux = 1;
                foreach (GameObject bot in botoes)
                {
                    bot.GetComponent<Button>().interactable = true;
                } 
                GameObject.Find("Jogo 2").gameObject.SetActive(false);
                painel.SetActive(true);

            }
        }else{
            aux = 1;
            foreach (GameObject bot in botoes)
            {
                bot.GetComponent<Button>().interactable = true;
            }
        }
    }
}

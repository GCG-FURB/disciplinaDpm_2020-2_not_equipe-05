using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Jogo3 : MonoBehaviour
{
    public GameObject painel; 
    public GameObject botao;
    public GameObject[] lixos;
    public GameObject porta1, porta2;
    System.Random rand = new System.Random();
    

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject fo in lixos)
        {
            fo.GetComponent<Rigidbody2D>().gravityScale = (float)rand.NextDouble() * (1 - (-1)) + (-1) ;
        }
        botao.GetComponent<Button>().onClick.AddListener(delegate{clicou();});

    }

    public IEnumerator contador(){
        yield return new WaitForSeconds(2.0f);
        porta1.SetActive(true);
        porta2.SetActive(true);
        foreach (GameObject fo in lixos)
        {
            fo.GetComponent<Rigidbody2D>().gravityScale = (float)rand.NextDouble() * (1 - (-1)) + (-1) ;
        }
        painel.SetActive(true);
        botao.transform.Rotate(0 , 0, 180);
        GameObject.Find("Jogo 3").gameObject.SetActive(false);
    }

    void clicou(){
        botao.transform.Rotate(0 , 0, 180);
        porta1.SetActive(false);
        porta2.SetActive(false);
        foreach (GameObject fo in lixos)
        {
            fo.GetComponent<Rigidbody2D>().gravityScale = 689;
        }
        StartCoroutine(contador());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

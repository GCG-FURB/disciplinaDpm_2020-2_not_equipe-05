using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rot;
    int score;
    public GameObject winText, painel;
    public GameObject[] pontinhos;
    public Vector3 posi;

    private void OnEnable()
    {
        gameObject.transform.position = posi;
        foreach (GameObject Food in pontinhos)
        {
            Food.SetActive(true);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        posi = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy){
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (mousePos.x < 0)
                {
                    rot = rotateAmount;
                    transform.Rotate(0, 0, rot);
                }
                else 
                {
                    rot = -rotateAmount;
                    transform.Rotate(0, 0, rot);
                }
            
            }
        }
    }

    private void FixedUpdate() 
    {
        if(gameObject.activeInHierarchy){
            rb.velocity = transform.up * moveSpeed;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            score++;
            if (score >= 5) 
            {
                //print("Level Complete");
                //winText.SetActive(true);
                foreach (GameObject Food in pontinhos)
                {
                    Food.SetActive(true);
                }
                score = 0;
                GameObject.Find("Jogo 1").gameObject.SetActive(false);
                painel.SetActive(true);
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            score = 0;
            GameObject.Find("Jogo 1").gameObject.SetActive(false);
            painel.SetActive(true);
            //SceneManager.LoadScene("Game");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject[] gameObjectsHearts;
    public GameObject[] gameObjectsMissingHearts;

    public int heartsLeft;
    public int maxHearts = 7;
    public int defaultHearts = 3;

    // Start is called before the first frame update
    void Start()
    {
        heartsLeft = defaultHearts;

        updateGUI();
    }
    void FixedUpdate(){
        updateGUI();
    }
    void updateGUI(){
        if (maxHearts > gameObjectsHearts.Length)
        {
            maxHearts = gameObjectsHearts.Length;
        }
        if (heartsLeft > maxHearts)
        {
            heartsLeft = maxHearts;
        }
        for (int i = 0; i < gameObjectsHearts.Length; i++)
        {
            if(i<heartsLeft && i<maxHearts){
                gameObjectsHearts[i].SetActive(true);
                gameObjectsMissingHearts[i].SetActive(false);
            }            
            else
            {
                if(i < maxHearts){
                    gameObjectsHearts[i].SetActive(false);
                    gameObjectsMissingHearts[i].SetActive(true);
                }
                else{
                    gameObjectsHearts[i].SetActive(false);
                    gameObjectsMissingHearts[i].SetActive(false);
                }
            }
        }
    }
}

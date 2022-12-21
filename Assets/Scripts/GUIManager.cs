/*using System.Collections;
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
    public void updateGUI()
    {
        int length = Mathf.Min(gameObjectsHearts.Length, gameObjectsMissingHearts.Length);
        maxHearts = Mathf.Min(maxHearts, length);
        heartsLeft = Mathf.Min(heartsLeft, maxHearts);

        for (int i = 0; i < length; i++)
        {
            gameObjectsHearts[i].SetActive(i < heartsLeft);
            gameObjectsMissingHearts[i].SetActive(i >= heartsLeft && i < maxHearts);
        }
    }
}*/
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
    public void updateGUI()
    {
        int length = Mathf.Min(gameObjectsHearts.Length, gameObjectsMissingHearts.Length);

        maxHearts = Mathf.Min(maxHearts, length);
        heartsLeft = Mathf.Min(heartsLeft, maxHearts);

        for (int i = 0; i < length; i++)
        {
            gameObjectsHearts[i].SetActive(i < heartsLeft);
            gameObjectsMissingHearts[i].SetActive(i >= heartsLeft && i < maxHearts);
        }
    }
}

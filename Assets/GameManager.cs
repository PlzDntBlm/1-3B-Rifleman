using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject DeathScreen;

    public float timescale = 0f;
    public bool isPaused = true;

    //private bool waitForKeyUp = false;
    // Start is called before the first frame update
    void Start()
    {
        //NewRound();
        ViewStartScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ViewStartScreen()
    {
        Debug.Log($"Start Screen");
        StartScreen.GetComponent<TextMeshProUGUI>().enabled = true;
        timescale = 0f;

        WaitForKeyPressToStart();
    }
    void WaitForKeyPressToStart()
    {

        //Start Coroutine
        StartCoroutine(keyPressToStart());
    }
    IEnumerator keyPressToStart()
    {
        yield return new WaitForSeconds(1);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        StartScreen.GetComponent<TextMeshProUGUI>().enabled = false;
        timescale = 1f;
        yield return null;
    }
    public void Die()
    {
        Debug.Log($"Just Died");
        DeathScreen.SetActive(true);
        timescale = 0f;

        StartCoroutine(keyPressToHideDeathScreen());
    }
    void restartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator keyPressToHideDeathScreen()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        DeathScreen.SetActive(false);
        restartLevel();
        yield return null;
    }
}

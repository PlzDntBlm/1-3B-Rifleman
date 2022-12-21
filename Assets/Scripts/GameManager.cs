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

    // Start is called before the first frame update
    void Start()
    {
        //NewRound();
        ViewStartScreen();
    }
    void ViewStartScreen()
    {
        toggleScreens("start");
        StartCoroutine(keyPressToStart());
    }
    public void Die()
    {
        toggleScreens("death");
        StartCoroutine(keyPressToHideDeathScreen());
    }
    void toggleScreens(string eventType)
    {
        switch (eventType)
        {
            case "start":
                StartScreen.GetComponent<TextMeshProUGUI>().enabled = true;
                break;
            case "death":
                DeathScreen.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid event type: " + eventType);
                break;
        }
        timescale = 0f;
    }
    IEnumerator keyPressToStart()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        StartScreen.GetComponent<TextMeshProUGUI>().enabled = false;
        timescale = 1f;
    }
    void restartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator keyPressToHideDeathScreen()
    {
        yield return new WaitForSeconds(0.5f);

        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }

        DeathScreen.SetActive(false);
        restartLevel();
    }
}

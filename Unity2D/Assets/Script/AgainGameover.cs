using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgainGameover : MonoBehaviour
{
    static AgainGameover instance;
    public Text timeScore;
    public GameObject GameoverUI;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        instance = this;
    }
    

    // Update is called once per frame
    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }
    public void RestarGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    private void Quit()
    {
        Application.Quit();
    }
    public static void Gameover(bool dead) {
        if (dead)
        {
            Time.timeScale = 0f;
            instance.GameoverUI.SetActive(true);
        }
    }
}

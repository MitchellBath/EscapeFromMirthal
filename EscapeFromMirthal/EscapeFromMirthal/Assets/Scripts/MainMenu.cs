using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string GameScene;

    public void NewGame() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(GameScene);

    }

    public void NextLevel() {

        //if (GameObject.Find("InfoObject") != null) {

            //if (GameObject.Find("InfoObject").GetComponent<Info>().level.name != "LevelEnd") {

                //print("Setlevel");
                //pastLevel = GameObject.Find("InfoObject").GetComponent<Info>().level;

            //}

            //print(pastLevel.name);

            if (SceneManager.GetActiveScene().name == "LevelEnd1") {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneManager.LoadScene("Level2");

            }
            if (SceneManager.GetActiveScene().name == "LevelEnd2") {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneManager.LoadScene("Level3");

             }
             if (SceneManager.GetActiveScene().name == "LevelEnd3") {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Title");

             }

    }

    public void QuitGame() {

        Application.Quit();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

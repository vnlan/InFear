using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameView : GameElement
{
    public MainCharacterView mainCharacterView;
    public MonsterCharacterView[] monsterCharacterView;
    public KeyView[] keyView;
    public DeadZoneView deadZoneView;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(app.level);
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("MenuMain");
        }
    }
}

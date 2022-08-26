using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameElement : MonoBehaviour
{
    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
}
public class GameApplication : MonoBehaviour
{
    public GameModel model;
    public GameView view;
    public GameController controller;

    public Text lifeCount;
    public Text keyCount;
    public Text nameCharacter;
    public GameObject gameOver;

    public Text notify;
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(UltilComponent.ReadData()) && int.Parse(UltilComponent.ReadData().Split('|')[2]) > 0 && !level.Equals(ConstantsComp.STARTUP) && !UltilComponent.ReadData().Split('|')[0].Equals(ConstantsComp.STARTUP))
        {
            SetData(UltilComponent.ReadData());
        }
        else
        {
            UltilComponent.writeData($"{level}||{model.life}|{model.key}|{view.mainCharacterView.gameObject.transform.position.x}|{view.mainCharacterView.gameObject.transform.position.y}|{view.mainCharacterView.gameObject.transform.position.z}");
        }

        if (level.Equals(ConstantsComp.STARTUP))
        {
            Notify(ConstantsComp.MOVE);
        }
    }

    void Update()
    {
        lifeCount.text = model.life.ToString();
        keyCount.text = model.key.ToString();
        nameCharacter.text = view.mainCharacterView.name;

        if(model.life == 0)
        {
            gameOver.SetActive(true);
        }
    }

    public void SetData(string input)
    {
        var data = input.Split('|');
        model.life = int.Parse(data[2]);
        model.key = int.Parse(data[3]);
        view.mainCharacterView.gameObject.transform.position = new Vector3(float.Parse(data[4]), float.Parse(data[5]), float.Parse(data[6]));
    }

    public void Notify(string message)
    {
        notify.gameObject.SetActive(true);
        notify.text = message;
    }

    public void HiddenNotify()
    {
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3);
        notify.gameObject.SetActive(false);
    }
}

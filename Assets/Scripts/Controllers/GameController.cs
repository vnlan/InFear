using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : GameElement
{
    public void OnKeyHit()
    {
        app.model.key++;
    }

    public void OnMonsterHit(string name)
    {
        app.model.life--;
        app.Notify(string.Format(ConstantsComp.DEADCHARACTER, name));
        CheckPoint();
    }

    public void OnDeadZoneHit()
    {
        app.model.life = 0;
    }

    public void OnNextDoorHit(string nameNextScene)
    {
        if(app.model.key >= app.model.winCondition)
        {
            if (app.level.Equals(ConstantsComp.STARTUP))
            {
                UltilComponent.writeData(string.Empty);
            }
            SceneManager.LoadScene(nameNextScene);
        }
        else
        {
            app.Notify(string.Format(ConstantsComp.NEXTDOORCONDITION, app.model.key, app.model.winCondition - app.model.key));
        }
    }

    public void CheckPoint()
    {
        if (!string.IsNullOrEmpty(UltilComponent.ReadData()))
        {
            var data = UltilComponent.ReadData().Split('|');
            UltilComponent.writeData($"{app.level}||{app.model.life}|{app.model.key}|{data[4]}|{data[5]}|{data[6]}");
            var loadCheckpoint = UltilComponent.ReadData().Split('|');
            app.model.life = int.Parse(loadCheckpoint[2]);
            app.model.key = int.Parse(loadCheckpoint[3]);
            app.view.mainCharacterView.gameObject.transform.position = new Vector3(float.Parse(loadCheckpoint[4]), float.Parse(loadCheckpoint[5]), float.Parse(loadCheckpoint[6]));
        }
    }
}

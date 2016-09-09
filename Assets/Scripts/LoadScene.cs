using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public void LoadToScene (int sceneToLoad) {
        DataManagement.dataManage.gameOn = true;
        DataManagement.dataManage.playerDed = false;
        Application.LoadLevel (sceneToLoad);
    }
}

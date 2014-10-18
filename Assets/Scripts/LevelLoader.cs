using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour{

    public float Delay;

    public void LoadLevel(string level){
        StartCoroutine(LoadLevelAsync(level));
    }

    private IEnumerator LoadLevelAsync(string level){
        yield return new WaitForSeconds(Delay);
        Application.LoadLevelAsync(level);
    }

    public void QuitGame(){
        Application.Quit();
    }

}

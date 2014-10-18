using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour{

    public Text HighScoreList;
    public Text SubmitButton;
    public InputField Input;

    protected void Awake(){
        LoadScore();
    }

    public void LoadScore(){
        string url = "http://silveryard.bplaced.net/BaconGameJam08/GetHighScore.php";
        WWW www = new WWW(url);

        StartCoroutine(LoadHighScores(www));
    }

    public void SaveScore(){
        string url = "http://silveryard.bplaced.net/BaconGameJam08/AddHighScore.php";
        WWWForm form = new WWWForm();
        form.AddField("User", Input.value);
        form.AddField("Score", Score.GetScore());
        WWW www = new WWW(url, form);

        StartCoroutine(SaveHighScore(www));
    }

    private IEnumerator LoadHighScores(WWW www){
        HighScoreList.text = "Loading";
        yield return www;
        HighScoreList.text = "loaded";
        if (www.error == null)
            HighScoreList.text = www.text.Replace("<br>", System.Environment.NewLine);
        else{
            HighScoreList.text = www.error;
        }
    }

    private IEnumerator SaveHighScore(WWW www){
        SubmitButton.text = "Loading";
        yield return www;

        SubmitButton.text = "Loaded";

        if (www.error == null)
            Debug.Log(www.text);
        else{
            Debug.Log("ERROR: " + www.error);
        }

        SubmitButton.text = "Thank you";
        LoadScore();
    }

    public void BackToMenu(){
        Application.LoadLevel("Menu");
    }
}

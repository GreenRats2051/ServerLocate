using UnityEngine;

public class PlayerPrefsSaver : ISaver
{
    public void SaveScore(int score, string path = null)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
}
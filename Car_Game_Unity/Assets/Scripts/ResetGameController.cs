using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameController : MonoBehaviour
{
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}

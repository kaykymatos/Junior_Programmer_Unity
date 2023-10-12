using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public GameManager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDefficulty);

    }
    void SetDefficulty()
    {
        Debug.Log(difficulty);
        gameManager.StartGame(difficulty);
        Debug.Log(gameObject.name + " Was click");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

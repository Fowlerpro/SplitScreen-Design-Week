using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class S_GameOverUI : MonoBehaviour
{
    [SerializeField]
    GameMaster gMRef;
    [SerializeField]
    TextMeshProUGUI scoreField;

    private void Update()
    {
        scoreField.text = gMRef.score.ToString();
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }
}

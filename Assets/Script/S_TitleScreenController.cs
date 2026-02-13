using UnityEngine;
using UnityEngine.SceneManagement;
public class S_TitleScreenController : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene("Dual Monitor Setup", LoadSceneMode.Single);
    }

}

using TMPro;
using UnityEngine;

public class S_TimerCounter : MonoBehaviour
{
    [SerializeField]
    GameMaster gM;

    TextMeshProUGUI textField;

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (textField != null)
        {
            textField.text = gM.startTime.ToString();
        }
    }
}

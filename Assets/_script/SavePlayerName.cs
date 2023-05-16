using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePlayerName : MonoBehaviour
{
    public TMP_InputField playerNameInput; // ������ �� ��������� TMP_InputField ��� ����� ����� ������

    private const string PlayerNameKey = "player_name"; // ���� ��� ���������� ����� ������ � PlayerPrefs

    public void SaveName()
    {
        string playerName = playerNameInput.text; // �������� ��� ������ �� InputField

        PlayerPrefs.SetString(PlayerNameKey, playerName); // ��������� ��� ������ � PlayerPrefs
    }
}

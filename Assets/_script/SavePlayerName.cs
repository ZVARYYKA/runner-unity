using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavePlayerName : MonoBehaviour
{
    public TMP_InputField playerNameInput; // ссылка на компонент TMP_InputField для ввода имени игрока

    private const string PlayerNameKey = "player_name"; // ключ для сохранения имени игрока в PlayerPrefs

    public void SaveName()
    {
        string playerName = playerNameInput.text; // получаем имя игрока из InputField

        PlayerPrefs.SetString(PlayerNameKey, playerName); // сохраняем имя игрока в PlayerPrefs
    }
}

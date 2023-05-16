using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI death;
    public bool isCount;
    private float timer = 0.0f; // таймер для отсчета времени

    private const float TimeDelay = 0.2f; // время задержки между инкрементами переменной count

    void Update()
    {
        timer += Time.deltaTime; // увеличиваем таймер каждый кадр

        if (timer >= TimeDelay) // если прошло достаточно времени
        {
            if (isCount)
                count++; // увеличиваем переменную count на 1
            textMeshPro.text = count.ToString(); // обновляем значение в компоненте TextMeshProUGUI
            timer = 0.0f; // сбрасываем таймер
        }
    }
}

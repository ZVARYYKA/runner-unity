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
    private float timer = 0.0f; // ������ ��� ������� �������

    private const float TimeDelay = 0.2f; // ����� �������� ����� ������������ ���������� count

    void Update()
    {
        timer += Time.deltaTime; // ����������� ������ ������ ����

        if (timer >= TimeDelay) // ���� ������ ���������� �������
        {
            if (isCount)
                count++; // ����������� ���������� count �� 1
            textMeshPro.text = count.ToString(); // ��������� �������� � ���������� TextMeshProUGUI
            timer = 0.0f; // ���������� ������
        }
    }
}

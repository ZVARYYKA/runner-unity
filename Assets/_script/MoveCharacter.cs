using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float moveSpeed = 5f; // ������� �������� �������� ��������

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // ������� ��������� �� ��� X
    }
}

using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float moveSpeed = 5f; // Задайте желаемую скорость движения

    private void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Двигаем персонажа по оси X
    }
}

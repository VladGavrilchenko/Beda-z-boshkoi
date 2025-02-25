using UnityEngine;

public class RotateTowardsPlayer: MonoBehaviour
{
    [SerializeField] private Transform player; // Посилання на трансформ гравця
    [SerializeField] private float rotationSpeed = 5f; // Швидкість обертання

    private void Update()
    {
        if (player != null)
        {
            // Отримуємо напрямок до гравця
            Vector3 direction = player.position - transform.position;

            // Нормалізуємо напрямок, щоб отримати вектор одиничної довжини
            direction.y = 0; // Опціонально, якщо хочете ігнорувати нахили по осі Y
            direction.Normalize();

            // Розраховуємо цільову ротацію
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Плавно обертаємо об'єкт у бік гравця
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Для встановлення гравця з іншого скрипта
    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform;
    }
}


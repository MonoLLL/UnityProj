using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    private DontDestroy[] saved;
    public void Awake()
    {
        saved = FindObjectsOfType<DontDestroy>(true);
        foreach (var item in saved)
        {
            // Найден объект типа DontDestroy, не являющийся объектом, к которому прикреплен этот скрипт
            if (item != this)
            {
                // Имя объектов одинаковое - дубликат удаляется
                if (item.name == this.name)
                    Destroy(gameObject);
            }
            // Метод библиотеки UnityEngine, не уничтожающий объект при переходе на другой экран (сцену)
        }
        DontDestroyOnLoad(gameObject);
    }
}

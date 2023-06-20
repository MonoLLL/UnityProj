using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
[System.Serializable]
public class SaveManager: MonoBehaviour
{
    public static SaveManager manager { get; private set; }
    public List<GameObject> Creatures = new List<GameObject>();
    private float currentStars;
    private float totalStars;
    private float health;
    private string filePath;
    private int unlockedLvls;

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            if (manager != this)
                Destroy(gameObject);
        }
        currentStars = 0;
        totalStars = 0;
        health = 0;
        unlockedLvls = 1;
        filePath = Application.persistentDataPath + "/savedgame.save";
    }
    //Сохранение финальных результатов уровня. Вызывается по его завершении
    public void SaveProgress()
    {
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        totalStars = Respawn.Instance.finalProgress;
        unlockedLvls = LevelManager.lvlUnlock;
        save.Score = totalStars;
        save.lvlUnlock = unlockedLvls;

        binFormatter.Serialize(file, save);
        file.Close();
    }
    //Сохранение текущего состояния уровня. Вызывается при выходе из уровня или приложения
    public void SaveInProcess()
    {
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        currentStars = StarCollectible.Instance.Score;
        health = HealthBar.Instance.healthToSave;
        save.Score = currentStars;
        save.Health = health;
        save.SaveCreatures(Creatures);

        binFormatter.Serialize(file, save);
        file.Close();
    }
    //Восстановление прогресса на уровне
    public void LoadGameProcess()
    {
        if (!File.Exists(filePath))
            return;
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Open);
        if (file.Length != 0)
        {
            Save save = (Save)binFormatter.Deserialize(file);
            file.Close();
            if (save.Creatures.Count != 0)
            {
                int i = 0;
                foreach (Save.SaveData creature in save.Creatures)
                {
                    Creatures[i].GetComponent<LoadPositions>().LoadData(creature);
                    i++;
                }
            }
            HealthBar.Instance.healthToSave = save.Health;
            HealthBar.Instance.LoadHealth();
            StarCollectible.Instance.Score = save.Score;
            StarCollectible.Instance.LoadScore();
        }
    }
    //Восстановление прогресса в игре
    public void LoadGameProgress()
    {
        if (!File.Exists(filePath))
            return;
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream file = new FileStream(filePath, FileMode.Open);

        Save save = (Save)binFormatter.Deserialize(file);
        file.Close();

        LevelManager.lvlUnlock = save.lvlUnlock;
        StarCollectible.Instance.Score = save.Score;
        StarCollectible.Instance.LoadScore();
    }
}
[System.Serializable]
public class Save
{
    // Структура данных - создание вектора
    [System.Serializable]
    public struct Vec2
    {
        public float x, y;
        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    // Структура данных сохраняемой позиции
    [System.Serializable]
    public struct SaveData
    {
        public Vec2 position;
        public SaveData(Vec2 pos)
        {
            position = pos;
        }
    }
    // Сохраняемые поля
    public List<SaveData> Creatures = new List<SaveData>();
    public float Score;
    public int lvlUnlock;
    public float Health;
    // Заполнение списка сохраняемых позиций объектов
    public void SaveCreatures(List<GameObject> creatures)
    {
        foreach (GameObject creature in creatures)
        {
            Vec2 pos = new Vec2(creature.transform.position.x, creature.transform.position.y);
            Creatures.Add(new SaveData(pos));
        }
    }
}

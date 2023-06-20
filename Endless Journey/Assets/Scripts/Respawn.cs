using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public AudioClip winSound;
    public static Respawn Instance { get; private set; }
    public float finalProgress; //Финальное количество звезд (для запоминания в меню уровней)

    public void Awake()
    {
        Instance = this;
        finalProgress = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            SaveResults();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SoundManager.instance.PlaySound(winSound);
        }
    }
    public void SaveResults()
    {
        LevelManager.lvlUnlock += 1;
        finalProgress = StarCollectible.Instance.Score;
        SaveManager.manager.SaveProgress();
    }
}

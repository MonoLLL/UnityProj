using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public AudioClip winSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SoundManager.instance.PlaySound(winSound, SoundManager.currentVolume);
        }
    }
}

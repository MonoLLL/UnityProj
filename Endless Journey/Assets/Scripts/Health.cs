using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health: MonoBehaviour
{
    public float currentHealth { get; private set; }
    private Animator anim;
    private void Awake()
    {
        currentHealth = 3;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("hurt");    //����� ������ ���� �������� ������
            GetComponent<PlayerMovement>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //����� ������ ���� ���� � ����������
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}

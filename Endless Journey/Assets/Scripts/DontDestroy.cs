using UnityEngine;

public class DontDestroy: MonoBehaviour
{
    private DontDestroy[] saved;
    public void Awake()
    {
        saved = FindObjectsOfType<DontDestroy>(true);
        foreach (var item in saved)
        {
            // ������ ������ ���� DontDestroy, �� ���������� ��������, � �������� ���������� ���� ������
            if (item != this)
            {
                // ��� �������� ���������� - �������� ���������
                if (item.name == this.name)
                    Destroy(gameObject);
            }
            // ����� ���������� UnityEngine, �� ������������ ������ ��� �������� �� ������ ����� (�����)
        }
        DontDestroyOnLoad(gameObject);
    }
}

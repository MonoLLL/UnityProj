using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingHook : MonoBehaviour
{
    //Визуализация крюка
    public LineRenderer line;
    //
    DistanceJoint2D joint;


    //К чему привязываюсь
    Vector3 target;

    RaycastHit2D rayCast;

    //Позволимая дистанция для привязки
    public float distance = 10f;
    public LayerMask mask;

    //Скорость приблежения к концу крюка
    public float stopping = 0.05f;
    
    void Start()
    {
        //Получение элемента отвечающего за длину крюка
        joint = GetComponent<DistanceJoint2D>();
        //Изначальное состояния крюка
        joint.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        
        if(joint.distance > 1f)
        {
            joint.distance -= stopping;
        }
        else
        {
            joint.enabled = false;
            line.enabled = false;
        }



        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            //Отслеживание курсора мыши
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            //Выситвание длины можно притянуться или нет
            rayCast = Physics2D.Raycast(transform.position, target - transform.position, distance, mask);


            //Проверка на привязку
            if(rayCast.collider != null)
            {
                //Если мы привязались зачит объект имеет тип риджебади
                joint.enabled = true;
                joint.connectedBody = rayCast.collider.gameObject.GetComponent<Rigidbody2D>();

                //Высчитывание отрисовки курюка
                joint.distance = Vector2.Distance(transform.position, rayCast.point);

                
                joint.enabled = true;
                joint.connectedBody = rayCast.collider.gameObject.GetComponent<Rigidbody2D>();
                //Высчитывание края объекта зацепа
                joint.connectedAnchor = rayCast.point - new Vector2(rayCast.collider.transform.position.x, rayCast.collider.transform.position.y);

                joint.distance = Vector2.Distance(transform.position, rayCast.point);

                //Отрисовка
                line.enabled = true;
                //Игрок
                line.SetPosition(0, transform.position);
                //Край луча
                line.SetPosition(1, rayCast.point);
                
            }
        }
        //Динамическая отрисовка 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            line.SetPosition(0, transform.position);
        }


        //Если клавиша не нажата, крюк отключается
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
}

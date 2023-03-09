using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//------- Скрипт для зацикленного перемещения фона в основном меню -------//
public class MenuBackgroundMoveLeft : MonoBehaviour
{
    [Header("Скорость перемотки")]
    [Range(300, 500)]
    public float speed;
    [Header("Начальная позиция")]
    private Vector3 startPosition;
    [Header("Длина сдвига")]
    private float repeatWidth;

    void Start()
    {
        transform.DOMoveX(-1000, 10f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        ////Debug.Log("startPosition " + startPosition.x.ToString());
        ////Фиксируем стартовую позицию
        //startPosition = transform.position;
        ////Определяем длину сдвига
        //if (GetComponent<BoxCollider>().size.x > GetComponent<BoxCollider>().size.y)
        //{
        //    repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        //}
        //else
        //{
        //    repeatWidth = GetComponent<BoxCollider>().size.y / 2;
        //}
        ////Debug.Log("repeatWidth" + repeatWidth.ToString());
    }

    //void Update()
    //{
    //    //Debug.Log("newPosition " + transform.position.x.ToString());
    //    //Производим сдвиг
    //    transform.Translate(Vector3.left * Time.deltaTime * speed);
    //    Debug.Log(transform.position.x);
    //    //Проверяем полученную позицию
    //    if (transform.position.x < -1300f)
    //    {
    //        transform.position = startPosition;
    //    }
    //}
}

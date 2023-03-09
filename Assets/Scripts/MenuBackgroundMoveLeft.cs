using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//------- ������ ��� ������������ ����������� ���� � �������� ���� -------//
public class MenuBackgroundMoveLeft : MonoBehaviour
{
    [Header("�������� ���������")]
    [Range(300, 500)]
    public float speed;
    [Header("��������� �������")]
    private Vector3 startPosition;
    [Header("����� ������")]
    private float repeatWidth;

    void Start()
    {
        transform.DOMoveX(-1000, 10f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        ////Debug.Log("startPosition " + startPosition.x.ToString());
        ////��������� ��������� �������
        //startPosition = transform.position;
        ////���������� ����� ������
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
    //    //���������� �����
    //    transform.Translate(Vector3.left * Time.deltaTime * speed);
    //    Debug.Log(transform.position.x);
    //    //��������� ���������� �������
    //    if (transform.position.x < -1300f)
    //    {
    //        transform.position = startPosition;
    //    }
    //}
}

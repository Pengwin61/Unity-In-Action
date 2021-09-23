using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;         // Объявляем общедоступную переменную
                                                                // которая появляется в редакторе Unity

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

     void Update()
    {
     if(axes == RotationAxes.MouseX)
        {
            // Это поворот в горизонтальной плоскости
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }   
     else if(axes == RotationAxes.MouseY)
        {
            // Это поворот в вертикальной плоскости
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; // Увеличиваем угол поворота
                                                                      // по вертикали в соответствии
                                                                      // с перемещениями указателя мыши

            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // Фиксируем угол
                                                                            // поворота по вертикали
                                                                            // в диапазоне, заданном
                                                                            // минимальным и максимальным
                                                                            // значениями.

            float rotationY = transform.localEulerAngles.y;     // Сохраняем одинаковый угол
                                                                // поворота вокруг оси Y (т.е
                                                                // вращение в горизонтальной
                                                                // плоскости отсутствует

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);     // Создаем новый вектор
                                                                                    // из сохраненных значений
                                                                                    // поворота
        }
        else
        {
            // это комбинированный поворот
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;    //  Приращение угла поворота
                                                                        //  через значение delta

            float rotationY = transform.localEulerAngles.y + delta;     // Значение delta - это
                                                                        // изменения угла поворота

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
}

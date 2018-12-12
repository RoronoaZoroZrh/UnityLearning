using UnityEngine;

namespace UNetStuty
{
    //Camera Control Component
    public class CameraComponent : MonoBehaviour
    {
        //Rotation delta
        private float _deltaX = 0f;

        //Rotation delta
        private float _deltaY = 0f;

        //Mouse Position
        private Vector3 _mousePosition;

        void Update()
        {
            //Scale
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                gameObject.transform.localPosition = gameObject.transform.localPosition + Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * 10;
            }

            //Rotate
            if (Input.GetMouseButton(1))
            {
                _deltaX = _deltaX + Input.GetAxis("Mouse X") * 5f;
                _deltaY = _deltaY + Input.GetAxis("Mouse Y") * 5f;
                _deltaX = MathUtilities.ClampAngle(_deltaX, -360, 360);
                _deltaY = MathUtilities.ClampAngle(_deltaY, -70, 70);
                gameObject.transform.rotation = Quaternion.Euler(-_deltaY, -_deltaX, 0);
            }

            //Move
            if (Input.GetMouseButtonDown(2))
            {
                _mousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(2))
            {
                Vector3 offset = Input.mousePosition - _mousePosition;
                offset = gameObject.transform.rotation * offset;
                gameObject.transform.localPosition = gameObject.transform.localPosition + offset * -0.005f;
                _mousePosition = Input.mousePosition;
            }
        }
    }
}
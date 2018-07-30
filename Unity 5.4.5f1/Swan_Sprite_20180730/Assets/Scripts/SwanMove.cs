using UnityEngine;

public class SwanMove : MonoBehaviour
{
    private float m_fSpeed = 4.0f;

    private void Start()
    {
        transform.position = new Vector3(22, 3, 0);
    }

    private void Update()
    {
        if (transform.position.x > -22)
        {
            transform.Translate(Vector3.right * -m_fSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(22, 3, 0);
        }
    }
}
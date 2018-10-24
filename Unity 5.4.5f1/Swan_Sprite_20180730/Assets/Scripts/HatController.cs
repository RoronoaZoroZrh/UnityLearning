using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour
{

    #region Properties
    //帽子位置
    private Vector3 m_hatPos;

    //宽度
    private float m_maxWidth;

    //特效
    public GameObject Effect;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {
        Vector3 sceenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(sceenPos);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        m_hatPos = transform.position;
        m_maxWidth = moveWidth.x - hatWidth;
    }

    // Update is called once per physics timestep
    private void FixedUpdate()
    {
        Vector3 rawPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 hatPos = new Vector3(rawPos.x, rawPos.y, 0);
        hatPos.x = Mathf.Clamp(hatPos.x, -m_maxWidth, m_maxWidth);
        GetComponent<Rigidbody2D>().MovePosition(hatPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newEffect = (GameObject)Instantiate(Effect, transform.position, transform.rotation);
        newEffect.transform.parent = transform;
        Destroy(newEffect, 1f);
        Destroy(collision.gameObject);
    }
    #endregion
}
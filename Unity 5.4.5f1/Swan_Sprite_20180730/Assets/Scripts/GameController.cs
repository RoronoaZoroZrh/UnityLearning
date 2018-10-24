using UnityEngine;

public class GameController : MonoBehaviour
{

    #region Properties
    //保龄球
    public GameObject BowlingBall = null;
    private GameObject m_bowlingBallNew = null;

    //宽度
    private float m_maxWidth = float.MinValue;

    //时间
    private float m_fallTime = 2f;
    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        float ballWidth = BowlingBall.GetComponent<Renderer>().bounds.extents.x;
        m_maxWidth = moveWidth.x - ballWidth;
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        m_fallTime = m_fallTime - Time.deltaTime;
        if (m_fallTime < 0)
        {
            m_fallTime = Random.Range(1.5f, 2.0f);
            float posX = Random.Range(-m_maxWidth, m_maxWidth);
            Vector3 spawnPosition = new Vector3(posX, transform.position.y, 0);
            m_bowlingBallNew = (GameObject)Instantiate(BowlingBall, spawnPosition, Quaternion.identity);
            Destroy(m_bowlingBallNew, 10);
        }
    }
}
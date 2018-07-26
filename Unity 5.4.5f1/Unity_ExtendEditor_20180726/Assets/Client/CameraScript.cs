using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    public Rect CameraRect { get; set; }

    [HideInInspector]
    [SerializeField]
    public Texture CameraTexture { get; set; }
}
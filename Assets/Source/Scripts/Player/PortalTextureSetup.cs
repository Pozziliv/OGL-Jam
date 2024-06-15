using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    [SerializeField] private Camera _cameraTeleport;
    [SerializeField] private Material _cameraTeleportMaterial;

    private void Start()
    {
        if (_cameraTeleport.targetTexture != null)
        {
            _cameraTeleport.targetTexture.Release();
        }

        _cameraTeleport.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraTeleportMaterial.mainTexture = _cameraTeleport.targetTexture;
    }
}

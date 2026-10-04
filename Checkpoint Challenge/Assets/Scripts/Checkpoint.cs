using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex;
    [SerializeField] private GameManager gameManager;

    [Header("Checkpoint Colours")]
    [SerializeField] private Color normalColor = Color.red;
    [SerializeField] private Color highlightedColor = Color.green;

    private Renderer checkpointRenderer;

    private void Awake()
    {
        checkpointRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.ReachCheckpoint(checkpointIndex);
        }
    }

    public void SetHighlighted(bool highlighted)
    {
        checkpointRenderer.material.color =
            highlighted ? highlightedColor : normalColor;
    }
}
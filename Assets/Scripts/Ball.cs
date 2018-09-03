using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public Rigidbody2D Rigid { get; private set; }
    public bool Active { get; private set; }

    [SerializeField]
    private GameObject trail;

    private Image image;
    private CircleCollider2D _collider;
    private TrailRenderer _trailRenderer;
    private int waterLayer, uiLayer;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
        image = GetComponent<Image>();
        _collider = GetComponent<CircleCollider2D>();
        waterLayer = LayerMask.NameToLayer("Water");
        uiLayer = LayerMask.NameToLayer("UI");
        _trailRenderer = trail.GetComponent<TrailRenderer>();
    }

    public void Reset()
    {
        Rigid.velocity = Vector3.zero;
        transform.localPosition = Vector2.zero;
        _trailRenderer.startColor = Color.white;
        _trailRenderer.endColor = Color.white;
        image.color = Color.white;
    }


    private void Update()
    {
        Debug.DrawRay(transform.position, -transform.right * 1000);
    }

    public void SetActive(bool active)
    {
        Rigid.simulated = active;
        image.enabled = active;
        _collider.enabled = active;
        Active = active;
        trail.layer = active ? uiLayer : waterLayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameBiheviour.singleton.sound.PlayHit();
        if (collision.gameObject.CompareTag("Wall")) return;
        Color c = collision.gameObject.GetComponent<Image>().color;
        _trailRenderer.startColor = c;
        _trailRenderer.endColor = c;
        image.color = c;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetActive(false);
        Reset();
        this.Deactivate();
    }
}

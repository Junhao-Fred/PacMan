using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class PacStudentMovement : MonoBehaviour
{
    [SerializeField] private AudioClip movingSound;

    private const float Speed = 2f;

    private readonly Vector3[] corners =
    {
        new Vector3(1, -1, 0),
        new Vector3(6, -1, 0),
        new Vector3(6, -5, 0),
        new Vector3(1, -5, 0)
    };

    private Animator animator;
    private Vector3 startPosition;
    private int nextCorner = 1;
    private float elapsed;
    private float duration;

    private void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = corners[0];

        AudioSource sound = GetComponent<AudioSource>();
        sound.clip = movingSound;
        sound.loop = true;
        sound.playOnAwake = false;
        sound.spatialBlend = 0f;
        sound.Play();

        BeginMove();
    }

    private void Update()
    {
        elapsed += Time.deltaTime;

        while (elapsed >= duration)
        {
            elapsed -= duration;
            transform.position = corners[nextCorner];
            nextCorner = (nextCorner + 1) % corners.Length;
            BeginMove();
        }

        transform.position = Vector3.Lerp(startPosition, corners[nextCorner], elapsed / duration);
    }

    private void BeginMove()
    {
        startPosition = transform.position;
        Vector3 direction = corners[nextCorner] - startPosition;
        duration = direction.magnitude / Speed;

        if (direction.x > 0)
            animator.Play("WalkRight", 0, 0f);
        else if (direction.x < 0)
            animator.Play("WalkLeft", 0, 0f);
        else if (direction.y > 0)
            animator.Play("WalkUp", 0, 0f);
        else
            animator.Play("WalkDown", 0, 0f);
    }
}

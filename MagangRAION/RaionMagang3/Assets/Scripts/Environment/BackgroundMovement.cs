using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed;
    private float speedScroll;
    
    private float lengthBG;
	
	private bool reverse;

	public int multiplierObject;
    
    void Start()
    {
        lengthBG = GetComponent<BoxCollider2D>().size.x * GetComponent<Transform>().localScale.x;
        Destroy(GetComponent<BoxCollider2D>());
    }

    void Update()
    {
        SpeedChange();
        Reset();
        transform.Translate(Vector3.left * Time.deltaTime * speedScroll);
    }

    private void SpeedChange()
    {
        speedScroll = speed * BackgroundScroller.instance.speedScrollScale;
		reverse = speedScroll < 0 ? true : false;
    }

    private void Reset()
    {
		if (reverse) {
			if (transform.position.x >= (2 * lengthBG))
			{
				transform.position = new Vector2(transform.position.x - (multiplierObject * lengthBG), transform.position.y );
			}
		} else {
			if (transform.position.x <= -(2 * lengthBG))
			{
				transform.position = new Vector2(transform.position.x + (multiplierObject * lengthBG), transform.position.y );
			}
		}
    }
}

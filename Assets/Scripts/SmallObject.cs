using UnityEngine;

public class SmallObject : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _active;

    private Vector3 _position;



    void Update()
    {
        ControlsSlider_Speed();
        MovementObject();
    }



    private void MovementObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _active = true;
        }

        if (_active == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                _position = hit.point;
            }
            Vector3 direction = _position - transform.position;

            float targ_pos = Vector3.Distance(transform.position, _position);

            if (targ_pos > 1)
            {
                transform.Translate(direction * _speed * Time.deltaTime, Space.World);
            }
            else
            {
                _active = false;
            }
        }
    }



    private void ControlsSlider_Speed()
    {
        _speed = FindObjectOfType<Canvas>().Speed;
    }
}
//By Bortsov "@Qb1ss" Gleb💵//
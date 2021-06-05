using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider _slider;

    [HideInInspector] public float Speed;

    private const float _minSpeed = 1;
    private const float _maxSpeed = 10;



    private void Start()
    {
        _slider.minValue = _minSpeed;
        _slider.maxValue = _maxSpeed;
    }



    private void Update()
    {
        Slider_ControlSpeed();
    }



    public void Button_Restart(string scene)
    {
        SceneManager.LoadScene(scene);
    }



    public void Slider_ControlSpeed()
    {
        Speed = _slider.value;
    }
}
//By Bortsov "@Qb1ss" Gleb💵//
using UnityEngine;

public class BigObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;



    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out SmallObject smallObject))
        {
            for (int i = 0; i < Random.Range(2, 4); i++)
            {
                Instantiate(_objects[i], new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0f, 3f), Random.Range(-2.5f, 2.5f)), Quaternion.identity);
            }
        }
    }
}
//By Bortsov "@Qb1ss" Gleb💵//
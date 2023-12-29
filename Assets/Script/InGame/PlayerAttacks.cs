using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] GameObject _hadoPrefub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hado(List<int> list)
    {
        if ((list.Count > 2 && list[list.Count - 1] == 6 && list[list.Count - 2] == 3 && list[list.Count - 3] == 2)
            || (list.Count > 3 && list[list.Count - 2] == 6 && list[list.Count - 3] == 3 && list[list.Count - 4] == 2))
        {
            Debug.Log("îgìÆåù");
            GameObject tama = Instantiate(_hadoPrefub);
            tama.transform.position = this.transform.position;
            Vector3 tamaVec = GetComponent<PlayerDirection>().PlayerFo;
            tama.GetComponent<hadoPrefub>().SetVec(tamaVec);
        }
    }
}

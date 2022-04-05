using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoDispenser : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private TextMeshPro text2;
    
    private int ammo = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        text2.text = GameManager.Instance.GetAmmoLeft().ToString("000");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmoVisuals()
    {
        text.text = ammo.ToString("000");;
        text2.text = GameManager.Instance.GetAmmoLeft().ToString("000");
    }

    public void AddAmmo(int amount)
    {
        if(ammo == GameManager.Instance.GetAmmoLeft()) return;
        if (ammo + amount > GameManager.Instance.GetAmmoLeft()) ammo = GameManager.Instance.GetAmmoLeft();
        else ammo += amount;
        
        UpdateAmmoVisuals();
    }

    public void ResetAmmo()
    {
        ammo = 0;
        
        UpdateAmmoVisuals();
    }

    public void SubmitAmmo()
    {
        GameManager.Instance.SubmitAmmo(ammo);
    }

    public int GetAmmo()
    {
        return ammo;
    }
}

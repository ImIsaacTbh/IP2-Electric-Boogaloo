
using UnityEngine;

public class WeaponSwitching : MonoBehaviour

{
    public int selectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previouseSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)//allowed you to use the scroll wheel up to change weapon
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
            selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)//allowed you to use the scroll wheel down to change weapon
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
              else
            selectedWeapon--;
            
        }
        if (previouseSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)   //Looks for the number the index is at and will set the weapon to that number
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

using UnityEngine;

namespace RPG.combat
{
    [CreateAssetMenu(fileName ="Weapon", menuName = "Weapons/make new weapon", order =0)]

    public class Weapon : ScriptableObject
    {
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] AnimatorOverrideController AnimationsOverride = null;
        [SerializeField] float weaponDamage = 10;
        [SerializeField] float weaponRange = 2f;
        public void Spawn(Transform handTransform, Animator animator)
        {
            if (weaponPrefab != null)
            {
                Instantiate(weaponPrefab, handTransform);
            }
            if (AnimationsOverride != null)
            {
                animator.runtimeAnimatorController = AnimationsOverride;
            }
           
            
        }

        public float GetDamage()
        {
            return weaponDamage;
        }
        public float GetRange()
        {
            return weaponRange;
        }
    }
    
}
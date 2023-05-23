using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


namespace RPG.ScaneControl
{
    public class portal : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A, B, C, D, E
        }
        [SerializeField] int loadorder;
        [SerializeField] Transform SpawnPoinnt;
        [SerializeField] DestinationIdentifier Destination;
        [SerializeField] float fadeOutTime = 0.5f;
        [SerializeField] float fadeInTime = 1f;
        [SerializeField] float fadeWaitTime = 1f;


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag=="Player")
            {
                StartCoroutine(transition());
            }
           
        }

        private IEnumerator transition()
        {
            DontDestroyOnLoad(gameObject);
            Fader fader = FindObjectOfType<Fader>();

            yield return fader.FadeOut(fadeOutTime);

            yield return SceneManager.LoadSceneAsync(loadorder);
            portal otherPortal = GetOtherPortal();
            updatePlayer(otherPortal);

            yield return new WaitForSeconds(fadeWaitTime);
            yield return fader.FadeIn(fadeInTime);

            Destroy(gameObject);
        }

        private portal GetOtherPortal()
        {
            foreach (portal item in FindObjectsOfType<portal>())
            {
                if (item == this)
                {
                    continue;
                }
                if (item.Destination != Destination) continue;
                return item;
            }
            return null;
           
        }
        private void updatePlayer(portal portal)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = portal.SpawnPoinnt.position;
            player.transform.rotation = portal.SpawnPoinnt.rotation;
            player.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}


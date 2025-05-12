using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoxActivator : MonoBehaviour
{
    [Header("Particle Effects")]
    [SerializeField] private ParticleSystem codyEffect;
    [SerializeField] private ParticleSystem veronicaEffect;
    [SerializeField] private ParticleSystem aliEffect;

    [Header("Glow Material")]
    [SerializeField] private Material glowMaterial;

    [Header("Game Objects")]
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject codyBox;
    [SerializeField] private GameObject veronicaBox;
    [SerializeField] private GameObject aliBox;

    [Header("Magic Items and Audio")]
    [SerializeField] private List<GameObject> superMagicEnableItems;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip magicSound;

    private Material[] treeMaterials;

    private Vector3 codyStartPos, veronicaStartPos, aliStartPos;
    private bool codyActivated = false, veronicaActivated = false, aliActivated = false;

    private int activatedCount = 0;

    private void Start()
    {
        treeMaterials = tree.GetComponent<Renderer>().materials;

        codyStartPos = codyBox.transform.position;
        veronicaStartPos = veronicaBox.transform.position;
        aliStartPos = aliBox.transform.position;
    }

    private void Update()
    {
        if (!codyActivated && Vector3.Distance(codyBox.transform.position, codyStartPos) > 0.01f)
        {
            OnCodyMoved();
        }

        if (!veronicaActivated && Vector3.Distance(veronicaBox.transform.position, veronicaStartPos) > 0.01f)
        {
            OnVeronicaMoved();
        }

        if (!aliActivated && Vector3.Distance(aliBox.transform.position, aliStartPos) > 0.01f)
        {
            OnAliMoved();
        }
    }

    private void OnCodyMoved()
    {
        codyActivated = true;
        ReplaceTreeMaterial(3);
        codyEffect.Play();
        codyBox.SetActive(false);
        CheckCompletion();
    }

    private void OnVeronicaMoved()
    {
        veronicaActivated = true;
        ReplaceTreeMaterial(1);
        veronicaEffect.Play();
        veronicaBox.SetActive(false);
        CheckCompletion();
    }

    private void OnAliMoved()
    {
        aliActivated = true;
        ReplaceTreeMaterial(2);
        aliEffect.Play();
        aliBox.SetActive(false);
        CheckCompletion();
    }

    private void ReplaceTreeMaterial(int index)
    {
        if (glowMaterial != null && index >= 0 && index < treeMaterials.Length)
        {
            treeMaterials[index] = glowMaterial;
            tree.GetComponent<Renderer>().materials = treeMaterials;
        }
    }

    private void CheckCompletion()
    {
        activatedCount++;
        if (activatedCount >= 3)
        {
            StartCoroutine(EnableMagicRoutine());
        }
    }

    private IEnumerator EnableMagicRoutine()
    {
        yield return new WaitForSeconds(2f);

        foreach (var item in superMagicEnableItems)
        {
            item.SetActive(true);
        }

        yield return new WaitForSeconds(2f);

        if (audioSource && magicSound)
        {
            audioSource.clip = magicSound;
            audioSource.Play();
        }
    }
}

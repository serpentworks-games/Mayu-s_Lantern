using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class VignetteDamageEffect : MonoBehaviour
{
    public float intensity;
    public float damage;
    public PostProcessProfile processProfile;

    Vignette vignetteEffect;
    bool exists;
    // Use this for initialization
    void Start()
    {
        exists = processProfile.TryGetSettings<Vignette>(out vignetteEffect);
    }

    private void Update()
    {
        ShowDamage(damage);
    }

    public void ShowDamage(float damage)
    {

        if (exists)
        {
            var vignette = vignetteEffect.intensity.value;

            vignette = Mathf.Lerp(vignette, vignette + damage, Time.deltaTime);
            intensity = vignette;

            if (vignette >= 1)
            {
                vignette = 1;
            }
        }

    }
}

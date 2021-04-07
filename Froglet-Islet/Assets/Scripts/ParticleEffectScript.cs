using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectScript : MonoBehaviour
{
    public ParticleSystem[] ps;
    bool rising; // NOT for rainbow rise, for green swirl
    const float RISE_SPEED = 0.01f;
    float frameNormalizer;

    // Start is called before the first frame update
    void Start()
    {
        ps[0].Stop();
        ps[1].Stop();
        rising = false;
    }

    // Update is called once per frame
    void Update()
    {
        frameNormalizer = Time.deltaTime / 0.15f;
        if(rising)
        {
            ps[0].transform.localPosition = new Vector3(ps[0].transform.localPosition.x, ps[0].transform.localPosition.y + RISE_SPEED * frameNormalizer, ps[0].transform.localPosition.z);
            if (ps[0].transform.localPosition.y > 1f)
                EndEffect();
        }
    }

    public void GreenSwirlEffect()
    {
        ps[0].transform.localPosition = new Vector3(0,-0.5f,0);
        ps[0].Play();
        rising = true;
    }

    public void RainbowRiseEffect()
    {
        ps[1].Play();
        StartCoroutine("DelayEndEffect");
    }

    IEnumerator DelayEndEffect()
    {
        yield return new WaitForSeconds(0.7f);
        EndEffect();
    }

    private void EndEffect()
    {
        ps[0].Stop();
        ps[1].Stop();
        rising = false;
    }

}

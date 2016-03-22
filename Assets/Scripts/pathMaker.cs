using UnityEngine;
using System.Collections;

public class pathMaker : MonoBehaviour {

    /*
    // put this on a small sphere, it will drop a "breadcrumb" trail of floor tiles
DECLARE CLASS MEMBER VARIABLES:
Declare a private integer called counter that starts at 0;
Declare a public Transform called floorPrefab, assign the prefab in inspector;
Declare a public Transform called pathmakerPrefab, assign the prefab in inspector; 
// you'll have to make a "pathmaker" prefab later

UPDATE:
If counter is less than 50, then:
    Generate a random number from 0.0f to 1.0f;
    If random number is less than 0.25f, then rotate 90 degrees;
    ... Else if number is 0.25f-0.5f, then rotate -90 degrees;
    ... Else if number is 0.99f-1.0f, then instantiate a pathmakerPrefab clone at current position;

    Instantiate a floorPrefab clone at current position;
    Move forward (in local space, relative to direction I'm facing) by 5 units;
    Increment counter;
Else:
    Destroy self;
    */

    public Transform tracksPrefab;
    public Transform tracksLPrefab;
    public Transform tracksRPrefab;
    public Transform pathMakerPrefab;

    private int counter = 0;
	
	// Update is called once per frame
	void Update ()
    {
        if (counter < 50)
        {
            float randomNumber = Random.Range(0f, 1f);

            if(randomNumber <0.25f)
            {
                Instantiate(tracksRPrefab, this.transform.position, this.transform.rotation);
                transform.localEulerAngles += new Vector3(0f, 90f, 0f);
            }
            else if (randomNumber >= 0.25f && randomNumber <=0.50f)
            {
                Instantiate(tracksLPrefab, this.transform.position, this.transform.rotation);
                transform.localEulerAngles -= new Vector3(0f, 90f, 0f);
            }
            else if (randomNumber >= 0.99f)
            {
                Instantiate(pathMakerPrefab, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(tracksPrefab, this.transform.position, this.transform.rotation);
            }

            transform.localPosition += transform.forward * 5f;
            counter++;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}

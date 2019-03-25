using System.Collections.Generic;
using UnityEngine;

public static class ConeCastExtension
{
    public static RaycastHit[] ConeCastAll(this Physics physics, Vector3 origin, float minRadius, float maxRadius, Vector3 direction, float maxDistance, float coneAngle)
    {
        RaycastHit[] coneCastHits = ConeCastAll(physics, origin, maxRadius, direction, maxDistance, coneAngle);
        RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin, minRadius, direction, maxDistance);  // Can hit objects which were already hit by the ConeCast

        List<RaycastHit> combinedHits = new List<RaycastHit>();

        combinedHits.AddRange(coneCastHits);
        combinedHits.AddRange(sphereCastHits);


        // Remove hits which share the same GameObject TODO Find a more efficient way to get rid of duplicates
        List<GameObject> individualObjects = new List<GameObject>();

        foreach (RaycastHit hit in combinedHits)
        {
            if (!individualObjects.Contains(hit.transform.gameObject))
            {
                individualObjects.Add(hit.transform.gameObject);

            } else  // This is a duplicate GameObject
            {
                combinedHits.Remove(hit);

            }

        }

        // Return the list of RaycastHits containing no duplicates (no duplucate GameObjects)
        return combinedHits.ToArray();

    }

    public static RaycastHit[] ConeCastAll(this Physics physics, Vector3 origin, float maxRadius, Vector3 direction, float maxDistance, float coneAngle)
    {
        RaycastHit[] sphereCastHits = Physics.SphereCastAll(origin - new Vector3(0, 0, maxRadius), maxRadius, direction, maxDistance);
        List<RaycastHit> coneCastHitList = new List<RaycastHit>();

        if (sphereCastHits.Length > 0)
        {
            for (int i = 0; i < sphereCastHits.Length; i++)
            {
                sphereCastHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
                Vector3 hitPoint = sphereCastHits[i].point;
                Vector3 directionToHit = hitPoint - origin;
                float angleToHit = Vector3.Angle(direction, directionToHit);

                if (angleToHit < coneAngle)
                {
                    coneCastHitList.Add(sphereCastHits[i]);
                }
            }
        }

        RaycastHit[] coneCastHits = new RaycastHit[coneCastHitList.Count];
        coneCastHits = coneCastHitList.ToArray();

        return coneCastHits;
    }
}
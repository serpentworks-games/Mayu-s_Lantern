using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IK.Feet
{

    public class IKHandler : MonoBehaviour
    {
        Animator anim;

        Transform leftFoot;
        Transform rightFoot;

        float lFootWeight;
        float rFootWeight;

        Vector3 lFootPos;
        Vector3 rFootPos;

        Quaternion lFootRot;
        Quaternion rFootRot;

        LayerMask ignoreLayer;
        Vector3 offset = new Vector3(0, 0.15f, 0);

        Transform l_helper;
        Transform r_helper;

        bool ignoreRotation;

        // Use this for initialization
        void Start()
        {
            anim = FindObjectOfType<Animator>();
            leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
            rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

            lFootRot = leftFoot.rotation;
            rFootRot = rightFoot.rotation;

            ignoreLayer = ~(1 << 3 | 1 << 9);

            l_helper = new GameObject().transform;
            l_helper.transform.parent = leftFoot;
            l_helper.localPosition = new Vector3(-0.2f, 0.5f, 0.6f);

            r_helper = new GameObject().transform;
            r_helper.transform.parent = rightFoot;
            r_helper.localPosition = new Vector3(0.2f, 0.5f, 0.6f);

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (anim == null)
            {
                return;
            }

            FindPositions(leftFoot, l_helper, ref lFootPos, ref lFootRot);
            FindPositions(rightFoot, r_helper, ref rFootPos, ref rFootRot);

            lFootWeight = anim.GetFloat("leftFoot");
            rFootWeight = anim.GetFloat("rightFoot");

            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, lFootWeight);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rFootWeight);

            anim.SetIKPosition(AvatarIKGoal.LeftFoot, lFootPos);
            anim.SetIKPosition(AvatarIKGoal.RightFoot, rFootPos);

            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, lFootWeight);
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rFootWeight);

            anim.SetIKRotation(AvatarIKGoal.LeftFoot, lFootRot);
            anim.SetIKRotation(AvatarIKGoal.RightFoot, rFootRot);
        }

        void FindPositions(Transform t, Transform t_helper, ref Vector3 targetPos, ref Quaternion targetRot)
        {
            RaycastHit hit;
            Vector3 origin = t.position;
            origin += Vector3.up * 0.03f;

            if (Physics.Raycast(origin, -Vector3.up, out hit, 1, ignoreLayer))
            {
                ignoreRotation = false;
                if (hit.transform.gameObject.layer == 10)
                {
                    ignoreRotation = true;
                }

                targetPos = hit.point + offset;
                Vector3 dir = t_helper.position - t.position;
                dir.y = 0f;
                Quaternion rot = Quaternion.LookRotation(dir);
                if (!ignoreRotation)
                {
                    targetRot = Quaternion.FromToRotation(Vector3.up, hit.normal) * rot;
                } else
                {
                    targetRot = rot;
                }
            }
        }
    }
}



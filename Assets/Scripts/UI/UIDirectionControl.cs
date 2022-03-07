using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
 {
        public bool useRelativeRotation = true;

        private Quaternion relativeRotaion;

        void Start()
        {
            relativeRotaion = transform.parent.localRotation;
        }

        void Update()
        {
            if (useRelativeRotation)
            {
                transform.rotation = relativeRotaion;
            }
        }
 }

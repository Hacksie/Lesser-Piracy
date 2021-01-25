using UnityEngine;

namespace HackedDesign
{
    public abstract class AbstractController : MonoBehaviour
    {
        public virtual float TurnDirection { get; }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace PrimeTweenDemo {
    // p0 todo replace with AnimateOnClick and serialize TweenAnimation instead? no, because I need to reference all animations from one place to animate them all
    // p0 todo create Demo Pro. With which version of Unity?
    public class OnClick : MonoBehaviour {
        [SerializeField] public UnityEvent onClick = new UnityEvent();

        void Update() {
            if (InputController.GetDown()) {
                Vector2 screenPos = InputController.screenPosition;
                var ray = Camera.main.ScreenPointToRay(screenPos);
                if (Physics.Raycast(ray, out var hit) && IsChild(hit.transform, transform)) {
                    // Debug.Log("onClick", this);
                    onClick.Invoke();
                }
            }
        }

        static bool IsChild(Transform t, Transform other) {
            Transform parent = t.parent;
            while (parent != null) {
                if (parent == other) {
                    return true;
                }
                parent = parent.parent;
            }
            return false;
        }
    }
}

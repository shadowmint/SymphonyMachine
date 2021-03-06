using UnityEngine;
using Jam.Actions;

namespace Jam.Utils
{
    /// Test helper
    public class HistoryLayoutTests : MonoBehaviour
    {
        public float defer = 0.5f;

        public float elapsed = 0f;

        public bool done = false;

        public int state = 0;

        public void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed > defer)
            {

                if (!done)
                {
                    state = 0;
                    done = true;
                }
                if (state == 0)
                {
                    int count = 0;
                    foreach (var target in Scene.FindComponents<SelectSymbol>())
                    {
                        target.action.execute = true;
                        count += 1;
                        if (count > 10)
                        {
                            break;
                        }
                    }
                    state = 1;
                }
                else if (state == 1)
                {
                    Scene.FindComponent<RunSymbols>().action.execute = true;
                    state = 2;
                }
            }
        }
    }
}

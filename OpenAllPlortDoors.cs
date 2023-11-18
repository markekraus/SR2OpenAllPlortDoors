using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace OpenAllPlortDoors
{
    internal class Entry : MelonMod
    {
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (sceneName != "LoadScene")
                return;

            foreach (var item in Resources.FindObjectsOfTypeAll<PuzzleSlot>())
            {
                try
                {
                    if (item._model == null || !item.IsLocked())
                        continue;

                    item._model.filled = true;
                    item._fillOnAwake = true;
                    item.Awake();
                }
                catch (System.Exception e)
                {
                    LoggerInstance.Error($"Failed to unlock {item?.name}", e);
                }
            }
        }
    }
}

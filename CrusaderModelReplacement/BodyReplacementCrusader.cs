using ModelReplacement;
using UnityEngine;

namespace CrusaderModelReplacement
{
    public class BodyReplacementCrusader : BodyReplacementBase
    {
        //Required universally
        protected override GameObject LoadAssetsAndReturnModel()
        {
            //Replace with the Asset Name from your unity project 
            string model_name = "crusPrefab";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }

        protected override void OnEmoteStart(int emoteId)
        {
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(29, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(44, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(49, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(58, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(60, 0);

            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(83, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(84, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(25, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(45, 0);

            if (emoteId == 1) {
               

                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(83, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(84, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(25, 60);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(45, 100);
            }
            if(emoteId == 2)
            {
               

                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(29, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(44, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(49, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(58, 100);
                replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(60, 70);
            }
            
        }

        protected override void OnEmoteEnd()
        {
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(83, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(84, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(25, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(45, 0);

            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(29, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(44, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(49, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(58, 0);
            replacementModel.GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(60, 0);
        }
    }
}

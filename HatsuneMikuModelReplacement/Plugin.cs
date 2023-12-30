using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;

//using System.Numerics;

namespace CrusaderModelReplacement
{
    [BepInPlugin("dd.CrusaderModelReplacement", "crusader Model", "1.4.1")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;

        // Universal config options 
        public static ConfigEntry<bool> enablecrusaderForAllSuits { get; private set; }
        public static ConfigEntry<bool> enablecrusaderAsDefault { get; private set; }
        public static ConfigEntry<string> suitNamesToEnablecrusader { get; private set; }
        
        // crusader model specific config options
        public static ConfigEntry<float> UpdateRate { get; private set; }
        public static ConfigEntry<float> distanceDisablePhysics { get; private set; }
        public static ConfigEntry<bool> disablePhysicsAtRange { get; private set; }

        private static void InitConfig()
        {
            enablecrusaderForAllSuits = config.Bind<bool>("Suits to Replace Settings", "Enable crusader for all Suits", false, "Enable to replace every suit with crusader. Set to false to specify suits");
            enablecrusaderAsDefault = config.Bind<bool>("Suits to Replace Settings", "Enable crusader as default", false, "Enable to replace every suit that hasn't been otherwise registered with crusader.");
            suitNamesToEnablecrusader = config.Bind<string>("Suits to Replace Settings", "Suits to enable crusader for", "Default,Orange suit", "Enter a comma separated list of suit names.(Additionally, [Green suit,Pajama suit,Hazard suit])");

            UpdateRate = config.Bind<float>("Dynamic Bone Settings", "Update rate", 60, "Refreshes dynamic bones more times per second the higher the number");
            disablePhysicsAtRange = config.Bind<bool>("Dynamic Bone Settings", "Disable physics at range", false, "Enable to disable physics past the specified range");
            distanceDisablePhysics = config.Bind<float>("Dynamic Bone Settings", "Distance to disable physics", 20, "If Disable physics at range is enabled, this is the range after which physics is disabled.");
            
        }
        private void Awake()
        {
            config = base.Config;
            InitConfig();
            Assets.PopulateAssets();

            // Plugin startup logic


            if (enablecrusaderForAllSuits.Value)
            {
                ModelReplacementAPI.RegisterModelReplacementOverride(typeof(BodyReplacementCrusader));

            }
            if (enablecrusaderAsDefault.Value)
            {
                ModelReplacementAPI.RegisterModelReplacementDefault(typeof(BodyReplacementCrusader));

            }

            var commaSepList = suitNamesToEnablecrusader.Value.Split(',');
            foreach (var item in commaSepList)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement(item, typeof(BodyReplacementCrusader));
            }
                

            Harmony harmony = new Harmony("dd.CrusaderModelReplacement");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"dd.CrusaderModelReplacement"} is loaded!");
        }
    }
    public static class Assets
    {
        // Replace mbundle with the Asset Bundle Name from your unity project 
        public static string mainAssetBundleName = "crusbundle";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name;
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}
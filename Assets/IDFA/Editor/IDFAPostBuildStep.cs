#if UNITY_IOS
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using System.IO;

public class IDFAPostBuildStep
{
    const string TrackingDescription = "This identifier will be used to deliver personalized ads to you. ";

    [PostProcessBuild(0)]
    public static void OnPostprocessBuild(BuildTarget buildTarget, string pathToXcode)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            AddPListValues(pathToXcode);
            AddFrameworks(pathToXcode);
        }
    }

    static void AddPListValues(string pathToXcode)
    {
        string plistPath = pathToXcode + "/Info.plist";
        
        PlistDocument plistObj = new PlistDocument();
        plistObj.ReadFromString(File.ReadAllText(plistPath));
        
        PlistElementDict plistRoot = plistObj.root;
        plistRoot.SetString("NSUserTrackingUsageDescription", TrackingDescription);
        
        File.WriteAllText(plistPath, plistObj.WriteToString());
    }

    static void AddFrameworks(string pathToXcode)
    {
        string projPath = PBXProject.GetPBXProjectPath(pathToXcode);
        PBXProject proj = new PBXProject();
        proj.ReadFromString(File.ReadAllText(projPath));
        
#if UNITY_2019_3
        string mainTarget = proj.GetUnityFrameworkTargetGuid();
#elif UNITY_2019_4_OR_NEWER
        string mainTarget = proj.GetUnityMainTargetGuid();
#else
        string mainTarget = proj.TargetGuidByName("Unity-iPhone");
#endif
        
        proj.AddFrameworkToProject(mainTarget, "AppTrackingTransparency.framework", true);
        
        File.WriteAllText(projPath, proj.WriteToString());
    }
}
#endif

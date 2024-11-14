using System;
using System.Security.Cryptography.X509Certificates;

public class gameevents
{
    public static event Action onstartgame;
    public static event Action onendgame;
    public static event Action<int> onnewenemycount;
    public static event Action onvictory;
    public static event Action<rewardresources> onreward;
    public static void raisestartgame()=>onstartgame?.Invoke();
    public static void raiseendgame()=>onendgame?.Invoke();
    public static void raisenewenemycount(int count)=>onnewenemycount?.Invoke(count);
    public static void raisevictory()=>onvictory?.Invoke();
    public static void Raiserewad(rewardresources reward)=>onreward?.Invoke(reward);
   
   
}
//Static settings for global access
public static class PlayerSettings 
{   
    public static PlayerController pc;
    public static float xSensitivity;
    public static float ySensitivity;
    public static float mvtSpeed;


    public static void SetVars(PlayerController pc, float xSensitivity, float ySensitivity, float mvtSpeed){
        PlayerSettings.pc = pc;
        PlayerSettings.xSensitivity = xSensitivity;
        PlayerSettings.ySensitivity = ySensitivity;
        PlayerSettings.mvtSpeed = mvtSpeed;
    }
    
}

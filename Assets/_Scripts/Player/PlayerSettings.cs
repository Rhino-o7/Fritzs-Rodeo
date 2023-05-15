//Static settings for global access
public static class PlayerSettings 
{   
    public static PlayerController pc;
    public static Inputs inputs;
    public static float xSensitivity;
    public static float ySensitivity;
    public static float mvtSpeed;


    public static void SetVars(PlayerController pc, Inputs inputs, float xSensitivity, float ySensitivity, float mvtSpeed){
        PlayerSettings.pc = pc;
        PlayerSettings.inputs = inputs;
        PlayerSettings.xSensitivity = xSensitivity;
        PlayerSettings.ySensitivity = ySensitivity;
        PlayerSettings.mvtSpeed = mvtSpeed;
    }
    
}

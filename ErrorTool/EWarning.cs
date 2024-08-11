namespace UTGAutoLoadUnload.Defines
{
    public enum EWarning
    {
        // Robot warning start with index 1000
        Robot_Tool_GlassDetectProblem = 1000,
        Robot_Pick_Fail,
        Robot_SafetyFenceSwitch_Not_Active,
        Robot_EmergencyStop_Active,
        Robot_Automatic_External_Not_active,
        Robot_NoProgramSelected,
        Robot_MessageConfirmRequire,
        Robot_Driver_Not_Ready,
        Robot_Programing_Not_Running,
        Robot_NotConnected,
        Robot_Origin_Vacuum_On,
        Robot_Place_Fail,

        // Left-In warning start with index 2000
        LeftIn_Slider_NotDetected = 2000,
        LeftIn_Slider_NotLocked,
        LeftIn_Slider_UnlockFail,
        LeftIn_Jig_NotDetected,
        LeftIn_JigType_NotMatch,
        LeftIn_SubDoor_NotLocked,
        LeftIn_SubDoor_SensorNotDetected,
        LeftIn_SubDoor_UnlockFail,
        LeftIn_UnAlign_Fail,


        LeftIn_Transfer_UpFail,
        LeftIn_Transfer_DownFail,
        LeftIn_Transfer_BWFail,
        LeftIn_Transfer_FWFail,
        LeftIn_TrayType_DetectFail,
        LeftIn_TrayAlign_ForwardFail,
        LeftIn_TrayAlign_BackwardFail,
        LeftIn_SPT_DownFail,
        LeftIn_CST_UpFail,
        LeftIn_SPT_UpFail,
        LeftIn_CST_DownFail,
        LeftIn_Transfer_UnGripFail,
        LeftInTransfer_UpFail,
        LeftIn_Transfer_GripFail,

        // TraySupplier warning start with index 3000
        TraySupplier_Slider_NotDetected = 3000,
        TraySupplier_Slider_NotLocked,
        TraySupplier_Slider_UnlockFail,
        TraySupplier_Jig_NotDetected,
        TraySupplier_JigType_NotMatch,
        TraySupplier_SubDoor_NotLocked,
        TraySupplier_SubDoor_SensorNotDetected,
        TraySupplier_SubDoor_UnlockFail,



        // Right-In warning start with index 4000
        RightIn_Slider_NotDetected = 4000,
        RightIn_Slider_NotLocked,
        RightIn_Slider_UnlockFail,
        RightIn_Jig_NotDetected,
        RightIn_JigType_NotMatch,
        RightIn_SubDoor_NotLocked,
        RightIn_SubDoor_SensorNotDetected,
        RightIn_SubDoor_UnlockFail,



        RightIn_CST_UpFail,
        RightIn_SPT_UpFail,
        RightIn_SPT_DownFail,
        RightIn_CST_DownFail,



        // NG Tray warning start with index 5000
        NGTray_Slider_NotDetected = 5000,
        NGTray_Slider_NotLocked,
        NGTray_Slider_UnlockFail,
        NGTray_Jig_NotDetected,
        NGTray_JigType_NotMatch,
        NGTray_SubDoor_NotLocked,
        NGTray_SubDoor_SensorNotDetected,
        NGTray_Door_UnlockFail,
        NGTray_UnAlign_Fail,


        NGTray_Transfer_UpFail,
        NGTray_Transfer_DownFail,
        NGTray_TransferBWFail,
        NGTray_TransferFWFail,
        NGTray_EndUp_Not_Detect,
        NGTray_TrayType_DetectFail,
        NGTray_TrayAlign_ForwardFail,
        NGTray_TrayAlign_BackwardFail,


        //Vision warning start with index 6000
        Vision_Flow_Not_Contain_GrabTool = 6000,
        Camera_In_GrabTool_Not_Initial,
        Vision_Flow_Not_Contain_OutputTool,
        Camera_Not_Connected,
        Vision_NoOutputReturn,
        Vision_RunTimeError,

        //NGTrayTransfer warning start with index 6000,
        NGTray_TransferVacuumOffFail,
        NGTray_TransferVacuumOnFail,

        TEST_WARNING = 9999,
    }
}

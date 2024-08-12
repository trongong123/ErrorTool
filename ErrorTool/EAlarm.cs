namespace UTGAutoLoadUnload.Defines
{
    public enum EAlarm
    {
        Main_Air_Not_Supplied = 0,

        // Robot alarm start with index 1000
        Robot_MoveOrigin_RequestFail = 1000,
        Robot_Origin_MoveFail,
        Robot_ReadyPick_RequestFail,
        Robot_ReadyPick_MoveFail,
        Robot_ReadyPick1_RequestFail,
        Robot_ReadyPick1_MoveFail,
        Robot_Pick1_RequestFail,
        Robot_Pick1_MoveFail,
        Robot_Pick_RequestFail,
        Robot_Pick_MoveFail,
        Robot_Pick2_RequestFail,
        Robot_Pick2_MoveFail,
        Robot_ReadyPick2_RequestFail,
        Robot_ReadyPick2_MoveFail,
        Robot_MoveReadyPlace_RequestFail,
        Robot_ReadyPlace_MoveFail,
        Robot_MoveReadyPlace1_RequestFail,
        Robot_ReadyPlace1_MoveFail,
        Robot_MoveReadyPlace2_RequestFail,
        Robot_ReadyPlace2_MoveFail,
        Robot_MovePlace1_RequestFail,
        Robot_Place1_MoveFail,
        Robot_MovePlace_RequestFail,
        Robot_Place_MoveFail,
        Robot_MovePlace2_RequestFail,
        Robot_Place2_MoveFail,
        Robot_MoveReady_RequestFail,
        Robot_Ready_MoveFail,

        Robot_MoveReadyPlaceNG_RequestFail,
        Robot_ReadyPlaceNG_MoveFail,
        Robot_MoveReadyPlaceNG1_RequestFail,
        Robot_ReadyPlaceNG1_MoveFail,
        Robot_MovePlaceNG1_RequestFail,
        Robot_PlaceNG1_MoveFail,
        Robot_MovePlaceNG2_RequestFail,
        Robot_PlaceNG2_MoveFail,

        Robot_MoveReadyPlaceNG2_RequestFail,
        Robot_ReadyPlaceNG2_MoveFail,

        Robot_MoveReadyVision_RequestFail,
        Robot_ReadyVision_MoveFail,
        Robot_MoveVision_RequestFail,
        Robot_Vision_MoveFail,
        Robot_ConnectFail,
        Robot_NoReadyResponse,
        Robot_SetModelFail,

        // Left-In alarm start with index 2000
        LeftIn_ZAxis_OriginFail = 2000,
        LeftIn_ZAxis_TraySearchTimeOut,


        LeftIn_CST_DoorLockFail,
        LeftIn_Slider_LockFail,
        LeftIn_Slider_UnlockFail,
        LeftIn_Door_LockFail,
        LeftIn_Door_UnlockFail,
        LeftIn_ZAxis_MoveChangePositionTimeout,
        LeftIn_ZAxis_MoveTiltPositionTimeout,
        LeftIn_ZAxis_ConnectFail,
        LeftIn_Motion_ConnectFail,
        LeftIn_ZAxis_MoveTimeout,

        // TraySupplier alarm start with index 3000
        TraySupplier_ZAxis_OriginFail = 3000,
        TraySupplier_ZAxis_TraySearchTimeOut,
        
        TraySupplier_ZAxis_MoveStartWorkingPositionTimeout,
        TraySupplier_ZAxis_MoveChangePositionTimeout,
        TraySupplier_ZAxis_MoveTimeout,
        TraySupplier_ZAxis_ConnectFail,
        TraySupplier_Motion_ConnectFail,

        // Right-In alarm start with index 4000
        RightIn_ZAxis_OriginFail = 4000,
        RightIn_ZAxis_TraySearchTimeOut,
        
        RightIn_CST_DoorLockFail,
        RightIn_ZAxis_MoveChangPositionTimeout,
        RightIn_CST_SliderLockFail,
        RightIn_ZAxis_MoveTiltPositionTimeout,
        RightIn_ZAxis_ConnectFail,
        RightIn_Motion_ConnectFail,

        //NG Tray alarm start with index 5000

        NGTray_ZAxis_OriginFail = 5000,
        NGTray_ZAxis_TraySearchTimeout,
        NGTray_Door_LockFail,
        NGTray_Door_UnlockFail,
        NGTray_ZAxis_MoveChangePositionTimeout,
        NGTray_ZAxis_ConnectFail,
        NGTray_Motion_ConnectFail,
        NGTray_ZAxis_MoveTimeout,

        //LeftInTransfer alarm start with index 6000,

        //NGTrayTransfer alarm start with index 6000,
        NGTray_Transfer_Origin_VacuumOn = 7000,


        Vision_AlignCamera_ConnectFail = 8000,
        Vision_LightController_ConnectFail,

        TEST_ALARM = 9999,
    }
}

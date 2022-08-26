using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantsComp
{
    // Các màn chơi
    public static string LEVEL1 = "Map1Lien";
    public static string LEVEL2 = "Map2Lan";
    public static string STARTUP = "MapStartUp";

    // Thông báo qua màn
    public static string NEXTDOORCONDITION = "Hiện tại bạn có {0} chìa khóa. Cần thêm {1} chìa khóa nữa để qua màn!!!";

    // Thông báo người chơi mất mạng
    public static string DEADCHARACTER = "Bạn đã bị tấn công bởi {0}";

    // Thông báo cho màn khởi động
    public static string MOVE = "Bạn ấn phím A - D hoặc ấn mũi tên trái - phải để di chuyển";
    public static string SPACE = "Bạn ấn phím cách để nhảy lên";
    public static string CTRL = "Bạn ấn phím Ctrl để cúi xuống";
    public static string KEY = "Bạn ăn chìa khóa để qua màn";
    public static string WARNING = "Cẩn thận hãy tránh né quái vật - Nhảy lên";
}

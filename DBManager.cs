using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int MedicXP;
    public static int InfectedXP;

    public static bool LoggedIn{get{ return username != null; }}

    public static void LoggedOut()
    {
        username = null;
    }
}

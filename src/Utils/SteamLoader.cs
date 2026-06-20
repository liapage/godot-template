namespace Game.Utils;

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Godot;
// using Steamworks;

public static class SteamLoader
{
    public static bool Init()
    {
        // NativeLibrary.SetDllImportResolver(typeof(SteamAPI).Assembly, ResolveSteamLibrary);
        // return SteamAPI.Init();
        return true;
    }

    private static IntPtr ResolveSteamLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName == "steam_api" || libraryName == "libsteam_api")
        {
            var platformPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libsteam_api.so");

            if (OperatingSystem.IsMacOS())
            {
                platformPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libsteam_api.dylib");
            }
            else if (OperatingSystem.IsWindows())
            {
                platformPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "steam_api64.dll");
            }

            if (File.Exists(platformPath))
            {
                return NativeLibrary.Load(platformPath);
            }
        }

        GD.PrintErr("Couldn't find steam lib");
        return IntPtr.Zero;
    }
}

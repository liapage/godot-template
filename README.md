# Godot Template

## Steamworks

To make it work for MacOS Apple Silicon, I had to clone https://github.com/rlabrecque/Steamworks.NET and build it myself:

```bash
dotnet build -c Release /p:PlatformTarget=AnyCPU
cp bin/x86/Windows/netstandard2.1/Steamworks.NET.dll ~/Development/lumi4x/chaos/Steamworks/OSX-Linux-x64/
```

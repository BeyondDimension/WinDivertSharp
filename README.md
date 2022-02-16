# WinDivertSharp
A minimal .NET binding over [WinDivert](https://github.com/basil00/Divert).

Available on [Nuget](https://www.nuget.org/packages/Aigio.WinDivertSharp).

## 修改内容
- 本机 dll 与 sys 放置在 nuget 包 [runtimes 文件夹](https://docs.microsoft.com/zh-cn/nuget/create-packages/supporting-multiple-target-frameworks#architecture-specific-folders)
- Header ushort & uint 使用 LittleEndian
# CrossSpeak

A cross-platform C# library designed for seamless integration with the active screen reader on Windows, macOS, and Linux systems.
It provides a unified interface for developers to incorporate screen reader functionality into their applications,
making it easier to create inclusive and accessible software experiences.
This library only works 64-bit environment and it uses [Tolk](https://github.com/ndarilek/tolk) for windows,
[libspeechdwrapper](https://github.com/khanshoaib3/libspeechdwrapper) for linux and [libspeak](https://github.com/Flameborn/libspeak) for MacOSX.

## Compatibility

As the library is built .NET Standard 2.0, it is compatible with .NET 2.0+, .NET Core 2.0+ and .NET Framework 4.6.1+.
[More info](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0#select-net-standard-version).

## Installation

### From Nuget.org

The library is available on [nuget](https://www.nuget.org/packages/TOWK.Utility.CrossSpeak) and you can use the following command to add it to your project:

```bash
dotnet add package TOWK.Utility.CrossSpeak --version 1.0.0
```

### Manual

Download the latest version from [releases](https://github.com/khanshoaib3/CrossSpeak/releases) and extract the contents to your project's root.
Add the reference to `CrossSpeak.dll` in your project's file as follows:

```xml
<ItemGroup>
	<Reference Include="./CrossSpeak.dll" />
</ItemGroup>
```

You would also need to copy the screen reader libraries to the output directory, here's how you can set it up to always copy them on build in your project's file:

```xml
<Target Name="CopyCustomContent" AfterTargets="AfterBuild">
	<Copy SourceFiles="lib\screen-reader-libs\linux\libspeechdwrapper.so" DestinationFolder="$(OutDir)lib\screen-reader-libs\linux" />
	<Copy SourceFiles="lib\screen-reader-libs\windows\nvdaControllerClient64.dll" DestinationFolder="$(OutDir)lib\screen-reader-libs\windows" />
	<Copy SourceFiles="lib\screen-reader-libs\windows\SAAPI64.dll" DestinationFolder="$(OutDir)lib\screen-reader-libs\windows" />
	<Copy SourceFiles="lib\screen-reader-libs\windows\Tolk.dll" DestinationFolder="$(OutDir)lib\screen-reader-libs\windows" />
	<Copy SourceFiles="lib\screen-reader-libs\macos\libspeak.dylib" DestinationFolder="$(OutDir)lib\screen-reader-libs\macos" />
</Target>
```

## How to use

Using CrossSpeak is pretty straightforward.
Initialize the library and then you can easily interact interact with the active screen reader using the provided API.
Check out [IScreenReader.cs](https://github.com/khanshoaib3/CrossSpeak/blob/master/CrossSpeak/IScreenReader.cs) to get an understanding about the different API method calls.

Here's a quick example:

```csharp
using CrossSpeak;

CrossSpeakManager.Instance.Initialize();
CrossSpeakManager.Instance.Speak("Hello there!");
CrossSpeakManager.Instance.Close();
```

*Make sure to always call the `Close()` method before your application closes.*

## Future Plans

1. Improve linux support by updating `libspeechdwrapper`, maybe use C/C++ for the wrapper library.

## Known Issues

1. The `IsSpeaking()` method always returns `false` for windows. I think this is something that needs to be fixed in `Tolk` itself.

# VISA.NET example

[![Build Status Github](https://github.com/vnau/IviVisaNetSample/actions/workflows/build.yml/badge.svg)](https://github.com/vnau/IviVisaNetSample/actions/workflows/build.yml) [![Build Status AppVeyor](https://ci.appveyor.com/api/projects/status/dag3r35u0sn1sci3?svg=true)](https://ci.appveyor.com/project/vnau/IviVisaNetSample)

> [!IMPORTANT]
> The need for this repository and the **Kelary.Ivi.Visa** package is no longer required. The **IVI Foundation** has released an [official NuGet package for VISA.NET Shared Components](https://www.nuget.org/packages/IviFoundation.Visa) v8.0+, which now fully supports **.NET 6.0** and later versions. This eliminates the need for the previous workarounds and custom solutions used in this repository.
>
> Going forward, developers should migrate to the official IVI Foundation VISA.NET package for VISA.NET v7.4+ implementations (currently supported by **Keysight** and **NI**), ensuring a more stable and maintainable integration for instrument communication in modern .NET applications. This official package simplifies the process and provides full support for various third-party VISA implementations, making this repository obsolete.

In the traditional approach, [VISA.NET Shared Components](https://www.ivifoundation.org/Shared-Components/default.html#visa-and-visanet-shared-components) are distributed solely as part of a vendor's installer for its VISA implementation.
This approach necessitates the installation of the vendor's VISA library implementation on the CI server environment, even if communication with instruments is not required at this stage.

If a developed application is intended to work with various third-party VISA implementations, and no VISA libraries are installed, it would be beneficial if it could provide only a part of the functionality or report the necessity of the VISA library.

This is a simple example of an application bypassing those limitations by using the unofficial NuGet VISA.NET Shared Components distribution, [Kelary.Ivi.Visa](https://www.nuget.org/packages/Kelary.Ivi.Visa/).

### Using VISA.NET in .NET 5+ solutions

.NET Standard, introduced in 2016, marked a pivotal moment in the evolution of the .NET ecosystem.
Since then, many versions of .NET have emerged, diminishing the relevance of the traditional .NET Framework for new projects.

Despite these advancements, VISA.NET remains tied to .NET Framework 2.0, with no indication from the IVI Foundation of plans to embrace modern technologies.

A notable challenge is VISA.NET's limited integration into projects with contemporary .NET runtimes.
However, compatibility has improved since .NET Core 2, allowing referencing of .NET Framework assemblies in compatibility mode. This suggests potential usability of the VISA.NET library and .NET Framework implementations within a modern .NET runtime.

Another challenge arises as the modern .NET runtime no longer uses the GAC, which VISA.NET relies on.
This issue is mitigated by preloading VISA.NET implementations.

In this repository, an **experimental** .NET 8 example application showcases potential VISA.NET usage with various vendors implementations.
Despite progress, successful execution is not guaranteed, as the .NET runtime may lack support for all .NET Framework APIs.
Basic functions have been tested with Rohde & Schwarz and Keysight implementations, but some functions may require further testing.

We look forward to the IVI Foundation moving the VISA.NET library from the .NET Framework to the .Net Standard, which will allow VISA.NET to become not only interchangeable, but also cross-platform.

IVI Foundation announces in [VPP-4.3.6](https://www.ivifoundation.org/downloads/VISA/vpp436_2024-02-08.pdf) that the _VISA.NET_ shared components version 7.3 and later will be available in both _.NET Framework_ versions that target _.NET 4.5_, and _.NET_ versions that target _.NET 6.0_ or after.

### Existing VISA.NET implementations

In most cases, an application built with VISA.NET Shared Components version 5.5 will work with later implementations of Shared Components.
For .NET 5+ projects, the Shared Components version must match those that the implementation depends on.

Below is a non-exhaustive list of vendor-specific VISA implementations with VISA.NET support.

| Implementation                                                                                                                                                         | Size    | VISA.NET Shared Components Version |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------- | ---------------------------------- |
| [Keysight IO Libraries Suite 2025](https://www.keysight.com/de/de/lib/software-detail/computer-software/io-libraries-suite-downloads-2175637.html)                     | 251 MB  | 8.0.1                              |
| [NI-VISA 2025 Q2](https://download.ni.com/support/nipkg/products/ni-v/ni-visa/25.3/offline/ni-visa_25.3.0_offline.iso)                                                 | 1.51 GB | 8.0.1                              |
| [Rohde & Schwarz VISA 7.2.5 for Windows](https://scdn.rohde-schwarz.com/ur/pws/dl_downloads/dl_application/application_notes/1dc02___rs_v/RS_VISA_Setup_Win_7_2_5.exe) | 60 MB   | 7.2                                |
| [NI-VISA 2023 Q4](https://download.ni.com/support/nipkg/products/ni-v/ni-visa/23.8/offline/ni-visa_23.8.0_offline.iso)                                                 | 1.41 GB | 7.2                                |
| [Rohde & Schwarz VISA 5.12.3 for Windows](https://www.rohde-schwarz.com/us/applications/r-s-visa-application-note_56280-148812.html)                                   | 59 MB   | 5.11                               |
| [Keysight IO Libraries Suite 2019](https://www.keysight.com/main/software.jspx?id=2175637)                                                                             | 251 MB  | 5.11                               |
| [NI-VISA 20.0](https://www.ni.com/en/support/downloads/drivers/download.ni-visa.html#346210)                                                                           | 1.16 GB | 5.11                               |
| [Keysight IO Libraries Suite 2018](https://www.keysight.com/main/software.jspx?id=2175637)                                                                             | 260 MB  | 5.8                                |
| [Keysight IO Libraries Suite 17.2](https://www.keysight.com/main/software.jspx?id=2784293)                                                                             | 191 MB  | 5.6                                |
| [NI-VISA 15.0,17.5](https://www.ni.com/en/support/downloads/drivers/download.ni-visa.html#306106)                                                                      | 122 MB  | 5.6                                |
| [Kikusui KI-VISA 5.5](https://www.kikusui.co.jp/en/download/en/?fn=com_kivisa)                                                                                         | 89 MB   | 5.5                                |

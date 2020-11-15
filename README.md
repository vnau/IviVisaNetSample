# VISA.NET example #

[![Build Status on Travis-CI](https://api.travis-ci.org/vnau/IviVisaNetSample.svg?branch=master)](https://travis-ci.org/vnau/IviVisaNetSample) [![Build status](https://ci.appveyor.com/api/projects/status/dag3r35u0sn1sci3?svg=true)](https://ci.appveyor.com/project/vnau/IviVisaNetSample)

In traditional approach [VISA.NET Shared Components](http://www.ivifoundation.org/shared_components/) distributed only as part of a vendor's installer for its VISA implementation.
This approach suppose installation of vendor's VISA library implementation on CI server environment even if communication with instruments is not required on this stage.

If developed application assumed to work with various third-party VISA implementations and no VISA libraries were installed it would be nice if it could provide only a part of the functionality or report VISA library necessity.

This is simple example of application bypassing those limitations using unofficial NuGet VISA.NET Shared Components distribution [Kelary.Ivi.Visa](https://www.nuget.org/packages/Kelary.Ivi.Visa/).

### VISA.NET implementations ###

In most cases, an application built with VISA.NET Shared Components version 5.5 will work with latter implementations of Shared Components.

Below is a non-exhausting list of vendor-specific VISA implementations with VISA.NET support.

| Implementation | Size | VISA.NET Shared Components Version |
| --- | ---- | ---- |
| [Rohde & Schwarz VISA 5.12.3 for Windows](https://www.rohde-schwarz.com/us/applications/r-s-visa-application-note_56280-148812.html) | 59 MB | 5.11 |
| [Keysight IO Libraries Suite 2019](https://www.keysight.com/main/software.jspx?id=2175637) | 251 MB | 5.11 |
| [NI-VISA 20.0](https://www.ni.com/ru-ru/support/downloads/drivers/download.ni-visa.html#346210)| 1.16 GB | 5.11 |
| [Keysight IO Libraries Suite 2018](https://www.keysight.com/main/software.jspx?id=2175637) | 260 MB | 5.8  |
| [Keysight IO Libraries Suite 17.2](https://www.keysight.com/main/software.jspx?id=2784293) | 191 MB | 5.6  |
| [NI-VISA 15.0,17.5](http://www.ni.com/download/ni-visa-17.5/7220/en/) | 756 MB | 5.6  |
| [Kikusui KI-VISA 5.5](https://www.kikusui.co.jp/en/download/en/?fn=com_kivisa) | 89 MB | 5.5  |

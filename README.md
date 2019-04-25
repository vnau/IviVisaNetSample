# VISA.NET example #

[![Build Status on Travis-CI](https://api.travis-ci.org/vnau/IviVisaNetSample.svg?branch=master)](https://travis-ci.org/vnau/IviVisaNetSample)

In traditional approach [VISA.NET Shared Components](http://www.ivifoundation.org/shared_components/) distributed only as part of a vendor's installer for its VISA implementation.
This approach suppose installation of vendor's VISA library implementation on CI server environment even if communication with instruments is not required on this stage.

If developed application assumed to work with various third-party VISA implementations and no VISA libraries were installed it would be nice if it could provide only a part of the functionality or report VISA library necessity.

This is simple example of application bypassing those limitations using unofficial NuGet VISA.NET Shared Components distribution [Kelary.Ivi.Visa](https://www.nuget.org/packages/Kelary.Ivi.Visa/).

### VISA.NET implementations ###

Following third-party VISA.NET implementations available:

| Implementation                                                  | VISA.NET Shared Components Version |
| ---------------------------------------------------------------------------------------------- | --- |
| [Keysight IO Libraries Suite 2018(18)](https://www.keysight.com/main/software.jspx?id=2175637) | 5.8 |
| [Keysight IO Libraries Suite 17.2](https://www.keysight.com/main/software.jspx?id=2784293)     | 5.6 |
| [NI-VISA 15.0,17.5](http://www.ni.com/download/ni-visa-17.5/7220/en/)                          | 5.6 |
| [Kikusui KI-VISA 5.5](https://www.kikusui.co.jp/en/download/en/?fn=com_kivisa)                 | 5.5 |

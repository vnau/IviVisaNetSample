# VISA.NET example #

In traditional approach [VISA.NET Shared Components](http://www.ivifoundation.org/shared_components/) distributed only as part of a vendor's installer for its VISA implementation.
This approach requires installation of vendor's VISA library implementation on build server even if communication with instruments is not needeed on this stage.

If developed application assumed to work with various third-party VISA implementations and no VISA libraries were installed it would be nice if it could provide only a part of the functionality or report VISA library neccesarity.

This is simple example of application bypassing those limitations using unofficial NuGet VISA.NET Shared Components distribution [Kelary.Ivi.Visa](https://www.nuget.org/packages/Kelary.Ivi.Visa/).

### VISA.NET implementations ###

Following third-party VISA.NET implementations available:

| Implementation                    | VISA.NET Shared Components Version |
| --------------------------------- | --- |
| Keysight IO Libraries Suite 17.2  | 5.6 |
| Keysight IO Libraries Suite 18    | 5.8 |
| NI-VISA 15.0                      | 5.6 |
| Kikusui KI-VISA 5.5               | 5.5 |

# VISA.NET example #

In traditional approach VISA.NET Shared Components distributed only as part of a vendor's installer for its VISA implementation.
This approach requires installation of vendor's VISA library implementation on build server even if communication with instruments is not needeed on this stage.

If developed application assumed to work with various third-party VISA implementations and no VISA libraries were installed it would be nice if it could provide only a part of the functionality or report VISA library neccesarity.

This is simple example of application bypassing this limitations using unofficial NuGet VISA.NET Shared Components distribution.
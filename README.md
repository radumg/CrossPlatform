# CrossPlatform

This repo hosts the sample code written for the [BiLT EUR 2018](https://www.rtcevents.com/bilt/eur18/) `Cross-platform development : from Revit/Dynamo to Rhino/Grasshopper and the web` hands-on labs.
The lab was accompanied by a lenghty handout that is available on the BiLT website for registered people.

## Purpose

Be a reference, source of inspiration & education for others. 

## What is it

It's a sample of how to build `cross-product` libraries for AEC apps, with a focus on
- re-using as much code as possible
- demonstrating some SOLID principles in action
- supporting as many apps as possible

The solutions is made of up of 2 things : a common library and specific application implementations.

### Crossplatform Library
This is the shared functionality that is product-agnostic & re-usable.

It holds the 
- geometry & BIM element definitions
- interoperability/conversion routines

### App implmentations
Distinct applications that bring the `Crossplatform.Library`to each platform :
- Revit app
- Dynamo app
- Rhino app
- Grasshopper app

## What does it do

### Geometry
It's a bare-bones geometry-sharing library, with definitions for
- Point
- Line
- Wall

You can converto `To` & `From` the `Crossplatform.Geometry` objects in `Revit`, `Dynamo`, `Rhino` & `Grasshopper`.
You'll also note that not all conversions are straight-forward : there's no `Wall` in Rhino, so that conversion shows how to think about translating non-compatible objects.

### WhoAmI
All has a simple `WhoAmI` command that has a single implementation for all products, but still manages to be a bit product-specific.

## Notes

- developed over 2 days before BiLT, so don't expect crazy-good code, I'm aiming for decent here
- this is not in active development, but modifications (pull requests, PRs) are welcomed if they add to the educational value of the repo

## License
MIT

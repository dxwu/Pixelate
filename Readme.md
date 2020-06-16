# Pixelate images

Blends image pixels in custom dimensions.

<img src="samples/sunday.jpg" alt="drawing" width="300"/>
<img src="samples/result_sunday.jpg" alt="drawing" width="300"/>

<br/>
<img src="samples/night.jpg" alt="drawing" width="300"/>
<img src="samples/result_night.jpg" alt="drawing" width="300"/>

<br/>
<img src="samples/arnolfini.jpg" alt="drawing" width="300"/>
<img src="samples/result_arnolfini.jpg" alt="drawing" width="300"/>

## Setup

Install dotnet core

```
dotnet build
```

## Run

Copy an image to this directory

```
dotnet run [image] [pixelWidth] [pixelHeight]
```

For example:

```
dotnet run samples/sunday.jpg 75 1200
```

The resuting image is saved as result.jpg
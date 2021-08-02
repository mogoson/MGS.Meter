[TOC]

﻿# MGS.Meter

## Summary
- Unity plugin for make Clock and Meter in scene.

## Environment
- .Net Framework 3.5 or above.
- Unity 5.0 or above.

## Platform

- Windows

## Demand

- Standard Clock with Hour, Minute and Second pointers.
- Normal Meter with multi pointers.
- Lerp Meter with multi pointers smooth rotate.

## Implemented
```C#
public struct ClockPointer{}
public class PointerClock : MonoBehaviour, IClock{}

public struct MeterPointer{}
public class PointerMeter : MonoBehaviour, IPointerMeter{}
public class LerpPointerMeter : PointerMeter{}
```

## Usage

1. Add the component to your game object.
2. Set the parameters of the component.

## Demo
- Demos in the path "MGS.Packages/Meter/Demo/" provide reference to you.

## Preview
- Clock

![Clock](./Attachment/images/Clock.gif)﻿

- Lerp Meter

![Lerp Meter](./Attachment/images/LerpMeter.gif)﻿

------

Copyright © 2021 Mogoson.	mogoson@outlook.com
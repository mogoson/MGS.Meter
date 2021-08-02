[TOC]

﻿# MGS.UMeter.dll

## Summary
- Made Pointer Clock and Meter in Unity scene.

## Environment
- .Net Framework 3.5 or above.
- Unity 5.0 or above.

## Dependence
- System.dll
- UnityEngine.dll

## Demand
- Made Pointer Clock and auto run if turn on.
- Made Pointer Clock and run by set angle.

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

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com